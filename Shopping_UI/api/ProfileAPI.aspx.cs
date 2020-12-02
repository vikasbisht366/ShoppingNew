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

public partial class api_ProfileAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    int Cusid ='0';
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

            #region getprofile
            if (Request.QueryString["Type"].ToString() == "GetProfile")
            {
                dt = getprofile();
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Invalid Customer");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
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

   

    public DataTable getprofile()
    {
        if (Cusid != 0)
        {
            string mobile = "select Convert(nvarchar,CustomerID) as CustomerID,UserName,Email,Mobile_No,AddDate,'true' as Status,'Success' as Message from tblCustomer where CustomerID=" + Cusid + " ";
            DataTable dtreturn = objaccess.GetDatatable(mobile);
            return dtreturn;
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Invalid Customer ID");
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