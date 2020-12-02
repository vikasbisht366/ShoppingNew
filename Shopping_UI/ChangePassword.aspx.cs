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


public partial class ChangePassword : System.Web.UI.Page
{

    Cls_DataAccess objdataaccess = new Cls_DataAccess();

    clsCustomer objCustomer = new clsCustomer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customerID"] == null || Session["customerID"] == "")
        {
            Response.Redirect("UserLogin.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Fill_Details();
            }
        }

    }

    private void Fill_Details()
    {
        DataTable dtcustomer = objdataaccess.GetDatatable("Select * from tblcustomer where customerID=" + Session["CustomerID"].ToString());
        if (dtcustomer.Rows.Count > 0)
        {
            label_UserName.Text = dtcustomer.Rows[0]["UserName"].ToString();
        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

    private void clear()
    {
        txtConfirmPassword.Text = "";
        txtCurrentPassword.Text = "";
        txtNewPassword.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dts = objdataaccess.GetDatatable("Select * from tblCustomer where CustomerID=" + Session["CustomerID"]);
        if (dts.Rows.Count > 0)
        {
            hidden_oldpass.Value = dts.Rows[0]["Password"].ToString();
            if (txtCurrentPassword.Text == hidden_oldpass.Value)
            {
                objCustomer.UpdateCustomerPassword(Convert.ToInt32(Session["customerID"].ToString()), txtCurrentPassword.Text, txtConfirmPassword.Text);
                Page.RegisterStartupScript("Msg1", "<script>alert('Password changed successfully !!!');</script>");
                clear();
            }
            else
            {
                Page.RegisterStartupScript("Msg1", "<script>alert('Current password is not valid !!!');</script>");
            }
        }
       
    }
}
