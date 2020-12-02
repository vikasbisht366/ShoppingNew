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

public partial class _notifyPaypal : System.Web.UI.Page
{
    clsOrder objclsOrder = new clsOrder();


   // ClsOrder objclsOrder = new ClsOrder();
    //ClsOrder objclsOrder = new ClsOrder();
    string clientMail;
    int totalQty = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                string strPaymentStatus = "";
                string strTransationID = "";
                string strOrderValue = "0.00";

                int OrderId = 0;

                DataSet ds = new DataSet();
                DataTable dtResponses = new DataTable();
                string strXml = "";
                string strEmail = "";
              
              //  OrderId = Convert.ToInt32(Request.Form["item_number"]);
                OrderId = Convert.ToInt32(Request.Form["orderid"]); //by yogesh
                
                //create table to get xml
                dtResponses.Columns.Add("strKey");
                dtResponses.Columns.Add("strValue");
                dtResponses.TableName = "Table1";

                foreach (string x in Request.Form)
                {
                    DataRow dr;
                    dr = dtResponses.NewRow();
                    dr[0] = x.ToString();
                    dr[1] = Convert.ToString(Request.Form[x]);
                    dtResponses.Rows.Add(dr);

                    if (x.ToString() == "payment_status")
                    {
                        strPaymentStatus = Convert.ToString(Request.Form[x]);
                    }
                    if (x.ToString() == "txn_id")
                    {
                        strTransationID = Convert.ToString(Request.Form[x]);
                    }
                }

                ds.Tables.Add(dtResponses);
                strXml = ds.GetXml();

                ds.Dispose();

                //save data to DB              
              // objclsOrder.InsertPayPalResponse(OrderId, strXml);
              InsertPayPalResponse(OrderId, strXml);
                string strTransactionValue;
                if (Request.Form["payment_status"].ToString() == "Completed" || Request.Form["payment_status"].ToString() == "Pending")
                {

                    strTransactionValue = Request.Form["txn_id"];
                   // int odid = Convert.ToInt32(Request.Form["item_number"]);
                    int odid = Convert.ToInt32(Request.Form["orderid"]);
                    UpdateOrder(strTransactionValue, odid);
                  //  SendConfirmation(odid);
                    sendMailAdminPass();//by yogesh

                }
                else
                {

                  //  UpdateOrderStatus(Convert.ToInt32(Request.Form["item_number"]));
                    UpdateOrderStatus(Convert.ToInt32(Request.Form["orderid"]));
                    sendMailAdminFail();
                }
            }
            catch (Exception ex)
            {

            }
        }

    }


    protected void UpdateOrder(string transactionId, int intOrderId)
    {
      Int32 i=0;
   //   i=  objclsOrder.UpdateOrder(transactionId, intOrderId);
//        i=objclsOrder.AddEditOrder(intOrderId,0,"Complete",false,transactionId,0,"");

    }
    protected void UpdateOrderStatus(int intOrderId)
    {
       Int32 i1=0;
       // objclsOrder.UpdateOrderForFailed(intOrderId);
  //        i1=objclsOrder.AddEditOrder(intOrderId,0,"Failed",false,"",0,"");
    }
    protected void InsertPayPalResponse(int intOrderId, string strXml)
    {
     Int32 i2=0;
       // objclsOrder.UpdateOrderForFailed(intOrderId);
    // i2 = objclsOrder.AddEditOrder(intOrderId, 0, "", false, "", 0, strXml);
    }
    private void sendMailAdminFail()
    {
        string strEmailBCC = "yogeshjadon1@gmail.com";
        string strEmailTo = "welcome@myshoppingclub.in";
        FlexiMail objSendMail = new FlexiMail();
        objSendMail.To = strEmailTo;
        objSendMail.CC = "";
        objSendMail.BCC = strEmailBCC;
        objSendMail.From = "welcome@myshoppingclub.in";
        objSendMail.FromName = "My Shopping Club";
        objSendMail.MailBodyManualSupply = true;
        objSendMail.MailBody = "Order was not completed successfuly";
        objSendMail.Subject = "Order Cancel or Failure Message ";
        objSendMail.Send();
    }

    //by yogesh jadon

    private void sendMailAdminPass()
    {
        string strEmailBCC = "yogeshjadon1@gmail.com";
        string strEmailTo = "support@myshoppingclub.in";
        FlexiMail objSendMail = new FlexiMail();
        objSendMail.To = strEmailTo;
        objSendMail.CC = "";
        objSendMail.BCC = strEmailBCC;
        objSendMail.From = "welcome@myshoppingclub.in";
        objSendMail.FromName = "My Shopping Club";
        objSendMail.MailBodyManualSupply = true;
        objSendMail.MailBody = "Order was completed successfuly";
        objSendMail.Subject = "Order Confirmation Message ";
        objSendMail.Send();
    }


    //private void SendMailUser(string[] strarrdata)
    //{

    //    string strEmailTo = "yogeshjadon1@gmail.com";
    //    string strEmailFrom = "welcome@myshoppingclub.in";
    //    string strEmailBCC = "support@myshoppingclub.in";
    //    //string strEmailFrom = "reliablekhandelwal@gmail.com";
    //    //string strEmailBCC = "reliablekhandelwal@gmail.com";

    //    FlexiMail objSendMail = new FlexiMail();
    //    objSendMail.To = "yogeshjadon1@gmail.com";
    //    objSendMail.CC = "lokendra.jain@bluechiptechnosys.com";
    //    objSendMail.BCC = strEmailBCC;
    //    objSendMail.From = strEmailFrom;
    //    objSendMail.FromName = "acurelax";
    //    objSendMail.MailBodyManualSupply = false;
    //    objSendMail.EmailTemplateFileName = "CustomerEmail.html";
    //    objSendMail.Subject = "Your Order Information from Acurelax";
    //    objSendMail.ValueArray = strarrdata;
    //    objSendMail.Send();

    //}
    //protected string[] GetBasketData(int orderid)
    //{
    //    string[] strArray = new string[12];
    //    try
    //    {

    //        ClsOrder _objClsorder = new ClsOrder();
    //        DataTable dt = new DataTable();
    //        dt = _objClsorder.GetOrderByOrderId(orderid);

    //        if (dt.Rows.Count > 0)
    //        {

    //            DataTable dtOrderItems = new DataTable();
    //            dtOrderItems = _objClsorder.GetOrderItems(orderid);
    //            strArray[0] = Convert.ToString(dt.Rows[0]["firstname"]) + "" + Convert.ToString(dt.Rows[0]["lastname"]);
    //            strArray[1] = Convert.ToString(dt.Rows[0]["address"]);
    //            strArray[2] = Convert.ToString(dt.Rows[0]["city"]);
    //            strArray[3] = Convert.ToString(dt.Rows[0]["zip"]);
    //            strArray[4] = Convert.ToString(dt.Rows[0]["country"]);
    //            strArray[5] = Convert.ToDateTime(dt.Rows[0]["orderdate"]).ToShortDateString();
    //            strArray[6] = Convert.ToString(dt.Rows[0]["orderid"]);

    //            decimal decFinalsubTotal = 0;

    //            for (int i = 0; i < dtOrderItems.Rows.Count; i++)
    //            {
    //                decFinalsubTotal = decFinalsubTotal + (Convert.ToDecimal(dtOrderItems.Rows[i]["qty"]) * Convert.ToDecimal(dtOrderItems.Rows[i]["numPrice"]));

    //            }

    //            string strHtmlHead = "<table width='100%' border='1' cellspacing='0' cellpadding='0' style='font-family: Verdana; font-size: 12px;'><tr><th align='left'>ItemCode</th><th align='left' >Product title</th><th align='right'>Quantity</th><th align='right'>Unit Price</th><th align='right'>SubTotal</th>";
    //            string strHtml = string.Empty;
    //            string completeHtml = string.Empty;

    //            for (int j = 0; j < dtOrderItems.Rows.Count; j++)
    //            {
    //                strHtml = strHtml + "<tr><td>" + Convert.ToString(dtOrderItems.Rows[j]["Itemcode"]) + "</td>" +
    //                           "<td>" + Convert.ToString(dtOrderItems.Rows[j]["ProductName"]) + "</td>" +
    //                           "<td align='right' >" + Convert.ToString(dtOrderItems.Rows[j]["qty"]) + "</td>" +
    //                           "<td align='right'>" + String.Format("{0:0.00}", Convert.ToDecimal(dtOrderItems.Rows[j]["NumPrice"])) + "</td>" +
    //                           "<td align='right'>" + String.Format("{0:0.00}", Convert.ToDecimal(dtOrderItems.Rows[j]["qty"]) * Convert.ToDecimal(dtOrderItems.Rows[j]["NumPrice"])) + "</td></tr>";

    //                totalQty += Convert.ToInt32(dtOrderItems.Rows[j]["qty"]);

    //            }
    //            completeHtml = strHtmlHead + strHtml + "</table>"; ;

    //            // this array  at this position hold basket items
    //            strArray[10] = completeHtml;
    //            strArray[7] = "$" + "" + String.Format("{0:0.00}", decFinalsubTotal);
    //            string strShipp = null;

    //            DataTable dtshipping = osp.getshippingdetail(orderid);


    //            //if (string.IsNullOrEmpty(strShipp))
    //            if (dtshipping.Rows.Count == 0)
    //            {
    //                string strGrandTotal = string.Empty;
    //                strArray[8] ="";
    //                decimal grandtotal =  Convert.ToDecimal(decFinalsubTotal);
    //                DataTable dtGetState = osp.GetState(Convert.ToInt32(dtshipping.Rows[0]["state"]), 0);
    //                decimal TaxtAmount = grandtotal / (Convert.ToDecimal(dtGetState.Rows[0]["tax"]));
    //                strArray[11] = "$" + "" + String.Format("{0:0.00}", TaxtAmount);

    //                grandtotal = grandtotal + TaxtAmount;

    //                strGrandTotal = String.Format("{0:0.00}", grandtotal);
    //                strArray[9] = "$" + "" + strGrandTotal;
                 
    //            }

    //            else
    //            {
    //                string strGrandTotal = string.Empty;
    //                DataTable dtGetState = osp.GetState(Convert.ToInt32(dtshipping.Rows[0]["state"]), 0);
    //                int deliverycharge = (Convert.ToInt32(dtGetState.Rows[0]["shippingcost"]) * totalQty);
    //                strArray[8] = "$" + "" + String.Format("{0:0.00}", deliverycharge);
    //                //strArray[12]="100";
    //                //strArray[9] = "2300";

    //                decimal grandtotal = Convert.ToDecimal(deliverycharge) + Convert.ToDecimal(decFinalsubTotal);

    //                decimal TaxtAmount = grandtotal / (Convert.ToDecimal(dtGetState.Rows[0]["tax"]));

    //                strArray[11] = "$" + "" + String.Format("{0:0.00}", TaxtAmount);

    //                grandtotal = grandtotal + TaxtAmount;

    //                strGrandTotal = String.Format("{0:0.00}", grandtotal);
    //                strArray[9] = "$" + "" + strGrandTotal;

                    
    //            }

               
    //            //clientMail = Convert.ToString(dt.Rows[0]["Email"]);


    //        }
    //        //return strArray;
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    return strArray;


    //}

    protected void SendConfirmation(int intOrderId)
    {

       // string[] strArray = new string[11];
       // strArray = GetBasketData(intOrderId);
     //   SendMailUser(strArray);

    }
     

}
