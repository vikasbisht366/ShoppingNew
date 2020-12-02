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

public partial class News : System.Web.UI.Page
{
    clsEvent obj = new clsEvent();
    DataTable dt = new DataTable();
  
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            fillEvent();
        }

    }
    private void fillEvent()
    {
        dt = obj.GetEvent(0);
        if (dt.Rows.Count > 0)
        {
            rptAllEvents.DataSource = dt;
            rptAllEvents.DataBind();
        }
       

    }
   
   
}
