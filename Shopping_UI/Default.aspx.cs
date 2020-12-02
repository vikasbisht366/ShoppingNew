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

public partial class Default : System.Web.UI.Page
{
    clsBrand objbrand = new clsBrand();
    clsProduct objProduct = new clsProduct();
    clsExtra objExtra = new clsExtra();
    DataTable dt = new DataTable();
    Cls_DataAccess objaccess = new Cls_DataAccess();
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
            bindMarqueeLine();
            //  DisplayMetaTags();
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

            ((HtmlMeta)Master.FindControl("_metaKeywords")).Attributes.Add("Content", dt.Rows[0]["MetaKeywords"].ToString());
            ((HtmlMeta)Master.FindControl("_metaDescription")).Attributes.Add("Content", dt.Rows[0]["MetaDesc"].ToString());
        }
    }
    private void bindMarqueeLine()
    {
        dt = objExtra.GetExtra(1);

        litMarqueeText.Text = Convert.ToString(dt.Rows[0]["Extra2"]);

    }

    private void BindProduct()
    {
        DataTable dt = new DataTable();
        dt = objaccess.GetDatatable("select top 12 * from tblProduct order by ProductID desc");
        repFeaturedProducts.DataSource = dt;
        repFeaturedProducts.DataBind();
    }

    protected void repFeaturedProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
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
            Response.Redirect("ViewCart.aspx");
        }
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

    protected void Repeater_skirts_ItemCommand(object source, RepeaterCommandEventArgs e)
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
            Response.Redirect("ViewCart.aspx");
        }
    }

    protected void Repeater_jewellery_ItemCommand(object source, RepeaterCommandEventArgs e)
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
            Response.Redirect("ViewCart.aspx");
        }
    }

    protected void Repeater_sandals_ItemCommand(object source, RepeaterCommandEventArgs e)
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
            Response.Redirect("ViewCart.aspx");
        }
    }

    protected void Repeater_watches_ItemCommand(object source, RepeaterCommandEventArgs e)
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
            Response.Redirect("ViewCart.aspx");
        }
    }

}
