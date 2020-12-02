using System;
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

public partial class All_Product : System.Web.UI.Page
{
    clsBrand objbrand = new clsBrand();
    clsProduct objProduct = new clsProduct();
    clsExtra objExtra = new clsExtra();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HiddenfieldSubCategoey.Value = Request.QueryString["subid"];
           
            if (HiddenfieldSubCategoey.Value == Request.QueryString["subid"])
            {
                BindSubcatProduct();
            }
            HiddenField_Brand.Value = Request.QueryString["id"];
            if (HiddenField_Brand.Value == Request.QueryString["id"])
            {
                bindBrandProduct();
            }
        }

    }

    public void BindSubcatProduct()
    {
        DataTable dt = new DataTable();
        dt = objProduct.GetProductBySubCategoryIDForNavMenu(Convert.ToInt32(HiddenfieldSubCategoey.Value), Convert.ToBoolean(1));
        repFeaturedProducts.DataSource = dt;
        repFeaturedProducts.DataBind();
    }
    public void bindBrandProduct()
    {
        DataTable dt1 = new DataTable();
        dt1 = objProduct.GetProductByBrandIDForNavMenu(Convert.ToInt32(HiddenField_Brand.Value), Convert.ToBoolean(1));
        repFeaturedProducts.DataSource = dt1;
        repFeaturedProducts.DataBind();
    }
}