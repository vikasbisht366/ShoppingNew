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


public partial class api_UpdateCustomerAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    int Cusid = '0';
    string mobile = "";
    string UserName = "";
    string email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            Cusid = Convert.ToInt32(Request.QueryString["CustomerID"]);
            UserName = Request.QueryString["UserName"];
            email = Request.QueryString["Email"];
            mobile = Request.QueryString["Mobile_No"];

            #region update profile
            if (Request.QueryString["Type"].ToString() == "UpdateProfile")
            {
                updateprofile();
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Invalid Type");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
            #endregion
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type is required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void updateprofile()
    {
        string ipaddress = GetIPAddress();
        string password = "", memberid = "", referral = "";
        if (Cusid != 0 && UserName != "" && email != "" && mobile != "" && UserName != null && email != null )
        {
            string query = "Exec proc_AddEditCustomerRegistration " + Cusid + ",'" + UserName + "','" + email + "','" + password + "','" + ipaddress + "','" + mobile + "','" + memberid + "','" + referral + "' ";
            DataTable dts = objaccess.GetDatatable(query);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dts, Newtonsoft.Json.Formatting.Indented));
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "CustomerID, User Name, Email and Mobile Number Is required");
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
}