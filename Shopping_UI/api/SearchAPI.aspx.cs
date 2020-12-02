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


public partial class api_SearchAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    string searchitem;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            searchitem = Request.QueryString["item"];
            if (Request.QueryString["Type"].ToString() == "SearchItem")
            {
                UserSignup();
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Type SearchItem is Required.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type is Required.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void UserSignup()
    {
        if (searchitem != null)
        {
            string query = "exec proc_searchitems '"+ searchitem +"' ";
            DataTable dts = objaccess.GetDatatable(query);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dts, Newtonsoft.Json.Formatting.Indented));

            dt = MasterMassage("Status", "true", "Message", "success.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
        else
        {
            DataTable dt = MasterMassage("Status", "false", "Message", "Invalid Request.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
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