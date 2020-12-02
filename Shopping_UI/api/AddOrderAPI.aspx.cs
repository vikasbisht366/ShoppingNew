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

public partial class api_AddOrderAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    clsOrder objorder = new clsOrder();
    clsOrderDetail objorderdetails = new clsOrderDetail();
    clsProduct objproduct = new clsProduct();

    int Cusid;
    string orderid;
    string query;
    string Amount;
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
    string deliverydate = "";
    int OrderdetailID;
    int orderID;
    int cityid = 0;
    string deliverycharge = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Random randomnumber = new Random();
        orderid = randomnumber.Next(10000000, 99999999).ToString();

        if (Request.QueryString["Type"] != null)
        {
            Cusid = Convert.ToInt32(Request.QueryString["CustomerID"]);
            deliverydate = Request.QueryString["deliverydate"];
            orderID = Convert.ToInt32(Request.QueryString["OrderCancleID"]);
            OrderdetailID = Convert.ToInt32(Request.QueryString["OrderdetailID"]);
            cityid = Convert.ToInt32(Request.QueryString["CityID"]);
            

            #region update profile
            if (Request.QueryString["Type"].ToString() == "Checkout")
            {
                deliverycharge = Request.QueryString["deliverycharge"].ToString();
                AddOrder();
            }
            else if (Request.QueryString["Type"].ToString() == "orderlist")
            {
                getorder();
            }
            else if (Request.QueryString["Type"].ToString() == "CancleOrder")
            {
                Removeorder();
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
        if (cityid != 0 && Cusid != 0 && orderid != "" && orderid != null && deliverycharge != "")
        {
            double amountMain = 0;
            DataTable dtvalue = objaccess.GetDatatable("select * from CartMaster where CustomerID=" + Cusid + " ");
            #region Addorder
            if (dtvalue.Rows.Count > 0)
            {
                DataTable dtaddress = objaccess.GetDatatable("Select * from tblAddressMaster where Customer_ID='" + Cusid + "' and Isactive='true' ");
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

                foreach (DataRow row in dtvalue.Rows)
                {
                    amountMain = amountMain + Convert.ToDouble(row["Totalamount"].ToString());
                }
                int orderID = objorder.AddEditOrder(0, Convert.ToInt32(Cusid), "Pending", Convert.ToBoolean(0), "Cash On Devilary", cityid, deliverycharge, orderid, amountMain.ToString(), System.DateTime.Now.ToString(), name, mobile, address, Country, state, city, zip, locality, landmark, Alternatemobileno);
                if (orderID > 0)
                {
                    foreach (DataRow row in dtvalue.Rows)
                    {
                        string cartID = row["AddCart_Id"].ToString();
                        string productID = row["ProductID"].ToString();
                        string qty = row["Quantity"].ToString();
                        string amount = row["Totalamount"].ToString();

                        DataTable dtproduct = objproduct.GetProduct(Convert.ToInt32(productID));
                        if (dtproduct.Rows.Count > 0)
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

                            string sourcePath = @"C:\inetpub\wwwroot\gartak.codunite.com\images\Product\actual\" + productImage;
                            string destinationPath = @"C:\inetpub\wwwroot\gartak.codunite.com\images\PurchaseProductImage\" + productImage;

                            //string sourcePath = @"C:\inetpub\wwwroot\gartak.codunite.com\images\Product\actual";
                            //string destinationPath = @"C:\inetpub\wwwroot\gartak.codunite.com\images\PurchaseProductImage";
                            File.Copy(sourcePath, destinationPath, true);

                            objorderdetails.AddEditOrderDetail(0, Cusid, Convert.ToInt32(productID), orderID, Convert.ToInt32(qty), amount, System.DateTime.Now.ToString("yyyyMMdd"),
                            orderid, productname, weight, price, Discount, Afterdiscount, taxrate, totalamount, DeliveryCharge, productImage);
                            objaccess.ExecuteQuery("delete from CartMaster where CustomerID=" + Cusid + " and AddCart_Id=" + cartID);
                            //return value
                        }
                        else
                        {
                            DataTable dts = MasterMassage("Status", "false", "Message", "Some issue with find Profuct.");
                            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dts, Newtonsoft.Json.Formatting.Indented));
                        }
                    }
                    string querygetDetails = "select Convert(nvarchar, OrderDetailID) as OrderDetailID, Convert(nvarchar, CustomerID) as CustomerID, Convert(nvarchar, ProductID) as ProductID,Convert(nvarchar, ID) as OrderID, DevilaryAddress,'true' as Status,'Success' as Message from tblOrderDetail where orderno=" + orderid + " ";
                    DataTable dt = objaccess.GetDatatable(querygetDetails);
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Your Cart Is Empty.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
            #endregion
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "CityId CustomerID and Delivery Charge Is required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void getorder()
    {
        string query = "Exec proc_GetAppOrderlist'" + Cusid + "' ";
        dt = objaccess.GetDatatable(query);
        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
    }

    public void Removeorder()
    {
        if (orderID != 0 && OrderdetailID != 0)
        {
            string query = "Exec Proc_CancleOrder'" + orderID + "','" + OrderdetailID + "' ";
            dt = objaccess.GetDatatable(query);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Canceled & OrderdetailID Is Required.");
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