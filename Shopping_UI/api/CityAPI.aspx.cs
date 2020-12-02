using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Newtonsoft.Json;

public partial class api_CityAPI : System.Web.UI.Page
{

    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.QueryString["Type"] != "")
        {
            if (Request.QueryString["Type"].ToString() == "City")
            {
                dt = getcity();
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                    HttpContext.Current.Response.End();
                }
            }
            else if (Request.QueryString["Type"].ToString() == "TermAndCondition")
            {
                dt = gettermAndCondition();
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                    HttpContext.Current.Response.End();
                }
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Type is Required");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                HttpContext.Current.Response.End();
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type is Required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            HttpContext.Current.Response.End();
        }
    }


    public DataTable getcity()
    {
        DataTable dtcity = objaccess.GetDatatable("select CityName,CityID from tblcity where isactive='true'");
        return dtcity;
    }
    public DataTable gettermAndCondition()
    {
        DataTable dtcity = objaccess.GetDatatable("select * from Tbl_termandCondition where isactive=1 and isdelete=0");
        return dtcity;
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