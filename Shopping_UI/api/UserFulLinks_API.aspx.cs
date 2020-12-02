using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Newtonsoft.Json;

public partial class api_UserFulLinks_API : System.Web.UI.Page
{

    Cls_DataAccess objaccess = new Cls_DataAccess();
    clsExtra objextra = new clsExtra();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (Request.QueryString["Type"] != null)
        {
            try
            {
                #region [GetExtra]
                if (Request.QueryString["Type"].ToString() == "GetExtra")
                {
                    getCartDetails();
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
                dt = MasterMassage("status", "false", "massage", "Somthing Went Else Please Try After Sometime.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Invalid Request");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void getCartDetails()
    {
        DataTable dts = new DataTable();
        dts = objextra.GetAllExtra(0);
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