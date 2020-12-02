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


public partial class api_AddCartAPI : System.Web.UI.Page
{
    clsCart objcart = new clsCart();
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    int cartid;
    string cusid = "";
    string proid = "";
    int quantity;
    string TotalAmount = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            try
            {
                cusid = Request.QueryString["CustomerID"];
                proid = Request.QueryString["ProductID"];
                cartid = Convert.ToInt32(Request.QueryString["CartID"]);
                quantity = Convert.ToInt32(Request.QueryString["Quantity"]);
                TotalAmount = Request.QueryString["TotalAmountwithquantity"];

                #region Signup Api
                if (Request.QueryString["Type"].ToString() == "ADDCART")
                {
                    UserSignup();
                }
                else if (Request.QueryString["Type"].ToString() == "CARTQuantity")
                {
                    cartquantity();
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Invalid Type");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                #endregion
            }
            catch
            {
                dt = MasterMassage("Status", "false", "massage", "Mendatory fields are required.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Invalid Request");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }

    }

    public void UserSignup()
    {
        if (cusid != "" && cusid != null && proid != "" && proid != null && quantity != 0 && TotalAmount != "" && TotalAmount != null)
        {
            DataTable dtq = objaccess.GetDatatable("select * from CartMaster where CustomerID='" + cusid + "' and ProductID='" + proid + "' ");
            if (dtq.Rows.Count > 0)
            {
                int AddCartID = Convert.ToInt32(dtq.Rows[0]["AddCart_ID"]);

                if (AddCartID != 0)
                {
                    string query = "Exec proc_AddEditCartMaster '" + AddCartID + "','" + cusid + "','" + proid + "','" + quantity + "','" + TotalAmount + "' ";
                    DataTable dt = objaccess.GetDatatable(query);
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
            }
            else
            {
                string query = "Exec proc_AddEditCartMaster '" + cartid + "','" + cusid + "','" + proid + "','" + quantity + "','" + TotalAmount + "' ";
                DataTable dt = objaccess.GetDatatable(query);
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            DataTable dt = MasterMassage("Status", "false", "Message", "CustomerID,ProductID & Quantity Is Required.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void cartquantity()
    {
        if (cusid != "" && cusid != null)
        {
            string query = "select count(*) as Cartitem,sum(convert(numeric(18,2),totalAmount)) as CartAmount from CartMaster where CustomerID=" + cusid;
            DataTable dt = objaccess.GetDatatable(query);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "CustomerID Is Required.");
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

