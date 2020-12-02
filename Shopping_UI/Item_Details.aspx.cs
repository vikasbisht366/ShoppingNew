using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;


public partial class Item_Details : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    clsProduct objProduct = new clsProduct();
    clsExtra objExtra = new clsExtra();
    DataTable dt = new DataTable();
    clsCart objcart = new clsCart();

    PagedDataSource _PagedDataSource = new PagedDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                BindProduct();
            }
            else if (Request.QueryString["proid"] != null)
            {
                BindProductbyproid();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    private void BindProductbyproid()
    {
        DataTable dt = new DataTable();
        dt = objProduct.GetProduct(Convert.ToInt32(Request.QueryString["proid"]));
        reponeitemdetails.DataSource = dt;
        reponeitemdetails.DataBind();

        dt = objaccess.GetDatatable("select * from tblProduct where ProductID='" + Request.QueryString["id"] + "' ");
        if (dt.Rows.Count > 0)
        {
            labelDescription.Text = dt.Rows[0]["Description"].ToString();
        }
    }

    private void BindProduct()
    {
        DataTable dt = new DataTable();
        dt = objProduct.GetProductOnItemDetails(Convert.ToInt32(Request.QueryString["id"]));
        reponeitemdetails.DataSource = dt;
        reponeitemdetails.DataBind();

        dt = objaccess.GetDatatable("select * from tblProduct where ProductID='" + Request.QueryString["id"] + "' ");
        if (dt.Rows.Count > 0)
        {
            labelDescription.Text = dt.Rows[0]["Description"].ToString();
        }
    }

    protected void reponeitemdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddToCart")
        {
            if (Session["CustomerID"] != null)
            {
                Int32 pid = Convert.ToInt32(e.CommandArgument);
                DataTable dt = objaccess.GetDatatable("select * from CartMaster where CustomerID=" + Session["CustomerID"].ToString() + " and ProductID='" + pid + "' ");
                if (dt.Rows.Count > 0)
                {
                    hidden_CartID.Value = dt.Rows[0]["AddCart_Id"].ToString();
                    hidden_Quantity.Value = dt.Rows[0]["Quantity"].ToString();
                    objcart.AddEditCartMaster(Convert.ToInt32(hidden_CartID.Value), Session["CustomerID"].ToString(), pid.ToString(), hidden_Quantity.Value);
                    Response.Redirect("ViewCart.aspx");
                }
                else
                {
                    objcart.AddEditCartMaster(0, Session["CustomerID"].ToString(), pid.ToString(), "1");
                    Response.Redirect("ViewCart.aspx");
                }

            }
            else
            {
                hidden_ProductID.Value = Request.QueryString["id"];
                Response.Redirect("LoginCart.aspx?id=" + hidden_ProductID.Value);
            }
        }
    }



}