using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Net;
using System.IO;

public partial class UserLogin : System.Web.UI.Page
{

    clsCustomer objaccess = new clsCustomer();
    DataTable dt = new DataTable();
    clsCustomerWalletAmount objwallet = new clsCustomerWalletAmount();
    Cls_DataAccess objacc = new Cls_DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ReferralID"] != null && Request.QueryString["ReferralID"] != "")
        {
            txt_referralid.Text = Request.QueryString["ReferralID"].ToString();
            txt_referralid.Enabled = false;
            Funcheckreferral();
            register.Style.Add("display", "block");
            login.Style.Add("display", "none");
        }
        Random memberid = new Random();
        hidden_memberid.Value = "WIN" + memberid.Next(100000, 900000).ToString();
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {

        dt = objaccess.CustomerLogin(txtusername.Text, txtpassword.Text);
        if (dt.Rows.Count > 0)
        {
            Session["CustomerID"] = Convert.ToString(dt.Rows[0]["CustomerID"]);
            Session["CustomerName"] = Convert.ToString(dt.Rows[0]["UserName"]);
            Session["memberid"] = Convert.ToString(dt.Rows[0]["memberid"]);
            Response.Redirect("UserHome.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert(' Invalid User  Name Or Password !');</script>");
        }

    }

    protected void txt_signup_Click(object sender, EventArgs e)
    {

        dt = objaccess.GetCustomerBymobile(txtMobile.Text);
        if (dt.Rows.Count == 0)
        {
            dt = objaccess.GetCustomer(Convert.ToInt32(Session["CustomerID"]));

            string ipaddress = GetIPAddress();
            objaccess.AddEditCustomerRegistration(0, txt_username.Text, txt_email.Text, txt_password.Text, ipaddress, txtMobile.Text, hidden_memberid.Value, txt_referralid.Text);
            dt = objaccess.GetLoginforbulk(txtMobile.Text, txt_password.Text);
            if (dt.Rows.Count > 0)
            {
                Session["CustomerID"] = Convert.ToString(dt.Rows[0]["CustomerID"]);
                objwallet.AddEditWalletAmount(0, "0", "0", "0", Session["CustomerID"].ToString());
                DataTable dtmemberdetails = objacc.GetDatatable("Select * from tblcustomer where customerID=" + dt.Rows[0]["CustomerID"].ToString());
                if (dtmemberdetails.Rows.Count > 0)
                {
                    string Message = "Registration Successfully with us. Your CUSTOMER ID IS : " + dtmemberdetails.Rows[0]["MemberID"].ToString() + " Share on Whatsapp and Facebook and Get 200 Points For Shopping Daily";
                   // SendSMS(dtmemberdetails.Rows[0]["Mobile_No"].ToString(), Message, dtmemberdetails.Rows[0]["MemberID"].ToString());
                }
            }
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "keykey", "alert(' Your Account Create Successfully !!!');location.replace('UserHome.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "keykey", "alert('You are Already Registered With mobile !!!');", true);
        }


    }

    protected string GetIPAddress()
    {
        String strHostName = string.Empty;
        // Getting Ip address of local machine...
        // First get the host name of local machine.
        strHostName = Dns.GetHostName();
        Console.WriteLine("Local Machine's Host Name: " + strHostName);
        // Then using host name, get the IP address list..
        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        return addr[1].ToString();
    }

    protected void txt_referralid_TextChanged(object sender, EventArgs e)
    {
        Funcheckreferral();
    }

    private void Funcheckreferral()
    {
        if (txt_referralid.Text != "")
        {
            dt = objaccess.Getmemberbyid(txt_referralid.Text);

            if (dt.Rows.Count > 0)
            {
                hidden_referral.Value = dt.Rows[0]["memberid"].ToString();
                string referal = hidden_referral.Value;
            }
            else
            {
                txt_referralid.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "keykey", "alert('Please Enter Valid Sponsor Id ');", true);
            }
        }
    }

    //protected void txtMobile_TextChanged(object sender, EventArgs e)
    //{
    //    dt = objaccess.GetCustomerBymobile(txtMobile.Text);
    //    if (dt.Rows.Count > 0)
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "keykey", "alert('You are Already Registered Please Login !!!');", true);
    //        // Page.RegisterStartupScript("Msg1", "<script>alert('You are Already Registered Please Login !!!');</script>");
    //    }
    //}

    //public void SendSMS(string MobileNo, string smsMessage, string refID)
    //{
    //    smsMessage = smsMessage + ", http://winspaymart.com/UserLogin.aspx?ReferralID=" + refID;
    //    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    WebClient client = new WebClient();

    //    string baseurl = "http://bulksms.ezulix.com/api/sendhttp.php?authkey=220062ACrMVV57Q7I5b1f500b&mobiles=91" + MobileNo + "&message=" + smsMessage + "&sender=WINSPM&route=4&country=0";


    //    Stream data = client.OpenRead(baseurl);
    //    StreamReader reader = new StreamReader(data);
    //    string s = reader.ReadToEnd();
    //    data.Close();
    //    reader.Close();
    //}

    protected void btnsignup_Click(object sender, EventArgs e)
    {
        register.Style.Add("display", "block");
        login.Style.Add("display", "none");
    }

    protected void lnklogin_Click(object sender, EventArgs e)
    {
        register.Style.Add("display", "none");
        login.Style.Add("display", "block");
    }

    protected void lnkforgatepassword_Click(object sender, EventArgs e)
    {
        login.Style.Add("display", "none");
        ForgatePassword.Style.Add("display", "block");

    }

    protected void btnforgatepass_Click(object sender, EventArgs e)
    {
        if (txtForgatemoile.Text != "")
        {
            DataTable dtmemberdetails = objacc.GetDatatable("Select * from tblcustomer where mobile_no='" + txtForgatemoile.Text + "'");
            if (dtmemberdetails.Rows.Count > 0)
            {
                string Message = "Thanks for password Request . Your Password IS : " + dtmemberdetails.Rows[0]["password"].ToString();
               // SendSMS(dtmemberdetails.Rows[0]["Mobile_No"].ToString(), Message, dtmemberdetails.Rows[0]["MemberID"].ToString());
                login.Style.Add("display", "block");
                ForgatePassword.Style.Add("display", "none");
            }
        }
    }
}