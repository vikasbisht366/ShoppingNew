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

public partial class api_SubcategoryAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    int CatID=0;
    int SubcatID=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        CatID = Convert.ToInt32(Request.QueryString["CategoryID"]);
        SubcatID = Convert.ToInt32(Request.QueryString["SubCategoryID"]);

        DataTable dt = new DataTable();
        if (Request.QueryString["Type"] != "")
        {

            if (Request.QueryString["Type"].ToString() == "SubCategory")
            {
                dt = GetSubCategory(CatID, SubcatID);
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Sub Category Not found");
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

    public DataTable GetSubCategory(int Catid, int SubcatID)
    {
        if (CatID != 0 && SubcatID == 0)
        {
            string query = "select SubCategoryID,Title as SubCategoryName,CategoryID,('http://gartak.codunite.com/images/SubCategory/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/SubCategory/medium/'+ImageUrl) as ImageURl ,'true' as Status,'Success' as Message from tblSubCategory where CategoryID=" + CatID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else if (CatID == 0 && SubcatID != 0)
        {
            string query = "select SubCategoryID,Title as SubCategoryName,CategoryID,('http://gartak.codunite.com/images/SubCategory/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/SubCategory/medium/'+ImageUrl) as ImageURl ,'true' as Status,'Success' as Message from tblSubCategory  where SubCategoryID=" + SubcatID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else if (CatID != 0 && SubcatID != 0)
        {
            string query = "select SubCategoryID,Title as SubCategoryName,CategoryID,('http://gartak.codunite.com/images/SubCategory/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/SubCategory/medium/'+ImageUrl) as ImageURl ,'true' as Status,'Success' as Message from tblSubCategory where CategoryID=" + CatID + " and SubCategoryID=" + SubcatID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else
        {
            string query = "select SubCategoryID,Title as SubCategoryName,CategoryID,('http://gartak.codunite.com/images/SubCategory/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/SubCategory/medium/'+ImageUrl) as ImageURl ,'true' as Status,'Success' as Message from tblSubCategory";
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