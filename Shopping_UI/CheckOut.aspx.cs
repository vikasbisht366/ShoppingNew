using System;
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
using System.Diagnostics;
using System.IO;
using System.Net;
using BLL;

public partial class CheckOut : System.Web.UI.Page
{
    Cart _objCart;
    clsCustomer objCustomer = new clsCustomer();
    clsCountry objCountry = new clsCountry();
    clsOrder objOrder = new clsOrder();
    clsOrderDetail objOrderDetail = new clsOrderDetail();
    clsExtra objExtra = new clsExtra();

    clsState objState = new clsState();
    DataTable dt = new DataTable();
    DataTable dt3 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddlCountry();
            bindShoppingCart();
        }
    }

    #region Step1
    protected void btnRegisterNext_Click(object sender, EventArgs e)
    {
        dt = objCustomer.GetCustomerByEmail(txtEmailR.Text.Trim());
        if (dt.Rows.Count > 0)
        {
            Page.RegisterStartupScript("a", "<script>alert('This Email Already exists our database, please choose another.')</script>");

        }
        else
        {

            ViewState["FirstName"] = txtFirstName.Text;
            ViewState["EmailR"] = txtEmailR.Text.Trim();
            ViewState["ContactR"] = txtContactNo.Text;
            txtAddress.Text = "";
            txtCity.Text = "";
            txtZip.Text = "";
            txtLandmark.Text = "";

            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void btnLoginNext_Click(object sender, EventArgs e)
    {
        dt = objCustomer.CustomerLogin(txtEmail.Text, txtPassword.Text);
        if (dt.Rows.Count > 0)
        {

            Session["customerID"] = Convert.ToString(dt.Rows[0]["CustomerID"]).Trim();
            Session["customerName"] = Convert.ToString(dt.Rows[0]["FirstName"]);
            txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
            txtLandmark.Text = "";
            fillddlCountry();
            ddlCountry.SelectedValue = Convert.ToString(dt.Rows[0]["CountryID"]);
            fillddlState(Convert.ToInt32(ddlCountry.SelectedValue));
            ddlState.SelectedValue = Convert.ToString(dt.Rows[0]["StateID"]);
            txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
            txtZip.Text = Convert.ToString(dt.Rows[0]["ZIP"]).Trim();

            MultiView1.ActiveViewIndex = 1;
            //  CustomerID, FirstName, LastName, Email, ContactNo1, ContactNo2, ImageUrl, Password, Address, Country, State, City, ZIP, IPAddress, Remark, AddDate, LastUpdate, IsActive, CountryID, StateID, CityID

        }
        else
        {
            lblMessage.Text = "Please enter valid email and password";
        }



    }

    #endregion
    #region Step2
    protected void btnShippingDetail_Click(object sender, EventArgs e)
    {

        try
        {

            //string xmlresult = SendSMS("10", "10", "10", "3216", txtZip.Text, "5", "AUS_PARCEL_REGULAR");
           // DataSet ds = new DataSet();
          //  System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
          //  doc.LoadXml(xmlresult);
          //  ds.ReadXml(new System.IO.StringReader(doc.OuterXml));

            //Repeater1.DataSource = ds;
            // Repeater1.DataBind();


            //Session["Address"] = txtAddress.Text;
            //Session["Landmark"] = txtLandmark.Text;
            //Session["CountryID"] = ddlCountry.SelectedValue;
            //Session["Country"] = ddlCountry.SelectedItem.Text;
            //Session["StateID"] = ddlState.SelectedValue;
            //Session["State"] = ddlState.SelectedItem.Text;
            //Session["City"] = txtCity.Text;
            //Session["Zip"] = txtZip.Text;

            ViewState["ShippingCost"] = "0.00";

            dt = objExtra.GetExtra(1);
            lblDiscount.Text = Convert.ToString(dt.Rows[0]["Extra1"]);

            Double discountcost = 0.00;
            discountcost = Convert.ToDouble(Session["ProductCost"].ToString()) * Convert.ToDouble(lblDiscount.Text.Trim()) / 100;
            Double discountcostround = 0.00;
            discountcostround = Math.Round(discountcost, 2);
            lblDiscountCost.Text = discountcostround.ToString();
            lblProductCost.Text = Session["ProductCost"].ToString();
            lblShippingCost.Text = ViewState["ShippingCost"].ToString();

            Session["TotalAmount"] = (Convert.ToDouble(Session["ProductCost"].ToString()) + Convert.ToDouble(ViewState["ShippingCost"].ToString())) - Convert.ToDouble(lblDiscountCost.Text);
            lblTotalAmount.Text = Session["TotalAmount"].ToString();
            MultiView1.ActiveViewIndex = 3;


           // MultiView1.ActiveViewIndex = 3;
        }
        catch
        {
           // lblMessageZIP.Text = "Please Enter valid Post Code";
        }




    }

    #region fill Country,State
    public void fillddlCountry()
    {
        DataTable dt = new DataTable();
        dt = objCountry.GetCountry();
        ddlCountry.DataSource = dt;
        ddlCountry.DataValueField = "CountryID";
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, new ListItem("Select a Country", "0"));

    }
    public void fillddlState(int CountryID)
    {
        //DataTable dt = new DataTable();
        //dt = objState.GetStateByCountryID(CountryID, true);
        //ddlState.DataSource = dt;
        //ddlState.DataValueField = "StateID";
        //ddlState.DataTextField = "StateName";
        //ddlState.DataBind();
        //ddlState.Items.Insert(0, new ListItem("Select a State", "0"));

    }
    #endregion
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlState(Convert.ToInt32(ddlCountry.SelectedValue));
    }
    #endregion
    #region Step3
    //protected void btnShippingCalculate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        string xmlresult = SendSMS("10", "10", "10", "3216", txtZip.Text, Session["TotalWeightCK"].ToString(), ddlServiceType.SelectedValue);
    //        DataSet ds = new DataSet();
    //        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    //        doc.LoadXml(xmlresult);
    //        ds.ReadXml(new System.IO.StringReader(doc.OuterXml));

    //        dt = ds.Tables[0];
    //        if (dt.Rows.Count > 0)
    //        {
    //            ViewState["ShippingCost"] = Convert.ToString(dt.Rows[0]["total_cost"]).Trim();
    //        }
    //        Repeater1.DataSource = ds;
    //        Repeater1.DataBind();

    //    }
    //    catch
    //    {
    //        Page.RegisterStartupScript("Msg1", "<script>alert('Please enter valid values');</script>");
    //    }
    //}

    //protected void lnkEditShippingDetails_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 1;
    //}

    //protected void btnShippingMethod_Click(object sender, EventArgs e)
    //{

    //    if (ddlServiceType.SelectedValue.ToString() == "0")
    //    {
    //        Page.RegisterStartupScript("Msg1", "<script>alert('Please Select Shipping Method');</script>");

    //    }
    //    else
    //    {
    //        if (ViewState["ShippingCost"] == null || ViewState["ShippingCost"] == "")
    //        {
    //            Page.RegisterStartupScript("Msg1", "<script>alert('Please Calculate Shipping');</script>");
    //        }
          
    //        else
    //        {
    //            dt = objExtra.GetExtra(1);
    //            lblDiscount.Text = Convert.ToString(dt.Rows[0]["Extra1"]);
             
    //            Double discountcost=0.00;
    //            discountcost = Convert.ToDouble(Session["ProductCost"].ToString()) * Convert.ToDouble(lblDiscount.Text.Trim()) / 100;
    //            Double discountcostround = 0.00;
    //            discountcostround = Math.Round(discountcost, 2);
    //            lblDiscountCost.Text = discountcostround.ToString();
    //            lblProductCost.Text = Session["ProductCost"].ToString();
    //            lblShippingCost.Text = ViewState["ShippingCost"].ToString();

    //            Session["TotalAmount"] = (Convert.ToDouble(Session["ProductCost"].ToString()) + Convert.ToDouble(ViewState["ShippingCost"].ToString()))-Convert.ToDouble(lblDiscountCost.Text);
    //            lblTotalAmount.Text = Session["TotalAmount"].ToString();
    //            MultiView1.ActiveViewIndex = 3;
    //        }

    //    }
    //}
    #endregion

    protected void btnFinalCheckOut_Click(object sender, EventArgs e)
    {
        paypalFunction();
    }
    private void paypalFunction()
    {
        _objCart = (Cart)Session["cart"];

        #region Customer create process
        if (Session["CustomerID"] == null || Session["CustomerID"] == "")
     
        {

            #region create customer
            try
            {
                Int32 intresult = 0;
               // intresult = objCustomer.AddEditCustomer(0, ViewState["FirstName"].ToString(), "", ViewState["EmailR"].ToString(), ViewState["ContactR"].ToString(), "", "", ViewState["ContactR"].ToString(), txtAddress.Text, ddlCountry.SelectedItem.Text, ddlState.SelectedItem.Text, txtCity.Text, txtZip.Text, Convert.ToString(Request.UserHostAddress), "", Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), 0);
                hidCustomerID.Value = intresult.ToString().Trim();
                sendMailwelcome(ViewState["EmailR"].ToString(), ViewState["ContactR"].ToString());
            }
            catch
            {
                hidCustomerID.Value = "1";
            }
            #endregion
         
        }
        else
        {
            hidCustomerID.Value = Session["CustomerID"].ToString();
        }
        #endregion
    //   Session["OrderID"] = 1;
       #region Order create process
       try
       {
           Int32 orderid = 0;
           string Extra2 = Session["ProductCost"].ToString() + "," + ViewState["ShippingCost"].ToString() + "," + lblDiscountCost.Text + "," + Session["TotalAmount"].ToString();
      //     orderid = objOrder.AddEditOrder(0, Convert.ToInt32(hidCustomerID.Value), "InQueue", false, "NA", 1, Extra2);
           Session["OrderID"] = orderid.ToString().Trim();
       }
       catch
       {
           Page.RegisterStartupScript("Msg1", "<script>alert('sorry for inconvenience...Some Error Occure in Order Process ');location.replace('CheckOut.aspx');</script>");

       }
       #endregion
       #region OrderDetail create process
       try
       {
           for (Int32 i = 0; i < _objCart.Items.Count; i++)
           {
               Int32 orderdetailid = 0;
               //orderdetailid = objOrderDetail.AddEditOrderDetail(0, Convert.ToInt32(hidCustomerID.Value), _objCart.Items[i].ProductID, Convert.ToInt32(Session["OrderID"].ToString()), _objCart.Items[i].Quantity);
               //  Session["OrderDetailID"] = orderdetailid.ToString().Trim();
           }
       }
       catch
       {
           //Error
       }
       #endregion
        if (Session["OrderID"] != null || Session["OrderID"] != "" || Session["TotalAmount"] != null || Session["TotalAmount"] != "")
        {
            Response.Redirect("Paypal.aspx");
        }
        else
        {
            Response.Redirect("processpaypal.aspx?status=fail");
        }

        //try
        //{
        //    //Session["CustomerIDD"] = hidCustomerID.Value.Trim();
        //    dt3 = objCustomer.GetAllCustomer(Convert.ToInt32(Session["CustomerIDD"].ToString()));

        //    if (dt3.Rows.Count > 0)
        //    {
        //        Session["FirstName"] = Convert.ToString(dt3.Rows[0]["FirstName"]);
        //        Session["Email"] = Convert.ToString(dt3.Rows[0]["Email"]);

        //        Response.Redirect("Paypal.aspx");
        //    }
        //    else
        //    {
        //        Session["FirstName"] = "Enter Your Name";
        //        Session["Email"] = "Enter Your Email";
        //        Response.Redirect("Paypal.aspx");
        //    }
        //}
        //catch
        //{
        //    Session["FirstName"] = "Enter Your Name";
        //    Session["Email"] = "Enter Your Email";
        //    Response.Redirect("Paypal.aspx");
        //}

    }
    protected string SendSMS(string lngth, string wdth, string hgth, string fpcode, string tpcode, string weght, string service_code)
    {
        string url = "https://auspost.com.au/api/postage/parcel/domestic/calculate.xml?";
        url = url + "length=" + HttpUtility.UrlEncode(lngth) + "&width=" + HttpUtility.UrlEncode(wdth) + "&height=" + HttpUtility.UrlEncode(hgth) + "&from_postcode=" + HttpUtility.UrlEncode(fpcode) + "&to_postcode=" + HttpUtility.UrlEncode(tpcode) + "&option_code=&weight=" + HttpUtility.UrlEncode(weght) + "&service_code=" + HttpUtility.UrlEncode(service_code) + "&extra_cover=";
        Uri objURI = new Uri(url);
        HttpWebRequest objwebreq = (HttpWebRequest)WebRequest.Create(objURI);
        objwebreq.ContentType = "text/xml;charset=utf-8;";
        objwebreq.Method = "Get";
        objwebreq.Timeout = 15000;
        objwebreq.Headers.Set("AUTH-KEY", "mf5yY8a2dzugeBsJFtZ5sIcNf2KlBbVl");
        HttpWebResponse objWebResponse = (HttpWebResponse)objwebreq.GetResponse();
        Stream objStream = objWebResponse.GetResponseStream();
        StreamReader objStreamReader = new StreamReader(objStream);
        return objStreamReader.ReadToEnd();

    }
    private void bindShoppingCart()
    {
        _objCart = new Cart();
        if (Session["cart"] != null)
        {
            _objCart = (Cart)Session["cart"];

            Session["ProductCost"] = _objCart.Total.ToString();
            Session["TotalWeightCK"] = _objCart.Totalweight.ToString();

        }
        else
        {
            // Response.Redirect("Product.aspx");
            Page.RegisterStartupScript("Msg1", "<script>alert('There are no products in your cart.Please To add a product to your cart');location.replace('Product.aspx');</script>");
        }
        // GeneralFunction.bindDataControl(rep_cart, (DataTable)Session["cart"]);
    }
    private void sendMail(string Email, string Password)
    {

        string[] valueArray = new string[2];
        valueArray[0] = Email;
        valueArray[1] = Password;



        FlexiMail objSendMail = new FlexiMail();
        objSendMail.To = Convert.ToString(ConfigurationManager.AppSettings["mailTo"]);
        objSendMail.CC = Email;
        objSendMail.BCC = Convert.ToString(ConfigurationManager.AppSettings["mailBCC"]);
        objSendMail.From = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);



        objSendMail.FromName = "My Shopping Club";
        objSendMail.MailBodyManualSupply = false;
        objSendMail.EmailTemplateFileName = "ForgetPassword.htm";
        objSendMail.Subject = "Password Recovery";
        objSendMail.ValueArray = valueArray;


        objSendMail.Send();



    }

    private void sendMailwelcome(string Email, string Password)
    {

        string[] valueArray = new string[2];
        valueArray[0] = Email;
        valueArray[1] = Password;



        FlexiMail objSendMail = new FlexiMail();
        objSendMail.To = Convert.ToString(ConfigurationManager.AppSettings["mailTo"]);
        objSendMail.CC = Email;
        objSendMail.BCC = Convert.ToString(ConfigurationManager.AppSettings["mailBCC"]);
        objSendMail.From = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);



        objSendMail.FromName = "My Shopping Club";
        objSendMail.MailBodyManualSupply = false;
        objSendMail.EmailTemplateFileName = "welcome.htm";
        objSendMail.Subject = "Welcome to My Shopping Club ";
        objSendMail.ValueArray = valueArray;


        objSendMail.Send();



    }
    protected void lnkforgotpassword_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text != "")
        {
            DataTable dt = new DataTable();
            dt = objCustomer.GetCustomerByEmail(txtEmail.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                string password = Convert.ToString(dt.Rows[0]["Password"]);
                try
                {

                    sendMail(txtEmail.Text, password);
                    txtEmail.Text = "";
                    Page.RegisterStartupScript("a", "<script>alert('Thank you! Your password has been sent at your Email Address.')</script>");
                }
                catch
                {
                    Page.RegisterStartupScript("a", "<script>alert('Server Error..Please try later.')</script>");
                }
            }
            else
            {
                Page.RegisterStartupScript("a", "<script>alert('This Email address does not exists our database, please enter another.')</script>");

            }

        }

        else
        {
            lblMessage.Text = "Please enter your email address!!!";
        }
    }
}
