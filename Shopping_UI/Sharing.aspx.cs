using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Sharing : System.Web.UI.Page
{
    Cls_DataAccess Objaccess = new Cls_DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["SHAREID"] != "")
        {
            Objaccess.ExecuteIntScalar("Exec Proc__WalletTransaction '" + Request.QueryString["SHAREID"].ToString() + "','100.00','Cr','ADMIN SHARE REWARD'");
            Response.Redirect("Default.aspx");
        }
    }
}