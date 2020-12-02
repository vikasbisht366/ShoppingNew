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

public partial class ViewAll_Product : System.Web.UI.Page
{
    clsBrand objbrand = new clsBrand();
    clsProduct objProduct = new clsProduct();
    clsExtra objExtra = new clsExtra();
    DataTable dt = new DataTable();

    private int currentPage;
    private int firstIndex;
    private int lastIndex;
    Cart _objCart = new Cart();
    string s1, s2;
    PagedDataSource _PagedDataSource = new PagedDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hidden_BrandID.Text = Request.QueryString["id"];
            hiddenID.Value= Request.QueryString["id"];

            //   DisplayMetaTags();
            BindProduct();
        }
    }
    protected void DisplayMetaTags()
    {
        StoreProc _obj = new StoreProc();
        DataTable dt = new DataTable();
        dt = _obj.GetStaticPages(Convert.ToInt32(Request["id"]));
        if (dt.Rows.Count > 0)
        {
            ((HtmlTitle)Master.FindControl("_metaTitle")).Text = dt.Rows[0]["MetaTitle"].ToString();
            ((HtmlMeta)Master.FindControl("_metaKeywords")).Attributes.Add("Content", dt.Rows[0]["MetaKeywords"].ToString());
            ((HtmlMeta)Master.FindControl("_metaDescription")).Attributes.Add("Content", dt.Rows[0]["MetaDesc"].ToString());
        }
    }

    private void BindProduct()
    {
        DataTable dt = new DataTable();
        dt = objProduct.GetProductTop4Featured(0);
        // Repeater_Letest.DataSource = dt;
        //Repeater_Letest.DataBind();
        repFeaturedProducts.DataSource = dt;
        repFeaturedProducts.DataBind();

        DataTable dt1 = new DataTable();
        dt1 = objProduct.GetProductTop4Featured(0);
        Repeater_Top.DataSource = dt1;
        Repeater_Top.DataBind();

        DataTable dt2 = new DataTable();
        dt2 = objProduct.GetProductTop4Featured(0);
        Repeater_under_20K.DataSource = dt2;
        Repeater_under_20K.DataBind();

        DataTable dt3 = new DataTable();
        dt3 = objProduct.GetTop7Product(0);
        //.DataSource = dt1;
      //  Repeater_Top.DataBind();

        DataTable dt4 = new DataTable();
        dt4 = objProduct.GetProductTop4Featured(0);
        Repeater_Budget.DataSource = dt4;
        Repeater_Budget.DataBind();

        DataTable dt5 = new DataTable();
        dt5 = objbrand.GetBrandDetailsforBrandName(Convert.ToInt32(hiddenID.Value));
        Brand_Details_Repeater.DataSource = dt5;
        Brand_Details_Repeater.DataBind();
    }


    private string giveweight(string weight)
    {
        string productweight = null;
        if (weight.IndexOf(" ") != -1)
        {
            s1 = weight.Substring(0, weight.IndexOf(" ")).Trim();
            s2 = weight.Substring(weight.IndexOf(" "));



            string s1_space_remove = s2.Replace(" ", "").Trim().ToLower();
            // string s1_space_remove = s2.Remove(0, 1).ToLower();
            string s1_kg = s1_space_remove.StartsWith("k").ToString();
            string s1_gm = s1_space_remove.StartsWith("g").ToString();
            string s1_ml = s1_space_remove.StartsWith("m").ToString();
            string s1_ltr = s1_space_remove.StartsWith("l").ToString();

            if (s1_kg == "True")
            {
                productweight = s1;

            }
            else if (s1_ltr == "True")
            {
                productweight = s1;
            }
            else if (s1_ml == "True")
            {
                s1 = weight.Substring(0, weight.IndexOf(" "));
                double s11 = Convert.ToDouble(s1) / 1000;
                productweight = Convert.ToString(s11);
            }
            else if (s1_gm == "True")
            {
                s1 = weight.Substring(0, weight.IndexOf(" "));
                double s11 = Convert.ToDouble(s1) / 1000;
                productweight = Convert.ToString(s11);
            }
            return productweight;
        }
        else
        {
            productweight = s1;

        }
        return productweight;
    }

    protected void repletestproduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddToCart")
        {
            Int32 pid = Convert.ToInt32(e.CommandArgument);
            objProduct.UpdateProductHits(pid);
            string pname = ((Label)e.Item.FindControl("lblTitle")).Text;
            string pweight = ((Label)e.Item.FindControl("lblWeight")).Text;
            //here weight convert in kg 
            string weight = giveweight(pweight);
            string price = ((Label)e.Item.FindControl("lblPrice")).Text;
            string img = ((HtmlImage)e.Item.FindControl("pimg")).Src;
            img = img.Substring(img.LastIndexOf("/") + 1);

            if (Session["cart"] != null)
                _objCart = (Cart)Session["cart"];
            _objCart.Insert(pid, Convert.ToDouble(price), 1, pname, img, Convert.ToDouble(weight), pweight);
            Session["cart"] = _objCart;
            Session["TotalItem"] = "";
            Session["TotalItem"] = _objCart.Items.Count;
            Response.Redirect("ShoppingBag.aspx");
        }

    }
}