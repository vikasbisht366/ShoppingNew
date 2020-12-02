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
using System.Net;
using System.Net.Mail;
using BLL;
public partial class Front : System.Web.UI.MasterPage
{
    clsCategory objCategory = new clsCategory();
    clsSubCategory objSubCategory = new clsSubCategory();
    clsExtra objExtra = new clsExtra();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillCategory();

        }
        try
        {
            if (Session["TotalItem"] != null || Session["TotalItem"] != "")
            {
                lblTotalItem.Text = Session["TotalItem"].ToString();
            }
            else
            {
                lblTotalItem.Text = "0";
            }
        }
        catch
        {
            lblTotalItem.Text = "0";
        }
        if (!Page.IsPostBack)
        {
            getExtra();
            fillSubCategory();
            // get page
            string pageName = Request.Url.ToString().ToLower();
            int pos = pageName.LastIndexOf("/");
            pageName = pageName.Substring(pos + 1);

            switch (pageName)
            {
                case "demo.aspx":
                    LeftMenuHalf1.Visible = false;
                    LeftMenuFull1.Visible = true;
                    break;
                case "default.aspx?id=1":
                    LeftMenuHalf1.Visible = false;
                    LeftMenuFull1.Visible = true;
                    break;
                case "staticdata.aspx?id=11":
                    LeftMenuHalf1.Visible = false;
                    LeftMenuFull1.Visible = true;
                    break;
                case "staticdata.aspx?id=6":
                    LeftMenuHalf1.Visible = false;
                    LeftMenuFull1.Visible = true;
                    break;


            }
            if (Request.QueryString["search"] != null)
            {
                LeftMenuHalf1.Visible = true;
                LeftMenuFull1.Visible = false;
            }





        }
    }




    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string txt = txtKeyword.Text;
        Response.Redirect("Product.aspx?search=" + txt);
    }
  
    private void fillSubCategory()
    {
        clsSubCategory objSubCategory = new clsSubCategory();
        DataTable dt = new DataTable();
        dt = objSubCategory.GetSubCategory(0);
        ddlSubCategory.DataSource = dt;
        ddlSubCategory.DataValueField = "SubCategoryID";
        ddlSubCategory.DataTextField = "Title";
        ddlSubCategory.DataBind();
        ddlSubCategory.Items.Insert(0, new ListItem("Select SubCategory", "0"));
    }

    private void getExtra()
    {
        dt = objExtra.GetExtra(1);

        lblPhoneNo.Text = Convert.ToString(dt.Rows[0]["Number"]);
       // litTopLine.Text = Convert.ToString(dt.Rows[0]["TopLine"]);
        //litSearchEx.Text = Convert.ToString(dt.Rows[0]["SearchExample"]);
       
        repSocialLink.DataSource = dt;
        repSocialLink.DataBind();

        repLogo.DataSource = dt;
        repLogo.DataBind();

        repFooter.DataSource = dt;
        repFooter.DataBind();
    }

    private void FillCategory()
    {
        dt = objCategory.GetCategory(0);
        repCategory.DataSource = dt;
        repCategory.DataBind();
    }
   
}
