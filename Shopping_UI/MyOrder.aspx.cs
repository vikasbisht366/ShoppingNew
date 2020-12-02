using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Net;
using System.IO;

public partial class MyOrder : System.Web.UI.Page
{
    Cls_DataAccess objdataaccess = new Cls_DataAccess();
    clsCustomer objcustomer = new clsCustomer();
    clsOrder objOrder = new clsOrder();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["customerID"] = "1";
        if (Session["customerID"] == null || Session["customerID"] == "")
        {
            Response.Redirect("UserLogin.aspx");
        }
        else
        {
            if (!IsPostBack)
            {

                bindOrder();
            }
        }
    }


    private void bindOrder()
    {
        DataTable dtcustomer = objdataaccess.GetDatatable("Select * from tblcustomer where customerID=" + Session["CustomerID"].ToString());
        if (dtcustomer.Rows.Count > 0)
        {
            label_UserName.Text = dtcustomer.Rows[0]["UserName"].ToString();
        }

            dt = objOrder.GetOrderByCustomerID(Convert.ToInt32(Session["customerID"].ToString()));
        if (dt.Rows.Count > 0)
        {
            rep_orderdetails.DataSource = dt;
            rep_orderdetails.DataBind();
        }
        else
        {
            label_No_record_Found.Text = "Sorry You Have No Order ";
        }

    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}
