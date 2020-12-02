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

public partial class MoneyTransfer : System.Web.UI.Page
{

    Cls_DataAccess objdataaccess = new Cls_DataAccess();
    clsCustomer objcustomer = new clsCustomer();
    clsCountry objcountry = new clsCountry();
    clsState objState = new clsState();
    clsCity objcity = new clsCity();
    common objcomman = new common();
    DataTable dt = new DataTable();


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
                Fill_Details();

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
        DataTable dtcustomer = objdataaccess.GetDatatable("Select * from tblcustomer where customerID=" + Session["CustomerID"].ToString());
        if (dtcustomer.Rows.Count > 0)
        {
            label_UserName.Text = dtcustomer.Rows[0]["UserName"].ToString();
            txt_MEMBERID.Text = dtcustomer.Rows[0]["memberid"].ToString();
        }
        DataTable dtamount = objdataaccess.GetDatatable("Select * from tbl_WalletBalance where CID=" + Session["CustomerID"].ToString());
        if (dtamount.Rows.Count > 0)
        {
            txt_DefaultAmount.Text = dtamount.Rows[0]["Balance"].ToString();
        }
    }

    protected void btn_accountsave_Click(object sender, EventArgs e)
    {
        dt = objcustomer.CustomerLogin(txt_MEMBERID.Text, txt_password.Text);
        if (dt.Rows.Count > 0)
        {
            if (txt_MEMBERID.Text != "" && txt_Amount.Text != "" && txt_narration.Text != "")
            {
                DataTable dtcus = objdataaccess.GetDatatable("select * from tblCustomer where memberid='"+ txt_MEMBERID.Text +"' ");
                if(dtcus.Rows.Count >0)
                {
                    hidden_member.Value = dtcus.Rows[0]["CustomerID"].ToString();
                }
                DataTable dts = objdataaccess.GetDatatable("select * from tblCustomer where memberid='" + txt_transmember.Text + "' ");
                if (dts.Rows.Count > 0)
                {
                    hiddencustomer.Value = dts.Rows[0]["CustomerID"].ToString();
                }

                txt_narration.Text = "GiveCredit/" + txt_narration.Text;
                objdataaccess.ExecuteQuery("Exec Proc__WalletTransaction '" + hidden_member.Value + "','-" + txt_Amount.Text + "','Dr','" + txt_narration.Text + "'");

                objdataaccess.ExecuteQuery("Exec Proc__WalletTransaction '" + hiddencustomer.Value + "','" + txt_Amount.Text + "','Cr','" + txt_narration.Text + "'");

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Success| Successfully Credit   !');location.replace('MoneyTransfer.aspx');</script>");

            }
            else
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please Select & Enter Mondatory(*) Field !');</script>");
            }
        }

    }

  

}