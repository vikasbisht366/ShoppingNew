using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class NetworkMaster : System.Web.UI.Page
{
    Cls_DataAccess objdataaccess = new Cls_DataAccess();
    clsCustomer objcustomer = new clsCustomer();
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
                network();
            }
        }
    }
    public void network()
    {
        DataTable dt = objdataaccess.GetDatatable("Select * from tbl_WalletBalance where CID=" + Session["CustomerID"].ToString());
        if (dt.Rows.Count > 0)
        {
            lblwalletbonus.Text = "0";
            lblbonuspoint.Text = dt.Rows[0]["Balance"].ToString();
        }
        dt = objcustomer.GetCustomer(Convert.ToInt32(Session["CustomerID"]));
        if (dt.Rows.Count > 0)
        {
            Session["memberid"] = dt.Rows[0]["memberid"].ToString();
            dt = objcustomer.getnetwork(Session["memberid"].ToString());
            rep_cart.DataSource = dt;
            rep_cart.DataBind();
        }
    }

    protected void rep_cart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Summary")
        {
            Int32 cusid = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("MemberSummary.aspx?id=" + cusid);
        }

    }

}