<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Paypal.aspx.cs" Inherits="Paypal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Paypal </title>

    <script language="JavaScript">
        function submitform() {
            document.forms[0].submit();
        }
    </script>

</head>
<body>
    <div style="margin: 100px 0 0 300px;">
        Processing Please wait...</div>
          <form method="post" action="https://www.paypal.com/cgi-bin/webscr" id="PayPalForm"
    name="PayPalForm">
  <%--  <form method="post" action="https://www.sandbox.paypal.com/cgi-bin/webscr" id="PayPalForm"
    name="PayPalForm">--%>
    <input type="hidden" name="no_shipping" value="2" />
    <input name="cmd" type="hidden" id="cmd" value="_xclick" />
    <input name="redirect_cmd" type="hidden" id="redirect_cmd" value="_xclick" />
    <input type="hidden" name="business" value="abc@yahoo.com" />
    <input type="hidden" name="item_name" value="Shopping club Products" />
    <%--   <input type="hidden" name="item_number" value="<%=item_number%>" />--%>
    <input type="hidden" name="orderid" value="<%=orderid%>" />
    <input name="image_url" type="hidden" title="styleshake" value="http://www.myshoppingclub.in/images/logo.jpg" />
    <input type="hidden" name="amount" value="<%=amount%>" />
    <input type="hidden" name="currency_code" value="INR" />
    <input type="hidden" name="country_code" value="IN" />
 <%--   <input type="hidden" name="first_name" value="<%=first_name%>" />--%>
    <%-- <input type="hidden" name="last_name" value="<%=last_name%>" />--%>
  <%--  <input type="hidden" name="address1" value="<%=address1%>" />--%>
    <%--    <input type="hidden" name="address2" value="<%=address2%>" />--%>
  <%--  <input type="hidden" name="city" value="<%=city%>" />
    <input type="hidden" name="state" value="<%=state%>" />--%>
  <%--  <input type="hidden" name="zip" value="<%=zip%>" />--%>
    <input type="hidden" name="lc" value="AUD" />
  <%--  <input type="hidden" name="email" value="<%=email%>" />--%>
    <%--    <input type="hidden" name="email-address" value="<%=email%>" />--%>
    <input type="hidden" name="notify_url" value="http://www.myshoppingclub.in/_notifyPaypal.aspx" />
    <input type="hidden" name="return" value="http://www.myshoppingclub.in/processpaypal.aspx?oid=<%=orderid%>&status=ok" />
    <input type="hidden" name="cancel_return" value="http://www.myshoppingclub.in/processpaypal.aspx?oid=<%=orderid%>&status=fail" />
    
    
 
  
    </form>
</body>
</html>

<script>    submitform();</script>

