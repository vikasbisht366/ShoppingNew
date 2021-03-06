﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<script src="js/countries.js" type="text/javascript"></script>
<style type="text/css">
select
{
width:282px;
}

    .style1
    {
        width: 366px;
    }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="middlepart">
        <h2 class="heading">
            Create An Free Account
        </h2>
 
        <table border="0" cellpadding="2" cellspacing="3" align="left" width="500px" style="line-height:25px;">
            <tr>
                <td style="width:100px;">
                    First Name
                </td>
                <td style="width:20px;">
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtFirstName" runat="server" ToolTip="Please Enter First Name" MaxLength="50" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter First Name"></asp:TextBox>
                   
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        Display="Dynamic" ErrorMessage="Please Enter First Name" SetFocusOnError="True" ValidationGroup="v" InitialValue="Enter First Name">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name
                </td>
                <td>
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtLastName" runat="server" ToolTip="Please Enter Last Name" MaxLength="50" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter Last Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                        Display="Dynamic" ErrorMessage="Please Enter Last Name" SetFocusOnError="True" ValidationGroup="v" InitialValue="Enter Last Name">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Email
                </td>
                <td>
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtEmail" runat="server" ToolTip="Please Enter your Email" MaxLength="50" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter Your Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Please Enter Email" SetFocusOnError="True" ValidationGroup="v" InitialValue="Enter Your Email">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Please Enter Correct Email" SetFocusOnError="True"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="v">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Password
                </td>
                <td>
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ToolTip="Please Enter Password"
                        MaxLength="30" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="*********"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Please Enter Password" SetFocusOnError="True"
                        ValidationGroup="v" InitialValue="*********">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Re-Password</td>
                <td>
                    :</td>
                <td class="style1">
                    <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" ToolTip="Please Enter Re-Password"
                        MaxLength="30" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="*********"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword0" runat="server" ControlToValidate="txtRePassword"
                        Display="Dynamic" ErrorMessage="Please Enter Re-Password" SetFocusOnError="True"
                        ValidationGroup="v" InitialValue="*********">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtRePassword" 
                        Display="Dynamic" ErrorMessage="Password does not match" SetFocusOnError="True" 
                        ValidationGroup="v">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Contact No.
                </td>
                <td>
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtContactNo1" runat="server" ToolTip="Please Enter your Contact"
                        MaxLength="30" onfocus="clearText(this)" onblur="clearText(this)" CssClass="txt_field_yo" value="-----------------"></asp:TextBox>
                    <cc2:FilteredTextBoxExtender ID="txtContactNo1_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" TargetControlID="txtContactNo1" FilterType="Custom,Numbers"  ValidChars=".,-, ,">
                    </cc2:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="rfvContactNo1" runat="server" ControlToValidate="txtContactNo1"
                        Display="Dynamic" ErrorMessage="Please Enter Contact" SetFocusOnError="True"
                        ValidationGroup="v" InitialValue="-----------------">*</asp:RequiredFieldValidator>
                  
                </td>
            </tr>
            <tr>
                <td>
                    Address
                </td>
                <td>
                    :
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtAddress" runat="server" ToolTip="Please Enter Address" MaxLength="150" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter Your Address" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                        Display="Dynamic" ErrorMessage="Please Enter Address" SetFocusOnError="True"
                        ValidationGroup="v" InitialValue="Enter Your Address">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Country
                </td>

                
                <td>
                    :
                </td>
                <td rowspan="3">    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    
                 
           <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlCountry_SelectedIndexChanged" CssClass="txt_field_yo" Width="292px">
                    </asp:DropDownList>   <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                        Display="Dynamic" ErrorMessage="Please Select Country" 
                        SetFocusOnError="True" ValidationGroup="v" InitialValue="0">*</asp:RequiredFieldValidator>
                <br />
             <asp:DropDownList ID="ddlState" runat="server" CssClass="txt_field_yo" Width="292px" 
                            AutoPostBack="True" onselectedindexchanged="ddlState_SelectedIndexChanged">
                    </asp:DropDownList> <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                        Display="Dynamic" ErrorMessage="Please Select State" 
                        SetFocusOnError="True" ValidationGroup="v">*</asp:RequiredFieldValidator>

                        <br />
             <asp:DropDownList ID="ddlCity" runat="server" CssClass="txt_field_yo" Width="292px">
                    </asp:DropDownList> <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                        Display="Dynamic" ErrorMessage="Please Select City" 
                        SetFocusOnError="True" ValidationGroup="v">*</asp:RequiredFieldValidator>
                     </ContentTemplate>
                    </asp:UpdatePanel> 
                     
                </td>
            </tr>
            <tr>
                <td>
                    State
                </td>
                <td>
                    :
                </td>
            </tr>
            <tr>
                <td>
                    City
                </td>
                <td>
                    :
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
                        MaxLength="6" Width="100px" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="000000"></asp:TextBox>
                    <cc2:FilteredTextBoxExtender ID="txtZip_FilteredTextBoxExtender" runat="server" 
                        Enabled="True" FilterType="Numbers" TargetControlID="txtZip">
                    </cc2:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip"
                        Display="Dynamic" ErrorMessage="Please enter ZIP code" SetFocusOnError="True"
                        ValidationGroup="v" InitialValue="000000" >*</asp:RequiredFieldValidator>
                </td>
            </tr>
      
       
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td class="style1" style="height:50px;">
                   
                        <asp:Image ID="CaptchaControl1" runat="server" ImageUrl="~/captcha.aspx" />
                           
                         
                         
                        
                </td>
            </tr>
            <tr>
                <td>
                </td>
                   <td>
                </td>
                <td class="style1">
                    Enter the characters you see
                    <asp:TextBox ID="txtCaptcha" runat="server" MaxLength="5"  Width="100px" CssClass="txt_field_yo"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvZip0" runat="server" ControlToValidate="txtCaptcha"
                        Display="Dynamic" ErrorMessage="Please enter CAPTCHA value" SetFocusOnError="True"
                        ValidationGroup="v">*</asp:RequiredFieldValidator>
                    <br />
                    <span style="color: #808080;">Letter are not case sensitive</span>
                   
                </td>
            </tr>
                  <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
                <td class="style1">
                    <asp:CheckBox ID="chbReadTerms" runat="server" />
                    I agree to the <a href="TermsCondition.aspx" target="_blank">Terms and Conditions </a>. 
                 
                </td>
            </tr>
            <tr>  <td>
                    &nbsp;
                </td>
                <td>
                </td>
                <td class="style1">
               <br />
             
                     <asp:Button ID="btnSubmit" runat="server" Text="Submit"  
                                      onclick="btnSubmit_Click" ValidationGroup="v" CssClass="btnSubmit"/>
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="v" />
                </td>
            </tr>
        </table>
    </div>
  
</asp:Content>
