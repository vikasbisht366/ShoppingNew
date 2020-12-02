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

public partial class ShoppingBag : System.Web.UI.Page
{
    DataTable dt;
    Cart _objCart;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           bindShoppingCart();
        }
       
    }

    private void bindShoppingCart()
    {
        _objCart = new Cart();
        if (Session["cart"] != null)
        {
            _objCart = (Cart)Session["cart"];
            rep_cart.DataSource = _objCart.Items;
             Session["TotalItem"] = "";
             Session["TotalItem"] = _objCart.Items.Count;
            rep_cart.DataBind();
            lbl_total.Text = _objCart.Total.ToString();
            //lbl_totalweight.Text = _objCart.Totalweight.ToString();
            //if (Convert.ToDouble(lbl_totalweight.Text) > 20)
            //{
            //    Page.RegisterStartupScript("Msg1", "<script>alert('The maximum weight of a parcel is 20 KG.So Please empty some products at your cart');</script>");
            //}
            //else
            //{

            //}
        }
        else
        {
            Page.RegisterStartupScript("Msg1", "<script>alert('There are no products in your cart.Please To add a product to your cart');location.replace('Product.aspx');</script>");
        }
       // GeneralFunction.bindDataControl(rep_cart, (DataTable)Session["cart"]);
    }
    protected void rep_cart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        _objCart = new Cart();
        Int32 pid = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "delete")
        { 
            _objCart = (Cart)Session["cart"];
            _objCart.DeleteItem(pid);
            Response.Redirect(Request.Url.ToString());
             
        }
        else if (e.CommandName == "update")
        { 
            _objCart = (Cart)Session["cart"];
            string strqty = ((TextBox)e.Item.FindControl("txt_Qty")).Text;
            
            Int32 qty = 1;

            if (int.TryParse(strqty, out qty))
            {
                qty = Convert.ToInt32(strqty);
                if (qty <= 0)
                {
                    qty = 1;
                }
                _objCart.Update(pid, qty);
            }
        }
      
        rep_cart.DataSource = _objCart.Items;
        rep_cart.DataBind();
        lbl_total.Text = _objCart.Total.ToString();
        //lbl_totalweight.Text = _objCart.Totalweight.ToString();
        //if (Convert.ToDouble(lbl_totalweight.Text) > 20)
        //{
        //    Page.RegisterStartupScript("Msg1", "<script>alert('The maximum weight of a parcel is 20 KG.So Please empty some products at your cart');</script>");
        //}
        //else
        //{

        //}
        Session["cart"] = _objCart;
    }
  

    
}
