using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class CompleteOrder : System.Web.UI.Page
{
    clsAddress objaddress = new clsAddress();
    DataTable dt = new DataTable();
    Cls_DataAccess objdataaccess = new Cls_DataAccess();
    clsOrderDetail objorderdetail = new clsOrderDetail();
    clsOrder objorder = new clsOrder();

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
                Random random = new Random();
                hidden_orderid.Value = /*"ORD"+*/ random.Next(10000000, 99999999).ToString();
                GetAddress();
                SetAddressfordeveler();
            }
        }
    }

    protected void btn_AddAddress_Click(object sender, EventArgs e)
    {
        DataTable dt = objdataaccess.GetDatatable("select * from tblAddressMaster where Customer_ID=" + Session["CustomerID"] + " and Id='" + hidden_ID.Value + "' ");
        if (dt.Rows.Count > 0)
        {
            objaddress.AddEditAddressMaster(Convert.ToInt32(hidden_ID.Value), Session["CustomerID"].ToString(), txt_name.Text, txt_mobile.Text, txt_Address.Text, txt_country.Text, txt_state.Text, txt_city.Text, txt_Zip.Text, txt_Locality.Text, txt_landmark.Text, txt_alternatemobile.Text);
            clearAddress();
            GetAddress();
        }
        else
        {
            objaddress.AddEditAddressMaster(0, Session["CustomerID"].ToString(), txt_name.Text, txt_mobile.Text, txt_Address.Text, txt_country.Text, txt_state.Text, txt_city.Text, txt_Zip.Text, txt_Locality.Text, txt_landmark.Text, txt_alternatemobile.Text);
            clearAddress();
            GetAddress();
        }
        newaddress.Style.Add("display", "none");
        listaddress.Style.Add("display", "block");
    }

    public void clearAddress()
    {
        txt_name.Text = "";
        txt_mobile.Text = "";
        txt_Address.Text = "";
        txt_country.Text = "";
        txt_state.Text = "";
        txt_city.Text = "";
        txt_Zip.Text = "";
        txt_Locality.Text = "";
        txt_landmark.Text = "";
        txt_alternatemobile.Text = "";
    }
    public void GetAddress()
    {
        DataTable dt = new DataTable();
        dt = objaddress.GetAddress(Session["CustomerID"].ToString());
        Address_get_Repeater.DataSource = dt;
        Address_get_Repeater.DataBind();


    }
    public void SetAddressfordeveler()
    {

        DataTable dts = objdataaccess.GetDatatable("Select * from tblAddressMaster where Customer_ID=" + Session["CustomerID"] + " and IsActive='true' ");
        if (dts.Rows.Count > 0)
        {
            label_Name.Text = dts.Rows[0]["Name"].ToString();
            label_Mobile.Text = dts.Rows[0]["Mobile_No"].ToString();
            label_Address.Text = dts.Rows[0]["Address"].ToString();
            label_country.Text = dts.Rows[0]["Country"].ToString();
            label_State.Text = dts.Rows[0]["State"].ToString();
            label_City.Text = dts.Rows[0]["City"].ToString();
            label_Zip.Text = dts.Rows[0]["Zip"].ToString();
            label_locality.Text = dts.Rows[0]["Locality"].ToString();
            label_landmark.Text = dts.Rows[0]["Landmark"].ToString();
            label_landmark.Text = dts.Rows[0]["Alternate_MobileNo"].ToString();
            hidden_IDsaveaddress.Value = dts.Rows[0]["Id"].ToString();
        }
    }

    protected void Address_get_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "addressedit")
        {
            Int32 pid = Convert.ToInt32(e.CommandArgument);
            DataTable dt = objaddress.GetAddressForEdit(pid, Session["CustomerID"].ToString());
            if (dt.Rows.Count > 0)
            {
                hidden_ID.Value = dt.Rows[0]["Id"].ToString();
                hidden_Customerid.Value = dt.Rows[0]["Customer_ID"].ToString();
                txt_name.Text = dt.Rows[0]["Name"].ToString();
                txt_mobile.Text = dt.Rows[0]["Mobile_No"].ToString();
                txt_Address.Text = dt.Rows[0]["Address"].ToString();
                txt_country.Text = dt.Rows[0]["Country"].ToString();
                txt_state.Text = dt.Rows[0]["State"].ToString();
                txt_city.Text = dt.Rows[0]["City"].ToString();
                txt_Zip.Text = dt.Rows[0]["Zip"].ToString();
                txt_Locality.Text = dt.Rows[0]["Locality"].ToString();
                txt_landmark.Text = dt.Rows[0]["LandMark"].ToString();
                txt_alternatemobile.Text = dt.Rows[0]["Alternate_MobileNo"].ToString();
            }
        }

        if (e.CommandName == "addressdelete")
        {

            Int32 pid = Convert.ToInt32(e.CommandArgument);
            DataTable dt = objaddress.DeleteAddress(pid, Session["CustomerID"].ToString());
            GetAddress();

        }
        if (e.CommandName == "DevelerthisAddress")
        {
            Int32 aid = Convert.ToInt32(e.CommandArgument);
            DataTable dt = objaddress.UpdateAddressforDeliver(aid, Session["CustomerID"].ToString());
            SetAddressfordeveler();
            div_CahsOnDelivery.Style.Add("display", "block");
            div_address.Style.Add("display", "none");

        }
    }

    protected void btn_Cashondelevery_Click(object sender, EventArgs e)
    {

        int value = objdataaccess.ExecuteIntScalar("select count(*) from CartMaster where CustomerID=" + Session["CustomerID"]);

        for (int i = 1; i <= value; i++)
        {
            DataTable pro = objdataaccess.GetDatatable("select * from CartMaster where CustomerID=" + Session["CustomerID"]);
            if (pro.Rows.Count > 0)
            {
                Hidden_Cartid.Value = pro.Rows[0]["AddCart_Id"].ToString();
                hidden_productID.Value = pro.Rows[0]["ProductID"].ToString();
                hidden_Quantity.Value = pro.Rows[0]["Quantity"].ToString();

                int address = objdataaccess.ExecuteIntScalar("Select Id from tblAddressMaster where Customer_ID=" + Session["CustomerID"] + " and Isactive='true' ");

                // objorder.AddEditOrder( 0, Convert.ToInt32(Session["CustomerID"]), "Pending", Convert.ToBoolean(0), "Cash On Devilary",Convert.ToInt32(0), "",hidden_orderid.Value);
                //objorderdetail.AddEditOrderDetail(0, Convert.ToInt32(Session["CustomerID"]), Convert.ToInt32(hidden_productID.Value), Convert.ToInt32(hidden_orderid.Value), Convert.ToInt32(hidden_Quantity.Value), address.ToString());

                objdataaccess.ExecuteQuery("delete from CartMaster where CustomerID=" + Session["CustomerID"] + " and AddCart_Id=" + Hidden_Cartid.Value);
            }
        }

        Response.Redirect("OrderDetails.aspx?odid=" + hidden_orderid.Value);
    }

    protected void btn_AddNewAddress_Click(object sender, EventArgs e)
    {
        newaddress.Style.Add("display", "block");
        listaddress.Style.Add("display", "none");
    }

    #region CashOnDelivery Div
    protected void btn_ManageAddress_Click(object sender, EventArgs e)
    {
        div_CahsOnDelivery.Style.Add("display", "none");
        div_address.Style.Add("display", "block");
    }

    protected void btn_paypal_Click(object sender, EventArgs e)
    {
        div_CahsOnDelivery.Style.Add("display", "none");
        div_paypal.Style.Add("display", "block");
    }

    protected void btn_netBanking_Click(object sender, EventArgs e)
    {
        div_CahsOnDelivery.Style.Add("display", "none");
        div_Netbanking.Style.Add("display", "block");
    }

    protected void btn_Creditdebit_Click(object sender, EventArgs e)
    {
        div_CahsOnDelivery.Style.Add("display", "none");
        div_debitcredit.Style.Add("display", "block");
    }
    #endregion

    #region credit debit
    protected void btn_ManageAddres_Click(object sender, EventArgs e)
    {
        div_debitcredit.Style.Add("display", "none");
        div_address.Style.Add("display", "block");
    }
    protected void btn_CashOn_Click(object sender, EventArgs e)
    {
        div_debitcredit.Style.Add("display", "none");
        div_CahsOnDelivery.Style.Add("display", "block");
    }
    protected void btn_netbankingforcredit_Click(object sender, EventArgs e)
    {
        div_debitcredit.Style.Add("display", "none");
        div_Netbanking.Style.Add("display", "block");
    }
    protected void btn_Paypalforcredit_Click(object sender, EventArgs e)
    {
        div_debitcredit.Style.Add("display", "none");
        div_paypal.Style.Add("display", "block");
    }

    #endregion

    #region netbanking
    protected void btn_manageaddressfornet_Click(object sender, EventArgs e)
    {
        div_Netbanking.Style.Add("display", "none");
        div_address.Style.Add("display", "block");
    }

    protected void btn_creditfornet_Click(object sender, EventArgs e)
    {
        div_Netbanking.Style.Add("display", "none");
        div_debitcredit.Style.Add("display", "block");
    }

    protected void btn_paypalfornet_Click(object sender, EventArgs e)
    {
        div_Netbanking.Style.Add("display", "none");
        div_paypal.Style.Add("display", "block");
    }

    protected void btn_cashfornet_Click(object sender, EventArgs e)
    {
        div_Netbanking.Style.Add("display", "none");
        div_CahsOnDelivery.Style.Add("display", "block");
    }

    #endregion

    #region paypal
    protected void btn_addressforpay_Click(object sender, EventArgs e)
    {
        div_paypal.Style.Add("display", "none");
        div_address.Style.Add("display", "block");
    }

    protected void btn_cashforpay_Click(object sender, EventArgs e)
    {
        div_paypal.Style.Add("display", "none");
        div_CahsOnDelivery.Style.Add("display", "block");
    }

    protected void btn_creditforpay_Click(object sender, EventArgs e)
    {
        div_paypal.Style.Add("display", "none");
        div_debitcredit.Style.Add("display", "block");
    }

    protected void btn_netforpay_Click(object sender, EventArgs e)
    {
        div_paypal.Style.Add("display", "none");
        div_Netbanking.Style.Add("display", "block");
    }
    #endregion


}
