using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Net;

public partial class api_ForgotPasswordAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    string mobileNumber = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            mobileNumber = Request.QueryString["mobileno"];

            if (Request.QueryString["Type"].ToString() == "ForgotPassword")
            {
                Forgotpass();
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Invalid Type");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type is required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void Forgotpass()
    {
        if (mobileNumber != "" && mobileNumber != null)
        {
            if (mobileNumber.Length == 10)
            {
                DataTable dt = objaccess.GetDatatable("Select * from tblCustomer where Mobile_No='" + mobileNumber + "' ");
                if (dt.Rows.Count > 0)
                {
                    string password = dt.Rows[0]["Password"].ToString();

                    string Message = "Your Login Password is : " + password + " . ";
                    SendSMS(mobileNumber, Message);

                    dt = MasterMassage("Status", "true", "Message", "Your password send to your mobile number Successfully.");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Invalid Mobile Number .");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Invalid Mobile Number");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Mobile Number is required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void SendSMS(string mobileNumber, string Message)
    {
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        WebClient client = new WebClient();
        string baseurl = "http://198.24.149.4/API/pushsms.aspx?loginID=ghartak&password=4154fdf&mobile=" + mobileNumber + "&text=" + Message + "&senderid=GHARTK&route_id=2&Unicode=0";

        Stream data = client.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
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
}