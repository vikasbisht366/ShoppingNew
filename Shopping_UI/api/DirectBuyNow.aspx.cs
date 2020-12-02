using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using BLL;
using System.Net;
using System.Data;
using System.IO;

public partial class api_DirectBuyNow : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    clsOrder objorder = new clsOrder();
    clsOrderDetail objorderdetails = new clsOrderDetail();
    clsProduct objproduct = new clsProduct();
    int Cusid;
    string DelivaryDate;
    string productid;
    string Amount;
    string quantity;
    string orderid;
    string query;
    string address;
    string name = "";
    string mobile = "";
    string Country = "";
    string state = "";
    string city = "";
    string zip = "";
    string landmark = "";
    string locality = "";
    string Alternatemobileno = "";
    int cityid = 0;
    string deliverycharge = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Random randomnumber = new Random();
        orderid = randomnumber.Next(10000000, 99999999).ToString();

        if (Request.QueryString["Type"] != null)
        {
            Cusid = Convert.ToInt32(Request.QueryString["CustomerID"]);
            productid = Request.QueryString["ProductID"];
            quantity = Request.QueryString["Quantity"];
            Amount = Request.QueryString["Amount"];
            DelivaryDate = Request.QueryString["DelivaryDate"];
            cityid = Convert.ToInt32(Request.QueryString["CityID"]);
            deliverycharge = Request.QueryString["deliverycharge"].ToString();

            #region update profile
            if (Request.QueryString["Type"].ToString() == "BuyNow")
            {
                AddOrder();
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

    public void AddOrder()
    {
        if (cityid != 0 && Cusid != 0 && orderid != "" && orderid != null && productid != "" && productid != null && quantity != "" && quantity != null && Amount != "" && Amount != null && deliverycharge != "")
        {
            #region address
            DataTable dtaddress = objaccess.GetDatatable("Select * from tblAddressMaster where Customer_ID=" + Cusid + " and Isactive='true' ");
            if (dtaddress.Rows.Count > 0)
            {
                name = dtaddress.Rows[0]["Name"].ToString();
                mobile = dtaddress.Rows[0]["Mobile_No"].ToString();
                address = dtaddress.Rows[0]["Address"].ToString();
                Country = dtaddress.Rows[0]["Country"].ToString();
                state = dtaddress.Rows[0]["State"].ToString();
                city = dtaddress.Rows[0]["City"].ToString();
                zip = dtaddress.Rows[0]["Zip"].ToString();
                landmark = dtaddress.Rows[0]["Landmark"].ToString();
                locality = dtaddress.Rows[0]["Locality"].ToString();
                Alternatemobileno = dtaddress.Rows[0]["Alternate_MobileNo"].ToString();
            }
            #endregion
            DataTable dtproduct = objproduct.GetProduct(Convert.ToInt32(productid));
            if (dtaddress.Rows.Count > 0)
            {
                string productname = dtproduct.Rows[0]["title"].ToString();
                string weight = dtproduct.Rows[0]["weight"].ToString();
                decimal price = Convert.ToDecimal(dtproduct.Rows[0]["Price"]);
                decimal Discount = Convert.ToDecimal(dtproduct.Rows[0]["Discount"]);
                decimal Afterdiscount = Convert.ToDecimal(dtproduct.Rows[0]["AfterDiscount"]);
                decimal taxrate = Convert.ToDecimal(dtproduct.Rows[0]["TaxRate"]);
                decimal totalamount = Convert.ToDecimal(dtproduct.Rows[0]["Total_Amount"]);
                string DeliveryCharge = dtproduct.Rows[0]["DeliveryCharge"].ToString();
                string productImage = dtproduct.Rows[0]["ImageUrl"].ToString();

                int orderID = objorder.AddEditOrder(0, Cusid, "Pending", Convert.ToBoolean(0), "Cash On Devilary", cityid, deliverycharge, orderid, Amount, DelivaryDate, name, mobile, address, Country, state, city, zip, locality, landmark, Alternatemobileno);
                if (orderID > 0)
                {
                    int OrderID = objaccess.ExecuteIntScalar("select ID From tblorder Where OrderID=" + orderid + " ");

                    string sourcePath = @"C:\inetpub\wwwroot\gartak.codunite.com\images\Product\actual\" + productImage;
                    string destinationPath = @"C:\inetpub\wwwroot\gartak.codunite.com\images\PurchaseProductImage\" + productImage;
                    File.Copy(sourcePath, destinationPath, true);

                    objorderdetails.AddEditOrderDetail(0, Cusid, Convert.ToInt32(productid), OrderID, Convert.ToInt32(quantity), Amount, DelivaryDate, orderid,
                        productname, weight, price, Discount, Afterdiscount, taxrate, totalamount, DeliveryCharge, productImage);

                    dt = MasterMassage("Status", "true", "Message", "Thank you for Your Order Your Order Successfully Placed.");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Some Issue With Add Order.");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Some Issue With Product.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "CustomerID, ProductID, Amount,Delivery Charge & Quantity Is required");
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