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

public partial class Slider : System.Web.UI.Page
{
    clsPhotoGallery objPhotoGallery = new clsPhotoGallery();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = objPhotoGallery.GetPhotoGallery(0, 1);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}
