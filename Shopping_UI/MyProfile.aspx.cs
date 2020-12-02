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


public partial class MyProfile : System.Web.UI.Page
{
    clsCustomer objCustomer = new clsCustomer();
    clsCountry objCountry = new clsCountry();
    clsState objState = new clsState();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
        if (Session["customerID"] == null || Session["customerID"] == "")
        {
            Response.Redirect("default.aspx");
        }
        else
        {
            fillCustomer(Convert.ToInt32(Session["customerID"].ToString()));
        }
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        try
        {
            Int32 intresult = 0;
          //  intresult = objCustomer.AddEditCustomer(Convert.ToInt32(Session["customerID"].ToString()), txtFirstName.Text, txtLastName.Text, txtEmail.Text.Trim(), txtContactNo1.Text, "", "", txtRePassword.Text, txtAddress.Text, ddlCountry.SelectedItem.Text, ddlState.SelectedItem.Text, txtCity.Text, txtZip.Text, Convert.ToString(Request.UserHostAddress), "", Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), 0);
        
           // clear();
            Page.RegisterStartupScript("Msg1", "<script>alert('Your Profile updated successfully.');location.replace('Welcome.aspx');</script>");


        }
        catch
        {
            Page.RegisterStartupScript("Msg1", "<script>alert('Email ID already exists, please enter another.');</script>");
        }




    }

    private void clear()
    {
        txtAddress.Text = "";
        txtContactNo1.Text = "";
        txtEmail.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtPassword.Text = "";
        txtRePassword.Text = "";
        txtZip.Text = "";
        txtCity.Text = "";
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;

    }


    private void fillCustomer(int CustomerID)
    {
        DataTable dt = new DataTable();
        dt = objCustomer.GetCustomer(CustomerID);

        txtFirstName.Text = Convert.ToString(dt.Rows[0]["UserName"]);
     //   txtLastName.Text = Convert.ToString(dt.Rows[0]["LastName"]);
        txtEmail.Text = Convert.ToString(dt.Rows[0]["Email"]);
        txtContactNo1.Text = Convert.ToString(dt.Rows[0]["Mobile_No"]);
        txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
        txtPassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
        txtRePassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
        txtZip.Text = Convert.ToString(dt.Rows[0]["ZIP"]);
        txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
        fillddlCountry();
         ddlCountry.SelectedValue = Convert.ToString(dt.Rows[0]["CountryID"]);
         fillddlState(Convert.ToInt32(ddlCountry.SelectedValue));
        ddlState.SelectedValue = Convert.ToString(dt.Rows[0]["StateID"]);
       
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlState(Convert.ToInt32(ddlCountry.SelectedValue));
    }
    #region fill Country,State
    public void fillddlCountry()
    {
        DataTable dt = new DataTable();
        dt = objCountry.GetCountry();
        ddlCountry.DataSource = dt;
        ddlCountry.DataValueField = "CountryID";
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, new ListItem("Select a Country", "0"));

    }
    public void fillddlState(int CountryID)
    {
        DataTable dt = new DataTable();
        dt = objState.GetStateByCountryID(CountryID);
        ddlState.DataSource = dt;
        ddlState.DataValueField = "StateID";
        ddlState.DataTextField = "StateName";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("Select a State", "0"));

    }
    #endregion
}
