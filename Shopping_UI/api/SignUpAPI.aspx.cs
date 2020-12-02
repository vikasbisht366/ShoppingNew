using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.IO;

public partial class api_SignUpAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    static int cusid = 0;
    static string username;
    static string email;
    static string pass;
    static string mobile;
    static string memberid;
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Random random = new Random();
        memberid = "GRT" + random.Next(100000, 900000).ToString();

        if (Request.QueryString["Type"] != "")
        {
            try
            {
                cusid = Convert.ToInt32(Request.QueryString["id"]);
                username = Request.QueryString["userid"];
                email = Request.QueryString["emailid"];
                pass = Request.QueryString["password"];
                mobile = Request.QueryString["mobileno"];

                #region Signup Api
                if (Request.QueryString["Type"].ToString() == "CreateAccount")
                {
                    UserSignup(cusid, username, email, pass);
                }
                if (Request.QueryString["Type"].ToString() == "OTPVERIFY")
                {
                    otpverify();
                }
                #endregion
            }
            catch
            {
                dt = MasterMassage("Status", "false", "Message", "Somthing went rong.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Invalid Request");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void otpverify()
    {
        if (mobile != null)
        {
            Random randomotp = new Random();
            string OTP = randomotp.Next(1000, 9999).ToString();

            DataTable dt = objaccess.GetDatatable("Select * from tblCustomer where Mobile_No='" + mobile + "' ");
            if (dt.Rows.Count > 0)
            {
                dt = MasterMassage("Status", "false", "Message", "Mobile Number Is Already Register .");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
            else
            {
                string Message = "Your Mobile No. Verify OTP is (" + OTP + ").One Time Password is " + OTP + " ";
                SendSMS(mobile, Message);

                DataTable dts = MasterMassage("Status", "true", "Message", " " + OTP + " ");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dts, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            DataTable dt = MasterMassage("Status", "false", "Message", "Mobile Number,UserName & Password Is required.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }


    public void UserSignup(int cusid, string username, string email, string pass)
    {

        string ipaddress = GetIPAddress();
        string refrral = "";
        if (username != null && pass != null && mobile != null)
        {
            DataTable dt = objaccess.GetDatatable("Select * from tblCustomer where Mobile_No='" + mobile + "' ");
            if (dt.Rows.Count > 0)
            {
                dt = MasterMassage("Status", "false", "Message", "Mobile Number Is Already Register .");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
            else
            {
                string query = "Exec proc_AddEditCustomerRegistration " + cusid + ",'" + username + "','" + email + "','" + pass + "','" + ipaddress + "','" + mobile + "','" + memberid + "','" + refrral + "' ";
                DataTable dts = objaccess.GetDatatable(query);
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dts, Newtonsoft.Json.Formatting.Indented));

                string Message = "Your Account Create Successfully.Your UserID : " + mobile + " and Password : " + pass + " ";
                SendSMS(mobile, Message);
            }
        }
        else
        {
            DataTable dt = MasterMassage("Status", "false", "Message", "Mobile Number,UserName & Password Is required.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    protected string GetIPAddress()
    {
        String strHostName = string.Empty;
        // Getting Ip address of local machine...
        // First get the host name of local machine.
        strHostName = Dns.GetHostName();
        Console.WriteLine("Local Machine's Host Name: " + strHostName);
        // Then using host name, get the IP address list..
        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        return addr[1].ToString();
    }

    public DataTable MasterMassage(string Variablename, string values, string Message, string values1)
    {
        DataTable tb = new DataTable();
        DataRow dr;
        tb.Columns.Add(Variablename, typeof(string));
        tb.Columns.Add(Message, typeof(string));
        dr = tb.NewRow();
        dr[Variablename] = values;
        dr[Message] = values1;
        tb.Rows.Add(dr);
        return tb;

    }


    public void SendSMS(string MobileNo, string Message)
    {
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        WebClient client = new WebClient();
        string baseurl = "http://198.24.149.4/API/pushsms.aspx?loginID=ghartak&password=4154fdf&mobile=" + mobile + "&text=" + Message + "&senderid=GHARTK&route_id=2&Unicode=0";

        Stream data = client.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
    }

}