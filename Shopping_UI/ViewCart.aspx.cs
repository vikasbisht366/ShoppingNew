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

public partial class Cart_ViewCart : System.Web.UI.Page
{
    clsCart objcart = new clsCart();
    DataTable dt;
    Cart _objCart;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustomerID"] == null)
        {
            Response.Redirect("LoginCart.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                bindShoppingCart();
            }
        }
    }
    private void bindShoppingCart()
    {
        DataTable dt = new DataTable();
        dt = objcart.GetCartMaster(Session["CustomerID"].ToString());
        rep_cart.DataSource = dt;
        rep_cart.DataBind();

    }

    protected void rep_cart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            Int32 cid = Convert.ToInt32(e.CommandArgument);
            DataTable dt = objcart.DeleteItemfromCartMaster(cid, Session["CustomerID"].ToString());
            bindShoppingCart();
        }

        if (e.CommandName == "update")
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hf = (HiddenField)e.Item.FindControl("hidden_cartid");
                string hiddenCart = hf.Value;
                HiddenField cusid = (HiddenField)e.Item.FindControl("Hidden_CustomerID");
                string CustomerID = cusid.Value;
                TextBox hr = (TextBox)e.Item.FindControl("txt_Qty");
                string Quantity = hr.Text;
                HiddenField hs = (HiddenField)e.Item.FindControl("Hidden_ProductID");
                string ProductID = hs.Value;
                objcart.UpdateCartProductQuentity(Convert.ToInt32(hiddenCart), CustomerID.ToString(), ProductID.ToString(), Quantity.ToString());
                bindShoppingCart();
            }
        }
    }

}