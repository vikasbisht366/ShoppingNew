using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using BLL;
using Newtonsoft.Json;
using System.Net;

public partial class api_LoginAPI : System.Web.UI.Page
{
    string userid;
    string password;
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        userid = Request.QueryString["userid"];
        password = Request.QueryString["password"];

        if (Request.QueryString["Type"] != null)
        {
            try
            {
                #region LoginApi
                if (Request.QueryString["Type"].ToString() == "UserLogin")
                {
                    dt = UserLogin();
                    if (dt.Rows.Count > 0)
                    {
                        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                    }
                    else
                    {
                        dt = MasterMassage("Status", "false", "Message", "User Name Or Password is Invalid.");
                        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                    }
                }
                #endregion
            }
            catch
            {
                dt = MasterMassage("Status", "false", "massage", "Please Enter UserName & Password");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type Is Required.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }

    }
    public DataTable UserLogin()
    {
        if (userid != null && password != null && userid != "" && password != "")
        {
            string query = "select Convert(nvarchar,CustomerID) as CustomerID,Mobile_No as UserID,Password,'true' as Status,'Success' as Message from tblCustomer where Mobile_No=" + userid + " and password='" + password + "' ";
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "User ID And Password Is Required.");
            return dt;
        }
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