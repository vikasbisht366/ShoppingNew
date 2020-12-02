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
using System.Drawing;
using BLL;

public partial class Product : System.Web.UI.Page
{


    private int currentPage;
    private int firstIndex;
    private int lastIndex;
    Cart _objCart = new Cart();
    string s1, s2;
    PagedDataSource _PagedDataSource = new PagedDataSource();

    clsProduct objProduct = new clsProduct();
    clsCategory objCategory = new clsCategory();
    clsSubCategory objSubCategory = new clsSubCategory();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null || Session["cid"] != null)
            {
                //if (Request.QueryString["id"] != null)
                //    bindGallery(Convert.ToInt32(Request.QueryString["id"]));
                //else if (Session["cid"] != null)
                //    bindGallery(Convert.ToInt32(Session["cid"]));
            }
            else
            {
                ltrDescription.Text = "";
                bindProduct();
            }
        }
    }

    private void bindProduct()
    {

        if (Request.QueryString["fid"] != null)
        {
            Label1.Text = "Featured";
            dt = objProduct.GetProductFeatured(0);
        }
        else if (Request.QueryString["pid"] != null)
        {
            Label1.Text = "Popular";
            dt = objProduct.GetProductPopular(0);
        }
        else if (Request.QueryString["nid"] != null)
        {
            Label1.Text = "New";
            dt = objProduct.GetProductLatest(0);
        }
        else if (Request.QueryString["sid"] != null)
        {
            Label1.Text = "Search";
            dt = objProduct.GetProduct(Convert.ToInt32(Request.QueryString["sid"]));

        }
        else if (Request.QueryString["scid"] != null)
        {
            // Label1.Text = Convert.ToString(Request.QueryString["title"]);
            dt = objProduct.GetProductBySubCategoryID(Convert.ToInt32(Request.QueryString["scid"]), true);

            DataTable dt2 = new DataTable();
            dt2 = objSubCategory.GetSubCategory(Convert.ToInt32(Request.QueryString["scid"]));
            Label1.Text = Convert.ToString(dt2.Rows[0]["Title"]);
            ltrDescription.Text = Convert.ToString(dt2.Rows[0]["Description"]);
            if (dt2.Rows.Count > 0)
            {
                ((HtmlTitle)Master.FindControl("_metaTitle")).Text = dt2.Rows[0]["MetaTitle"].ToString();
                ((HtmlMeta)Master.FindControl("_metaKeywords")).Attributes.Add("Content", dt2.Rows[0]["MetaKeyword"].ToString());
                ((HtmlMeta)Master.FindControl("_metaDescription")).Attributes.Add("Content", dt2.Rows[0]["MetaDescription"].ToString());
            }


        }
        else if (Request.QueryString["cid"] != null)
        {
            // Label1.Text = Convert.ToString(Request.QueryString["title"]);
            dt = objProduct.GetProductByCategoryID(Convert.ToInt32(Request.QueryString["cid"]));

            DataTable dt2 = new DataTable();
            dt2 = objCategory.GetCategory(Convert.ToInt32(Request.QueryString["cid"]));
            Label1.Text = Convert.ToString(dt2.Rows[0]["Title"]);
            ltrDescription.Text = Convert.ToString(dt2.Rows[0]["Description"]);
            if (dt2.Rows.Count > 0)
            {
                ((HtmlTitle)Master.FindControl("_metaTitle")).Text = dt2.Rows[0]["MetaTitle"].ToString();
                ((HtmlMeta)Master.FindControl("_metaKeywords")).Attributes.Add("Content", dt2.Rows[0]["MetaKeyword"].ToString());
                ((HtmlMeta)Master.FindControl("_metaDescription")).Attributes.Add("Content", dt2.Rows[0]["MetaDescription"].ToString());
            }


        }
        else if (Request.QueryString["search"] != null)
        {
            Label1.Text = Convert.ToString(Request.QueryString["search"]);
            dt = objProduct.GetProductByProductName((Request.QueryString["search"].ToString()));
        }
        else
        {
            Label1.Text = "Popular";
            dt = objProduct.GetProductPopular(0);
        }


        if (dt.Rows.Count > 0)
        {
            _PagedDataSource.DataSource = dt.DefaultView;
            _PagedDataSource.AllowPaging = true;
            _PagedDataSource.PageSize = 8;
            if (currentPage >= 0)
            {
                _PagedDataSource.CurrentPageIndex = currentPage;
                ViewState["TotalPages"] = _PagedDataSource.PageCount;
                this.btn_first.Enabled = !_PagedDataSource.IsFirstPage;
                this.btn_last.Enabled = !_PagedDataSource.IsFirstPage;
                this.btn_next.Enabled = !_PagedDataSource.IsLastPage;
                this.btn_last.Enabled = !_PagedDataSource.IsLastPage;

                repProducts.DataSource = _PagedDataSource;
                repProducts.DataBind();
                this.doPaging();
            }
        }


    }

    private void doPaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        firstIndex = currentPage - 5;
        if (currentPage > 5)
            lastIndex = currentPage + 5;
        else
            lastIndex = 10;
        if (lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            firstIndex = lastIndex - 10;
        }
        if (firstIndex < 0)
            firstIndex = 1;
        for (Int32 i = firstIndex; i < lastIndex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        this.dlpaging.DataSource = dt;
        this.dlpaging.DataBind();

    }

    protected void repProducts_ItemCommand(object source, DataListCommandEventArgs e)
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


    protected void dlpaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("btn_paging");
        if (lnkbtnPage.CommandArgument.ToString() == currentPage.ToString())
        {
            lnkbtnPage.Enabled = false;
            lnkbtnPage.Font.Bold = true;
            lnkbtnPage.ForeColor = System.Drawing.Color.Yellow;
            lnkbtnPage.Font.Size = FontUnit.Large;


            btn_firstt.Enabled = true;
            btn_firstt.Font.Bold = false;

            btn_firstt.Font.Size = FontUnit.Small;
            // lnkbtnPage.BackColor = System.Drawing.Color.Black;
        }

    }
    protected void dlpaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("Paging"))
        {
            currentPage = Convert.ToInt32(e.CommandArgument);
            bindProduct();

        }
    }
    protected void btn_next_Click(object sender, ImageClickEventArgs e)
    {
        currentPage += 1;

        bindProduct();
    }
    protected void btn_last_Click(object sender, ImageClickEventArgs e)
    {
        currentPage = Convert.ToInt32(ViewState["TotalPages"]) - 1;

        bindProduct();
    }
    protected void btn_prev_Click(object sender, ImageClickEventArgs e)
    {
        currentPage -= 1;

        bindProduct();
    }
    protected void btn_first_Click(object sender, ImageClickEventArgs e)
    {
        currentPage = 0;

        bindProduct();
    }


    protected void btn_firstt_Click(object sender, EventArgs e)
    {
        currentPage = 0;
        btn_firstt.Enabled = false;
        btn_firstt.Font.Bold = true;
        btn_firstt.ForeColor = System.Drawing.Color.Yellow;
        btn_firstt.Font.Size = FontUnit.Large;
        bindProduct();
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

}