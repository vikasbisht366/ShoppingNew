<%@ Page Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true"
    CodeFile="ProcessPayPal.aspx.cs" Inherits="ProcessPayPal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="middlepart">
<h2 class="heading">  Process Paypal</h2>
<div style="margin:50px;padding:50px;">
     <asp:MultiView ID="mvMain" runat="Server">
        <asp:View ID="vwMsg" runat="server">
            <table style="height: 350px; width:100%;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top">
                        <table width="100%;" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left" valign="top">
                                    <h1 style="color: red">
                                        <br />
                                        <asp:Literal ID="Literal1" runat="server">Sorry !!</asp:Literal>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <b>Your transaction has not been successful.<br />
                                        Please try again making sure all payment details are correct.
                                        <br />
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vwThanks" runat="server">
            <table style="height: 350px; width: 100%;;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top">
                        <table width="100%;" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left" valign="top">
                                    <h1>
                                        <br />
                                        <asp:Literal ID="litTitle" runat="server">Thank you for shopping with us</asp:Literal>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <p style="text-align: justify;">
                                        <b>Your order has been successfully placed on our website.<br />
                                            Shortly you will get an Email.<br />
                                            Your order id is
                                            <asp:Label ID="lblOrderNo" runat="server"></asp:Label>.
                                            <br />
                                            <br />
                                            <a href="http://www.myshoppingclub.in/">Click here to return to Home Page</a></b>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vwBasketError" runat="server">
            <table style="height: 350px; width: 100%;;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top">
                        <table width="100%;" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left" valign="top">
                                    <h1 style="color: red">
                                        <asp:Literal ID="Literal2" runat="server">Sorry !!</asp:Literal>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <b>You have no item in basket.</b><br />
                                    <br />
                                    <b>Please add an item first and then checkout.</b>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
   
   </div>
  </div>
 
</asp:Content>
