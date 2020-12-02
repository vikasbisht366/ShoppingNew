using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class IndexMaster : System.Web.UI.MasterPage
{
    clsCategory objCategory = new clsCategory();
    clsSubCategory objSubcat = new clsSubCategory();
    clsBrand objBrand = new clsBrand();
    clsProduct objProduct = new clsProduct();
    clsCustomer objaccess = new clsCustomer();
    DataTable dt = new DataTable();
    clsCustomerWalletAmount objwallet = new clsCustomerWalletAmount();
    Cls_DataAccess objdataaccess = new Cls_DataAccess();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customerID"] == null)
        {
            loginSignsup.Visible = true;
            withUsername.Visible = false;
            if (!IsPostBack)
            {
                FillCategory();
            }
        }
        else
        {
            loginSignsup.Visible = false;
            withUsername.Visible = true;
            if (!IsPostBack)
            {
                FillCategory();
                dt = objaccess.GetCustomer(Convert.ToInt32(Session["CustomerID"]));
                if (dt.Rows.Count > 0)
                {
                    Label_Name.Text = dt.Rows[0]["UserName"].ToString();
                    //Label_userName.Text = dt.Rows[0]["memberid"].ToString();

                }
                dt = objdataaccess.GetDatatable("Select * from tbl_WalletBalance where CID=" + Session["CustomerID"].ToString());
                if (dt.Rows.Count > 0)
                {
                    label_WalletAmount.Text = dt.Rows[0]["Balance"].ToString();
                }
            }
        }

    }
    private void FillCategory()
    {
        dt = objCategory.GetCategory(0);
        Category_Repeter.DataSource = dt;
        Category_Repeter.DataBind();
    }
 
    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataTable dt1 = new DataTable();
        HiddenField hf = (HiddenField)e.Item.FindControl("hidCategory");
        dt1 = objSubcat.GetSubCategoryByCategoryID(Convert.ToInt32(hf.Value), true);

        Repeater r1 = (Repeater)e.Item.FindControl("SubCategory_Repeater");
        r1.DataSource = dt1;
        r1.DataBind();

    }

    protected void SubCategory_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataTable dt2 = new DataTable();
        HiddenField hf = (HiddenField)e.Item.FindControl("hid_SubCategory");
        dt2 = objProduct.GetProductAllBySubCategoryID(Convert.ToInt32(hf.Value));

        Repeater r1 = (Repeater)e.Item.FindControl("product_Repeater");
        r1.DataSource = dt2;
        r1.DataBind();
    }

    protected void btn_logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}
