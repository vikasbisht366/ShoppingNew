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

public partial class Paypal : System.Web.UI.Page
{

   // public string user_id = "";
    public string orderid = "";
  //  public string item_name;
    //public string item_number;
    public string amount;
  public string PaypalID;

  //  public string email;
  //  public string first_name = "";
    //public string last_name = "";
   // public string address1 = "";
    //public string address2 = "";
  //  public string city = "";
    //public string state = "";
   // public string zip = "";



    protected void Page_Load(object sender, EventArgs e)
    {
       // user_id = Session["CustomerIDD"].ToString();
        orderid = Session["OrderID"].ToString();
        //item_name = "My Shopping Club Product";
        amount = Session["TotalAmount"].ToString();
      //  email = "indoasiangroceries@yahoo.com.au";
        //email = Session["Email"].ToString();
     //   first_name = "Enter First Name";
        //first_name = Session["FirstName"].ToString();
       // address1 = "Enter Address";
        //address1 = Session["Address"].ToString();
      //  city = "Enter City";
        //city = Session["City"].ToString();
        //state = Session["State"].ToString();
        //zip = Session["Zip"].ToString();

        //  item_number = "";
        //  address2="";
        //  last_name = Session["LastName"].ToString();
         PaypalID = "indoasiangroceries@yahoo.com.au";
    }
}
