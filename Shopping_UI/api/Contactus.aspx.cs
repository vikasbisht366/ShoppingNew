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


public partial class api_Contactus : System.Web.UI.Page
{

    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["Type"] != null)
        {
            try
            {
                #region Signup Api
                if (Request.QueryString["Type"].ToString() == "GetContactDetails")
                {
                    GetContactDetails();
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Invalid Type.");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
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
            dt = MasterMassage("Status", "false", "Message", "Type Can't be null");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }

    }

    public void GetContactDetails()
    {
        string query = "Select Convert(nvarchar,ID) as ID,Name,Mobile_No,Email,Addr from tbl_ContactUs where IsActive='true' ";
        DataTable dts = objaccess.GetDatatable(query);
        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dts, Newtonsoft.Json.Formatting.Indented));
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