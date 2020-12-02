<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut"
    Theme="checkoutTextBox" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/cart.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 300px;
        }
    </style>
</head>
<body style="padding:10px;margin:10px;background-color:#cfcfcf;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="720px" style="background-color:#fff;height:450px;vertical-align:top;">
        <tr>
        <td>  <h1 style="padding-left:20px;">
                                            Checkout Process</h1></td>
        </tr>
            <tr>
                <td valign="top">
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <table width="775px" style="padding: 10px;">
                             
                                <tr>
                                    <td style="width: 251px;" valign="top">
                                        <div>
                                            <a class="selected" href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Account
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step2 button-->
                                        <div>
                                            <a href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step3 button-->
                                        <div>
                                           <a href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Method</div>
                                            </a>
                                        </div>
                                        <!--step4 button-->
                                        <div>
                                         <a href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Order
                                                        Complete</div>
                                            </a>
                                        </div>
                                        <!--step5 button-->
                                        <div>
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </td>
                                    <td>
                                        <table width="200px" style="line-height: 25px; border: solid 1px #cfcfcf; padding: 10px;">
                                            <tr>
                                                <td>
                                                    <h2>
                                                        New User ?</h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtFirstName" runat="server" ToolTip="Please Enter Name" MaxLength="50"></asp:TextBox>
                                                    <cc2:TextBoxWatermarkExtender ID="txtFirstName_TextBoxWatermarkExtender" runat="server"
                                                        Enabled="True" TargetControlID="txtFirstName" WatermarkCssClass="watermark" WatermarkText="Enter name">
                                                    </cc2:TextBoxWatermarkExtender>
                                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                        Display="Dynamic" ErrorMessage="Please Enter Name" SetFocusOnError="True" ValidationGroup="rv">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtEmailR" runat="server" ToolTip="Please Enter your Email" MaxLength="50"></asp:TextBox>
                                                    <cc2:TextBoxWatermarkExtender ID="txtEmailR_TextBoxWatermarkExtender" runat="server"
                                                        Enabled="True" TargetControlID="txtEmailR" WatermarkCssClass="watermark" WatermarkText="Enter email">
                                                    </cc2:TextBoxWatermarkExtender>
                                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmailR"
                                                        Display="Dynamic" ErrorMessage="Please Enter Email" SetFocusOnError="True" ValidationGroup="rv">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmailR"
                                                        Display="Dynamic" ErrorMessage="Please Enter Correct Email" SetFocusOnError="True"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="rv">*</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtContactNo" runat="server" ToolTip="Please Enter Contact No" MaxLength="30"></asp:TextBox>
                                                    <cc2:FilteredTextBoxExtender ID="txtContactNo_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Custom,Numbers" TargetControlID="txtContactNo" ValidChars=".,-, ,">
                                                    </cc2:FilteredTextBoxExtender>
                                                    <cc2:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                                        TargetControlID="txtContactNo" WatermarkCssClass="watermark" WatermarkText="Enter contact no">
                                                    </cc2:TextBoxWatermarkExtender>
                                                    <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo"
                                                        Display="Dynamic" ErrorMessage="Please Enter Contact No" SetFocusOnError="True"
                                                        ValidationGroup="rv">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                   
                                                        <asp:Button ID="btnRegisterNext" runat="server" Text="Continue" 
                                                            ValidationGroup="rv" OnClick="btnRegisterNext_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ValidationGroup="rv" ShowSummary="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <h1 style="border: none;">
                                            OR</h1>
                                    </td>
                                    <td>
                                        <table width="200px" style="line-height: 25px; border: solid 1px #cfcfcf; padding: 10px;">
                                            <tr>
                                                <td>
                                                    <h2>
                                                        Sign In</h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                                                    <cc2:TextBoxWatermarkExtender ID="txtEmail_TextBoxWatermarkExtender" runat="server"
                                                        Enabled="True" TargetControlID="txtEmail" WatermarkCssClass="watermark" WatermarkText="Enter email">
                                                    </cc2:TextBoxWatermarkExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                                        Display="Dynamic" ErrorMessage="Please enter user register email" SetFocusOnError="True"
                                                        ValidationGroup="l">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="25" TextMode="Password"></asp:TextBox>
                                                    <cc2:TextBoxWatermarkExtender ID="txtPassword_TextBoxWatermarkExtender" runat="server"
                                                        Enabled="True" TargetControlID="txtPassword" WatermarkCssClass="watermark" WatermarkText="************">
                                                    </cc2:TextBoxWatermarkExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword"
                                                        Display="Dynamic" ErrorMessage="Please enter password" SetFocusOnError="True"
                                                        ValidationGroup="l">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkforgotpassword0" runat="server" CausesValidation="false" CssClass="forgotpassword"
                                                        OnClick="lnkforgotpassword_Click">Forgot Password</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                  
                                                        <asp:Button ID="btnLoginNext" runat="server" Text="Continue" 
                                                            ValidationGroup="l" onclick="btnLoginNext_Click" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="l" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                              
                            </table>
                        </asp:View>
                   
                        <asp:View ID="View2" runat="server">
                            <table width="775px" style="padding: 10px;">
                            
                                <tr>
                                    <td style="width: 251px;" valign="top">
                                        <div>
                                            <a class="selected" href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Account
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step2 button-->
                                        <div>
                                            <a href="#" class="selected">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step3 button-->
                                        <div>
                                          <a href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Method</div>
                                            </a>
                                        </div>
                                        <!--step4 button-->
                                        <div>
                                        <a href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Order
                                                        Complete</div>
                                            </a>
                                        </div>
                                        <!--step5 button-->
                                        <div>
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </td>
                                    <td>
                                        <table width="450px" style="line-height: 25px; border: solid 1px #cfcfcf; padding: 10px;">
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblMessageZIP" runat="server" EnableViewState="False" 
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td style="width: 325px;">
                                                    <asp:TextBox ID="txtAddress" runat="server" EnableTheming="false" 
                                                        Height="100px" TextMode="MultiLine" ToolTip="Please Enter Address" 
                                                        Width="200px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                                                        ControlToValidate="txtAddress" Display="Dynamic" 
                                                        ErrorMessage="Please Enter Address" SetFocusOnError="True" ValidationGroup="vs">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Landmark
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLandmark" runat="server" MaxLength="150" ToolTip="Please Enter Address"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Country
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                 <asp:DropDownList ID="ddlCountry" runat="server" Width="206px" Height="25px" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlCountry_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <%--   <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                                                        Display="Dynamic" ErrorMessage="Please select Country" SetFocusOnError="True"
                                                        ValidationGroup="vs">*</asp:RequiredFieldValidator>--%>
                                                    <asp:RequiredFieldValidator ID="rfvAddress0" runat="server" 
                                                        ControlToValidate="ddlCountry" Display="Dynamic" 
                                                        ErrorMessage="Please Select Country" InitialValue="0" SetFocusOnError="True" 
                                                        ValidationGroup="vs">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    State
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlState" runat="server" Width="206px" Height="25px">
                                                    </asp:DropDownList>
                                                   <%-- <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="state"
                                                        Display="Dynamic" ErrorMessage="Please Select State" SetFocusOnError="True" ValidationGroup="vs">*</asp:RequiredFieldValidator>--%>
                                                    <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" 
                                                        ControlToValidate="ddlState" Display="Dynamic" 
                                                        ErrorMessage="Please Select State" InitialValue="0" SetFocusOnError="True" 
                                                        ValidationGroup="vs">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    City
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td class="style1">
                                                    <asp:TextBox ID="txtCity" runat="server" ToolTip="Please Enter City" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                                                        Display="Dynamic" ErrorMessage="Please Enter Your City" SetFocusOnError="True"
                                                        ValidationGroup="vs">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    ZIP/Postcode
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td class="style1">
                                                   <asp:TextBox ID="txtZip" runat="server" ToolTip="Please Enter ZIP code" 
                        MaxLength="6" Width="100px" EnableTheming="false"></asp:TextBox>
                    <cc2:FilteredTextBoxExtender ID="txtZip_FilteredTextBoxExtender" runat="server" 
                        Enabled="True" FilterType="Numbers" TargetControlID="txtZip">
                    </cc2:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip"
                        Display="Dynamic" ErrorMessage="Please enter ZIP code" SetFocusOnError="True"
                        ValidationGroup="vs">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revZIP" runat="server" 
                        ErrorMessage="Please enter valid ZIP" ControlToValidate="txtZip" 
                        Display="Dynamic" SetFocusOnError="True" ValidationExpression="\d{6}" 
                        ValidationGroup="vs">*</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                              
                                                <td colspan="3">
                                                    <br />
                                                
                                                        <asp:Button ID="btnShippingDetail" runat="server" 
                                                            Text="Continue" ValidationGroup="vs" onclick="btnShippingDetail_Click" />
                                                 
                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="vs" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            
                            </table>
                        </asp:View>
                         <asp:View ID="View3" runat="server">
                           </asp:View>
                  <%--      <asp:View ID="View3" runat="server">
                           <table width="775px" style="padding: 10px;">
                           
                                <tr>
                                    <td style="width: 251px;" valign="top">
                                        <div>
                                            <a class="selected" href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Account
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step2 button-->
                                        <div>
                                            <a href="#" class="selected">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step3 button-->
                                        <div>
                                            <a href="#" class="selected">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Method</div>
                                            </a>
                                        </div>
                                        <!--step4 button-->
                                        <div>
                                         <a href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Order
                                                        Complete</div>
                                            </a>
                                        </div>
                                        <!--step5 button-->
                                        <div>
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </td>
                                    <td>
                                        <table width="450px" style="line-height: 25px; border: solid 1px #cfcfcf; padding: 10px;">
                                      <tr>
                                      <td style="height:250px;">
                                      
                                          <table cellpadding="5" cellspacing="5">
        
            <tr>
                <td>
                    Shipping Method </td>
                <td>
                    <asp:DropDownList ID="ddlServiceType" runat="server">
                        <asp:ListItem Value="0">--Select Shipping Method --</asp:ListItem>
                        <asp:ListItem Value="AUS_PARCEL_REGULAR">Regular Parcel</asp:ListItem>
                        <asp:ListItem Value="AUS_PARCEL_EXPRESS">Express Post Parcel</asp:ListItem>
                        <asp:ListItem Value="AUS_PARCEL_PLATINUM">Express Post Platinum Parcel</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvZip0" runat="server" ControlToValidate="ddlServiceType"
                        Display="Dynamic" ErrorMessage="Please Select Shipping Method" SetFocusOnError="True"
                        ValidationGroup="sm" InitialValue="0">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
             
                                                    <asp:Button ID="btnShippingCalculate" runat="server" Text="Shipping Calculate" 
                        onclick="btnShippingCalculate_Click" ValidationGroup="sm" />
                                                    </div>
                  
                 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="False">
                    <ItemTemplate>
                    <div style="padding:20px;">
                  
                    <h3>   <%#Eval("service")%></h3>
               <p style="text-align:justify;"><%#Eval("delivery_time")%></p>
                    <p style="font-weight:bold;text-transform:uppercase;">Price :$<%#Eval("total_cost")%></p>
                 

                    </div>
                    </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
                                      
                                     </td>
                                      </tr>
                                            <tr>
                                              
                                                <td>
                                                    <br />
                                                   
                                                        <asp:Button ID="btnShippingMethod" runat="server" 
                                                            Text="Continue" ValidationGroup="vs" onclick="btnShippingMethod_Click" />
                                                
                                             
                                                    <asp:LinkButton ID="lnkEditShippingDetails" runat="server" Font-Bold="True" 
                                                        ForeColor="Black" onclick="lnkEditShippingDetails_Click">Edit Shipping Details</asp:LinkButton>
                                             
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                             
                            </table>
                        </asp:View>--%>
                        
                               <asp:View ID="View4" runat="server">
                            
                           <table width="775px" style="padding: 10px;">
                             
                                <tr>
                                    <td style="width: 251px;" valign="top">
                                        <div>
                                            <a class="selected" href="#">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Account
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step2 button-->
                                        <div>
                                            <a href="#" class="selected">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Details</div>
                                            </a>
                                        </div>
                                        <br />
                                        <!--step3 button-->
                                        <div>
                                            <a href="#" class="selected">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shipping
                                                        Method</div>
                                            </a>
                                        </div>
                                        <!--step4 button-->
                                        <div>
                                            <a href="#" class="selected">
                                                <div class="steps_button" style="margin-top: 0px;">
                                                    <div style="margin: 6px 0px 0px 20px;">
                                                        Step 4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Order
                                                        Complete</div>
                                            </a>
                                        </div>
                                        <!--step5 button-->
                                        <div>
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </td>
                                    <td>
                                       <h3>Congratulation!!! you will get   <asp:Label ID="lblDiscount" runat="server" Font-Bold="True"></asp:Label>% Discount on product cost</h3>
                                        <table width="450px" style="line-height: 25px; border: solid 1px #cfcfcf; padding: 10px;">
                                      <tr>
                                      <td style="height:150px;"><a href=""></a>
                                          <table cellpadding="5" cellspacing="5" class="style1">
                                              <tr>
                                                  <td>
                                                      Total Product Cost</td>
                                                  <td>
                                                       <img src="images/inr.png" alt="" style="float:left;" /><asp:Label ID="lblProductCost" runat="server" Font-Bold="True"></asp:Label>
                                                  </td>
                                                 
                                              </tr>
                                              <tr>
                                                  <td>
                                                      Total Shipping Cost</td>
                                                  <td>
                                                       <img src="images/inr.png" alt="" style="float:left;" /><asp:Label ID="lblShippingCost" runat="server" Font-Bold="True"></asp:Label>
                                                  </td>
                                                
                                              </tr>
                                              <tr>
                                                  <td>
                                                      Discount on Product Cost</td>
                                                  <td >
                                                    <img src="images/inr.png" alt="" style="float:left;" /><asp:Label ID="lblDiscountCost" runat="server" Font-Bold="True"></asp:Label></td>
                                                 
                                              </tr>
                                              <tr style="color:#C90911;font-weight:bold;">
                                                  <td>
                                                      Total</td>
                                                  <td>
                                                       <img src="images/inr.png" alt="" style="float:left;" /><asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                                  </td>
                                              </tr>
                                          </table>
                                          </td>
                                      </tr>
                                            <tr>
                                              
                                                <td>
                                                    <br />
                                                   
                                                        <asp:Button ID="btnFinalCheckOut" runat="server" Text="Proceed to Payment" 
                                                            ValidationGroup="vs" onclick="btnFinalCheckOut_Click"  />
                                                  
                                             
                                                    <asp:HiddenField ID="hidCustomerID" runat="server" />
                                             
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                             
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
