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

public partial class api_GetAddressAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    string CusID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            CusID = Request.QueryString["CustomerID"];

            if (Request.QueryString["Type"].ToString() == "GetAddress")
            {
                dt = GetAddress();
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "There Is No Address.");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
            else if(Request.QueryString["Type"].ToString() == "AddressForProfile")
            {
                dt = GetAddressgorprofile();
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "There Is No Address.");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "There Is Required.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type is required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public DataTable GetAddress()
    {
        if (CusID != "" && CusID != null)
        {
            string mobile = "select Customer_ID,Name,Mobile_No,Address+ ',' +City+ ' ' +State+ ',' +Country+ ',' +Zip+ ',' +Landmark+ ',' +Locality+ ',' +Alternate_MobileNo as Address,'true' as Status,'Success' as Message from tblAddressMaster where Customer_ID=" + CusID + " ";
            DataTable dtreturn = objaccess.GetDatatable(mobile);
            return dtreturn;
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "CustomerID Is Required");
            return dt;
        }
    }

    public DataTable GetAddressgorprofile()
    {
        if (CusID != "" && CusID != null)
        {
            string mobile = "select *,'true' as Status,'Success' as Message from tblAddressMaster where Customer_ID=" + CusID + " ";
            DataTable dtreturn = objaccess.GetDatatable(mobile);
            return dtreturn;
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "CustomerID Is Required");
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