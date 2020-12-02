<%@ Page Title="" Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 64px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="middlepart">
        <h2 class="heading">
            Already a member
        </h2>
        <img src="Images/Login.jpg" alt="" style="float: left; width: 300px;" />
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
      
        <table cellpadding="2" cellspacing="3" align="left" width="350px" style="line-height: 25px;
            border: solid 1px #cfcfcf; padding: 20px;">
            <tr>
                <td colspan="3">
                    <h2 class="heading">
                        Login with us
                    </h2>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    Email
                </td>
                <td style="width: 20px;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter Email" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Please enter email" SetFocusOnError="True" ValidationGroup="l"
                        InitialValue="Enter Email">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    Password
                </td>
                <td style="width: 20px;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="25" TextMode="Password" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="*******" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Please enter password" SetFocusOnError="True"
                        ValidationGroup="l" InitialValue="*******">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td class="style1">
                </td>
                <td class="style1">
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="l" OnClick="btnLogin_Click"
                        CssClass="btnSubmit" />
 
    </td> </tr>
            <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:LinkButton ID="lnkforgotpassword" runat="server" CssClass="forgotpassword" CausesValidation="false"
                OnClick="lnkforgotpassword_Click">Forgot Password</asp:LinkButton>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ValidationGroup="l" ShowSummary="False" />
        </td>
    </tr>
    </table> 
      </asp:Panel>
    
    
    </div>
</asp:Content>
