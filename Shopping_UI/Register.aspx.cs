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

public partial class Register : System.Web.UI.Page
{
    clsCustomer objCustomer=new clsCustomer();
    clsCountry objCountry = new clsCountry();
    clsState objState = new clsState();
    clsCity objCity = new clsCity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddlCountry();
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (chbReadTerms.Checked == true)
        {

            if (this.txtCaptcha.Text == this.Session["randomStr"].ToString())
          
                            {

            try
            {
                Int32 intresult = 0;
               // intresult = objCustomer.AddEditCustomer(0, txtFirstName.Text, txtLastName.Text, txtEmail.Text.Trim(), txtContactNo1.Text, "", "", txtRePassword.Text, txtAddress.Text, ddlCountry.SelectedItem.Text, ddlState.SelectedItem.Text, ddlState.SelectedItem.Text, txtZip.Text, Convert.ToString(Request.UserHostAddress), "", Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCity.SelectedValue));
                if (intresult > 0)
                {
                    Page.RegisterStartupScript("Msg1", "<script>alert('Congratulation!!!, your account has been created successfully.');location.replace('Login.aspx');</script>");
                    clear();

                }
                else
                {
                    Page.RegisterStartupScript("Msg1", "<script>alert('Email ID already exists, please enter another. !!!');</script>");
                }
          
             
              

            }
            catch
            {
                Page.RegisterStartupScript("Msg1", "<script>alert('Email ID already exists, please enter another.');</script>");
            }

            return;
            }
            else
            {
                Page.RegisterStartupScript("Msg1", "<script>alert('Please enter valid CAPTCHA Text!!!');</script>");
                return;
            }
            this.txtCaptcha.Text = "";


        }
        else
        {
            Page.RegisterStartupScript("Msg1", "<script>alert('Please checked Terms and Conditions of Search World!!!');</script>");

        }
    }

    private void clear()
    {
        txtAddress.Text = "";
        txtCaptcha.Text = "";
        txtContactNo1.Text = "";
        txtEmail.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtPassword.Text = "";
        txtRePassword.Text = "";
        txtZip.Text = "";
      
        chbReadTerms.Checked = false;
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0;
       
    
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
        //DataTable dt = new DataTable();
        //dt = objState.GetStateByCountryID(CountryID,true);
        //ddlState.DataSource = dt;
        //ddlState.DataValueField = "StateID";
        //ddlState.DataTextField = "StateName";
        //ddlState.DataBind();
        //ddlState.Items.Insert(0, new ListItem("Select a State", "0"));

    }
    public void fillddlCity(int StateID)
    {
        DataTable dt = new DataTable();
       // dt = objCity.GetCity(StateID, true); GetCityByStateID
        ddlCity.DataSource = dt;
        ddlCity.DataValueField = "CityID";
        ddlCity.DataTextField = "CityName";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Select a City", "0"));

    }
    #endregion


    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlCity(Convert.ToInt32(ddlState.SelectedValue));
    }
}
