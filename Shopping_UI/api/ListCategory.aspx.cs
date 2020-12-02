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

public partial class api_ListCategory : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();

    int CatID;

    public void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (Request.QueryString["Type"] != "")
        {
            CatID = Convert.ToInt32(Request.QueryString["CategoryID"]);


            if (Request.QueryString["Type"].ToString() == "Category")
            {
                dt = GetCategory(CatID);
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Category Not found");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Invalid Request");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public DataTable GetCategory(int CatID)
    {
        if (CatID != 0)
        {
            string query = "select CategoryID,Title as CategoryName,('http://gartak.codunite.com/images/Category/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Category/medium/'+ImageUrl) as ImageURl ,'true' as Status,'Success' as Message from tblCategory where CategoryID=" + CatID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else
        {
            string query = "select CategoryID,Title as CategoryName,('http://gartak.codunite.com/images/Category/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Category/medium/'+ImageUrl) as ImageURl ,'true' as Status,'Success' as Message from tblCategory ";
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
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