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

public partial class api_ProductAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();

    int CatID = 0;
    int SubCatID = 0;
    int productID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (Request.QueryString["Type"] != "")
        {
            CatID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            SubCatID = Convert.ToInt32(Request.QueryString["SubCategoryID"]);
            productID = Convert.ToInt32(Request.QueryString["ProductID"]);

            if (Request.QueryString["Type"].ToString() == "Product")
            {
                dt = GetProduct(CatID, SubCatID, productID);
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Product Not found");
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

    public DataTable GetProduct(int CatID, int SubCatID, int productID)
    {
        if (CatID != 0 && SubCatID != 0 && productID != 0)
        {                                                                                    
            string query = "select ProductID,Title as ProductName,CategoryID,SubCategoryID,('http://gartak.codunite.com/images/Product/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Product/medium/'+ImageUrl) as ImageURl ,Description,price, Discount,AfterDiscount, Weight,Total_Amount,TaxRate,DeliveryCharge,'true' as Status,'Success' as Message from tblProduct where CategoryID=" + CatID + " and SubCategoryID=" + SubCatID + " and ProductID=" + productID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else if (CatID != 0 && SubCatID != 0 && productID == 0)
        {
            string query = "select ProductID,Title as ProductName,CategoryID,SubCategoryID,('http://gartak.codunite.com/images/Product/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Product/medium/'+ImageUrl) as ImageURl ,Description,price, Discount,AfterDiscount, Weight,Total_Amount,TaxRate,DeliveryCharge,'true' as Status,'Success' as Message from tblProduct where  CategoryID=" + CatID + " and  SubCategoryID=" + SubCatID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else if (CatID == 0 && SubCatID != 0 && productID == 0)
        {
            string query = "select ProductID,Title as ProductName,CategoryID,SubCategoryID,('http://gartak.codunite.com/images/Product/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Product/medium/'+ImageUrl) as ImageURl ,Description,price, Discount,AfterDiscount, Weight,Total_Amount,TaxRate,DeliveryCharge,'true' as Status,'Success' as Message from tblProduct where SubCategoryID=" + SubCatID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else if (CatID == 0 && SubCatID == 0 && productID != 0)
        {
            string query = "select ProductID,Title as ProductName,CategoryID,SubCategoryID,('http://gartak.codunite.com/images/Product/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Product/medium/'+ImageUrl) as ImageURl ,Description,price, Discount,AfterDiscount, Weight,Total_Amount,TaxRate,DeliveryCharge,'true' as Status,'Success' as Message from tblProduct where ProductID=" + productID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else if (CatID != 0 && SubCatID == 0 && productID == 0)
        {
            string query = "select ProductID,Title as ProductName,CategoryID,SubCategoryID,('http://gartak.codunite.com/images/Product/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Product/medium/'+ImageUrl) as ImageURl ,Description,price, Discount,AfterDiscount, Weight,Total_Amount,TaxRate,DeliveryCharge,'true' as Status,'Success' as Message from tblProduct where CategoryID=" + CatID;
            DataTable dtreturn = objaccess.GetDatatable(query);
            return dtreturn;
        }
        else
        {
            string query = "select ProductID,Title as ProductName,CategoryID,SubCategoryID,('http://gartak.codunite.com/images/Product/actual/'+ImageUrl) as actualImageURl,('http://gartak.codunite.com/images/Product/medium/'+ImageUrl) as ImageURl ,Description,price, Discount,AfterDiscount, Weight,Total_Amount,TaxRate,DeliveryCharge,'true' as Status,'Success' as Message from tblProduct ";
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