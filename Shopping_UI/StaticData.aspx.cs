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

public partial class StaticData : System.Web.UI.Page
{
   public string a = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            DisplayMetaTags();
        }
    }
  
  
    protected void DisplayMetaTags()
    {
        StoreProc _obj = new StoreProc();
        DataTable dt = new DataTable();
        dt = _obj.GetStaticPages(Convert.ToInt32(Request["id"]));
        if (dt.Rows.Count > 0)
        {
            litPageHeading.Text = Convert.ToString(dt.Rows[0]["PageTitle"]);
            litPageDesc.Text = Convert.ToString(dt.Rows[0]["pagedesc"]);
            a = litPageHeading.Text;
            ((HtmlTitle)Master.FindControl("_metaTitle")).Text = dt.Rows[0]["metatitle"].ToString();
            ((HtmlMeta)Master.FindControl("_metaKeywords")).Attributes.Add("Content", dt.Rows[0]["metakeywords"].ToString());
            ((HtmlMeta)Master.FindControl("_metaDescription")).Attributes.Add("Content", dt.Rows[0]["metadesc"].ToString());
        }
    }
   
}
