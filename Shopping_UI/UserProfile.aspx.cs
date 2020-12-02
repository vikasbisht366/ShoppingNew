using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Net;
using System.IO;

public partial class UserProfile : System.Web.UI.Page
{
    Cls_DataAccess objdataaccess = new Cls_DataAccess();
    clsCustomer objcustomer = new clsCustomer();
    clsCountry objcountry = new clsCountry();
    clsState objState = new clsState();
    clsCity objcity = new clsCity();
    common objcomman = new common();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustomerID"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                common.DropDownMasterBind((DropDownList)ddlcountry, objcountry.GetCountry(), "CountryName", "CountryID");
                common.DropDownMasterBind((DropDownList)ddlstate, objState.GetStateByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)), "StateName", "StateID");
                common.DropDownMasterBind((DropDownList)ddlcity, objcity.GetCityByStateID(Convert.ToInt32(ddlstate.SelectedValue)), "CityName", "CityID");

                Fill_Details();
                fillAccountDetails();
            }
        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

    private void Fill_Details()
    {
        //DataTable dt = objdataaccess.GetDatatable("Select * from tbl_WalletBalance where CID=" + Session["CustomerID"].ToString());
        //if (dt.Rows.Count > 0)
        //{
        //    lblwalletbonus.Text = "0";
        //    lblbonuspoint.Text = dt.Rows[0]["Balance"].ToString();
        //}
        DataTable dtcustomer = objdataaccess.GetDatatable("Select * from tblcustomer where customerID=" + Session["CustomerID"].ToString());
        if (dtcustomer.Rows.Count > 0)
        {
            txtCustomerName.Text = dtcustomer.Rows[0]["UserName"].ToString();
            txtMoblie.Text = dtcustomer.Rows[0]["Mobile_No"].ToString();
            txtEmail.Text = dtcustomer.Rows[0]["Email"].ToString();
            txtAddress.Text = dtcustomer.Rows[0]["Address"].ToString();
            txtmemberid.Text = dtcustomer.Rows[0]["memberid"].ToString();
            ddlcountry.SelectedValue = dtcustomer.Rows[0]["CountryID"].ToString();
            common.DropDownMasterBind((DropDownList)ddlstate, objState.GetStateByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)), "StateName", "StateID");
            ddlstate.SelectedValue = dtcustomer.Rows[0]["StateID"].ToString();
            common.DropDownMasterBind((DropDownList)ddlcity, objcity.GetCityByStateID(Convert.ToInt32(ddlstate.SelectedValue)), "CityName", "CityID");
            ddlcity.SelectedValue = dtcustomer.Rows[0]["CityID"].ToString();

            txtzip.Text = dtcustomer.Rows[0]["Zip"].ToString();
            txt_adddate.Text = dtcustomer.Rows[0]["AddDate"].ToString();
            label_UserName.Text = dtcustomer.Rows[0]["UserName"].ToString();
            hidden_Customerid.Value = dtcustomer.Rows[0]["CustomerID"].ToString();
            hidden_countryid.Value = dtcustomer.Rows[0]["CountryID"].ToString();

        }
    }

    private void fillAccountDetails()
    {
        DataTable dtcustomer = objdataaccess.GetDatatable("Select * from tbl_AccountDetails where CID=" + Session["CustomerID"].ToString());
        if (dtcustomer.Rows.Count > 0)
        {
            txt_Aadhar.Text = dtcustomer.Rows[0]["AadharCard"].ToString();
            txt_PanCard.Text = dtcustomer.Rows[0]["PanCard"].ToString();
            txt_BankAccount.Text = dtcustomer.Rows[0]["Account_No"].ToString();
            txt_ifsc.Text = dtcustomer.Rows[0]["IfscCode"].ToString();
            txt_branchName.Text = dtcustomer.Rows[0]["BranchName"].ToString();
            txt_branchAddress.Text = dtcustomer.Rows[0]["BranchAddress"].ToString();
        }
    }

    protected void btnSaveData_Click(object sender, EventArgs e)
    {
        string ipaddress = GetIPAddress();
        objcustomer.AddEditCustomer(Convert.ToInt32(hidden_Customerid.Value), txtCustomerName.Text, txtEmail.Text, txtMoblie.Text, "", "", txtAddress.Text, "", "", "", txtzip.Text, ipaddress, "", Convert.ToInt32(ddlcountry.SelectedValue), Convert.ToInt32(ddlstate.SelectedValue), Convert.ToInt32(ddlcity.SelectedValue));
        Fill_Details();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        common.DropDownMasterBind((DropDownList)ddlstate, objState.GetStateByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)), "StateName", "StateID");
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        common.DropDownMasterBind((DropDownList)ddlcity, objcity.GetCityByStateID(Convert.ToInt32(ddlstate.SelectedValue)), "CityName", "CityID");
    }

    protected string GetIPAddress()
    {
        String strHostName = string.Empty;
        // Getting Ip address of local machine...
        // First get the host name of local machine.
        strHostName = Dns.GetHostName();
        Console.WriteLine("Local Machine's Host Name: " + strHostName);
        // Then using host name, get the IP address list..
        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        return addr[1].ToString();
    }

    protected void btn_accountsave_Click(object sender, EventArgs e)
    {
        string ipaddress = GetIPAddress();
        DataTable dts = objdataaccess.GetDatatable("Select * from tbl_AccountDetails where CID=" + Session["CustomerID"]);
        if(dts.Rows.Count>0)
        {
            hidden_id.Value = dts.Rows[0]["ID"].ToString();
            objcustomer.AddEditAccountDetails(Convert.ToInt32(hidden_id.Value), Session["CustomerID"].ToString(), txt_Aadhar.Text, txt_PanCard.Text, txt_BankAccount.Text, txt_ifsc.Text, txt_branchName.Text, txt_branchAddress.Text, ipaddress);
            fillAccountDetails();
        }
        else
        {
            objcustomer.AddEditAccountDetails(0, Session["CustomerID"].ToString(), txt_Aadhar.Text, txt_PanCard.Text, txt_BankAccount.Text, txt_ifsc.Text, txt_branchName.Text, txt_branchAddress.Text, ipaddress);
            fillAccountDetails();
        }
        
    }

 
}