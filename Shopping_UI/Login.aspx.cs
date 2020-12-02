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
using System.IO;
using BLL;

public partial class Login : System.Web.UI.Page
{
    clsCustomer objCustomer = new clsCustomer();
    DataTable dt = new DataTable();
    //yogeshjadon1@gmail.com
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkforgotpassword_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text != "Enter Email")
        {
                DataTable dt = new DataTable();
                dt = objCustomer.GetCustomerByEmail(txtEmail.Text.Trim());
                if (dt.Rows.Count>0)
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

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        dt = objCustomer.CustomerLogin(txtEmail.Text, txtPassword.Text);
        if (dt.Rows.Count > 0)
        {
            Session["customerID"] = Convert.ToString(dt.Rows[0]["CustomerID"]);
            Session["customerName"] = Convert.ToString(dt.Rows[0]["UserName"]);
            Response.Redirect("Welcome.aspx");
        }
        else
        {
            lblMessage.Text = "Please enter valid email and password";
        }
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
}
