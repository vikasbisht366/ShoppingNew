using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Newtonsoft.Json;
using System.Net;

public partial class api_UpdateAPI : System.Web.UI.Page
{
    Cls_DataAccess objdataaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"].ToString() == "AppUpdate")
            {
                dt = UpdateApp();
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "New Version Not Found.");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Invalid Type.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }

        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type can't be Null.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }

    }

    public DataTable UpdateApp()
    {
        string query = "select * from tbl_UpdateApp";
        DataTable dtreturn = objdataaccess.GetDatatable(query);
        return dtreturn;
      
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