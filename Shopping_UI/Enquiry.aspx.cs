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

public partial class Enquiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
 
   
    protected void clear()
    {
        txtName.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtComment.Text = "";
    }

    private void sendMail()
    {
        try
        {

            string[] valueArray = new string[4];
            valueArray[0] = txtName.Text.Trim();
            valueArray[1] = txtPhone.Text.Trim();
            valueArray[2] = txtEmail.Text.Trim();
            valueArray[3] = txtComment.Text.Trim();
         

            FlexiMail objSendMail = new FlexiMail();
            objSendMail.To = Convert.ToString(ConfigurationManager.AppSettings["mailTo"]);
            objSendMail.CC = txtEmail.Text.Trim();
            objSendMail.BCC = Convert.ToString(ConfigurationManager.AppSettings["mailBCC"]);
            objSendMail.From = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);



            objSendMail.FromName = "My Shopping Club";
            objSendMail.MailBodyManualSupply = false;
            objSendMail.EmailTemplateFileName = "Enquiry.htm";
            objSendMail.Subject = "Enquiry Details";
            objSendMail.ValueArray = valueArray;


            objSendMail.Send();
            Page.RegisterStartupScript("a", "<script>alert('Thanks for your enquiry!)</script>");
            clear();
        }
        catch
        {
           
            Page.RegisterStartupScript("Msg1", "<script>alert('sorry for inconvenience....Please Contact here');location.replace('ContactUs.aspx');</script>");

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        sendMail();
    }
}
