using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;


public partial class MemberSummary : System.Web.UI.Page
{
    cls_CustomerWallettranasation objcustomerwallet = new cls_CustomerWallettranasation();
    Cls_DataAccess objaccess = new Cls_DataAccess();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustomerID"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }
        else
        {
            if (Request.QueryString["id"] != null)
            {
                Summary(Request.QueryString["id"]);
            }
            else
            {
                summarymmember();
            }
        }
    }

    public void Summary(string id)
    {
        if (id != "")
        {
            DataTable dt = objcustomerwallet.GetwalletTransaction(Convert.ToInt32(id));
            rep_cart.DataSource = dt;
            rep_cart.DataBind();
        }
        
    }
    public void summarymmember()
    {
        DataTable dt = objcustomerwallet.GetwalletTransaction(Convert.ToInt32(Session["CustomerID"]));
        rep_cart.DataSource = dt;
        rep_cart.DataBind();

    }

    protected void rep_cart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {


    }
}