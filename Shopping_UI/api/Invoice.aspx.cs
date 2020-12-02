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

public partial class api_Invoice : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    clsOrder objorder = new clsOrder();
    clsOrderDetail objorderdetails = new clsOrderDetail();
    string orderid;
    int customerid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            customerid = Convert.ToInt32(Request.QueryString["CustomerID"]);
            orderid = Request.QueryString["OrderID"];

            #region update profile
            if (Request.QueryString["Type"].ToString() == "Invoice")
            {
                if (Request.QueryString["CustomerID"].ToString() != null && Request.QueryString["CustomerID"].ToString() != "")
                {
                    if (Request.QueryString["OrderID"].ToString() != null && Request.QueryString["OrderID"].ToString() != "")
                    {
                        dt = Invoice(customerid, orderid);
                        if (dt.Rows.Count > 0)
                        {
                            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                        }
                        else
                        {
                            dt = MasterMassage("Status", "false", "Message", "Invalid Order Number");
                            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                        }
                    }
                    else
                    {
                        dt = MasterMassage("Status", "false", "Message", "OrderID cant be null or blank");
                        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                    }
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "CustomerID cant be null or blank");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
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

    public DataTable Invoice(int cutomerid, string orderid)
    {
        string query = @"select tblproduct.title,tblcustomer.UserName,tblcustomer.Mobile_No,
    tblorderdetail.QTY,tblorderdetail.Adddate,tblorderdetail.DevilaryAddress,((convert(decimal(18, 2), tblorderdetail.Amount)) * tblorderdetail.Qty) as Amount,tblorderdetail.Orderno
    from tblorderdetail
    inner join tblproduct on tblorderdetail.ProductID = tblproduct.ProductID
    inner join tblcustomer on tblorderdetail.CustomerID = tblcustomer.CustomerID where orderDetailID='" + orderid + "'  and tblorderdetail.CustomerID =" + cutomerid + "";
        DataTable dtinvoice = objaccess.GetDatatable(query);
        return dtinvoice;
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