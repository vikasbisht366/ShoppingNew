using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;


public partial class OrderDetails : System.Web.UI.Page
{
    clsOrderDetail objOrderDetail = new clsOrderDetail();
    DataTable dt = new DataTable();
    Cls_DataAccess objdataaccess = new Cls_DataAccess();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["odid"] != null)
            {
                FillData(Convert.ToInt32(Request.QueryString["odid"]));
            }
        }
    }

    private void FillData(int OrderID)
    {

        dt = objOrderDetail.GetOrderDetailByOrderID(OrderID);
      //  dt = objdataaccess.GetDatatable("select * from tblOrderDetail where CustomerID=" + Session["CustomerID"] + " and ID=" + Request.QueryString["odid"]);

        if (dt.Rows.Count > 0)
        {
            rep_orderdetails.DataSource = dt;
            rep_orderdetails.DataBind();

          

        }
        else
        {
            Page.RegisterStartupScript("Msg1", "<script>alert('There are no Product in your order.Please To add a product to your cart');</script>");
        }
    }
}