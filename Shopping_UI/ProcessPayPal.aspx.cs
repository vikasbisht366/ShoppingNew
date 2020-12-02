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

public partial class ProcessPayPal : System.Web.UI.Page
{
    clsOrder objclsOrder = new clsOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["status"] != null))
        {
            //--transaction successful
            if (Request.QueryString["status"].ToString() == "ok")
            {
                mvMain.SetActiveView(vwThanks);
                lblOrderNo.Text = Request.QueryString["oid"].ToString();
                UpdateOrder("Complete", Convert.ToInt32(Request.QueryString["oid"].ToString()));
                Session.Abandon();
            }
            else if (Request.QueryString["status"].ToString() == "fail")
            {
                UpdateOrder("Failed", Convert.ToInt32(Request.QueryString["oid"].ToString()));
                mvMain.SetActiveView(vwMsg);
                Session.Abandon();
            }
        }
       
    }

    protected void UpdateOrder(string status, int intOrderId)
    {
        try
        {
            Int32 i = 0;
           // i = objclsOrder.AddEditOrder(intOrderId, 0, status, false, "", 0, "");
        }
        catch
        {
        }
    }
}
