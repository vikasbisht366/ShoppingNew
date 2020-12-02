<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="container-fluid">
        <div class="col-md-3">
            <div style="box-shadow: 1px 1px #e1dbdb; background-color: white;">
                <div style="margin-left: 10px;">
                    <span>
                        <img src="Imagess/306473.png" height="50px" style="margin-top: 10px; margin-bottom: 10px;" />
                    </span>
                </div>
                <div style="float: right; margin-top: -50px; margin-right: 100px;">
                    <div>
                        <span>
                            <asp:Label runat="server" ID="label_hello"><b>Hello,</b></asp:Label></span>
                    </div>
                    <div>
                        <span>
                            <asp:Label runat="server" ID="label_UserName" Font-Bold="true"></asp:Label>
                        </span>
                    </div>
                </div>
            </div>
            <br />
            <div style="box-shadow: 1px 1px #e1dbdb; background-color: white;">
                <p style="padding: 15px; border-bottom: 1px solid #e1dbdb;">
                    &nbsp&nbsp&nbsp
                    <img src="Imagess/MYOrders.png" height="20px" />&nbsp&nbsp&nbsp 
                    <a href="MyOrder.aspx" style="font-size: 18px; text-decoration: none"><b>MY ORDERS </b></a>
                </p>
                <p style="padding: 15px; border-bottom: 1px solid #e1dbdb;">
                    <a href="UserProfile.aspx" style="font-size: 18px; text-decoration: none">&nbsp&nbsp&nbsp 
                         <i class="glyphicon glyphicon-user"></i><b>&nbsp Account Setting</b></a>
                </p>

                <p style="padding: 15px; border-bottom: 1px solid #e1dbdb;">
                    <a href="MoneyTransfer.aspx" style="font-size: 18px; text-decoration: none">&nbsp&nbsp&nbsp 
                         <i class="glyphicon glyphicon-random"></i><b>&nbsp Transfer</b></a>
                </p>

                <p style="padding: 15px;">
                    <a href="ChangePassword.aspx" style="font-size: 18px; text-decoration: none">&nbsp&nbsp&nbsp 
                         <i class="glyphicon glyphicon-lock"></i><b>&nbsp Change Password</b></a>
                </p>

                <p style="padding: 15px; border-top: 1px solid #e1dbdb;">
                    &nbsp&nbsp&nbsp
                     <a href="#" style="font-size: 18px; text-decoration: none"><span class="glyphicon glyphicon-off"></span>&nbsp<b>
                         <asp:Button runat="server" ID="logout" Style="border-style: none; background-color: white;" OnClick="logout_Click" Text="Logout" /></b></a>
                </p>
            </div>
        </div>


        <div class="col-md-8">
            <div class="middlepart">
                <h2 align="center" class="heading">Change Password</h2>

                <br />
                <table align="center" style="line-height: 30px; width: 500px;">
                    <tr>
                        <td class="auto-style1"><b>Current Password :</b>
                        </td>
                        <td class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtCurrentPassword" runat="server" MaxLength="20"
                                TextMode="Password" onfocus="clearText(this)"
                                onblur="clearText(this)" CssClass="txt_field_yo" placeholder="Current Password" Width="243px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Require3" ControlToValidate="txtCurrentPassword" Display="None" ValidationGroup="Submit"
                                runat="server" ErrorMessage="Current Password is Required "></asp:RequiredFieldValidator>

                            <asp:HiddenField runat="server" ID="hidden_oldpass" />
                        </td>
                    </tr>
                    <tr>
                        &nbsp
                    </tr>

                    <tr>

                        <td class="auto-style1"><b>New Password :</b>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="20" TextMode="Password" onfocus="clearText(this)"
                                onblur="clearText(this)" CssClass="txt_field_yo" placeholder="New Password" Width="243px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNewPassword" Display="None" ValidationGroup="Submit"
                                runat="server" ErrorMessage="New Password is Required "></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        &nbsp
                    </tr>
                    <tr>

                        <td class="auto-style1"><b>Confirm Password :</b>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20"
                                TextMode="Password" onfocus="clearText(this)"
                                onblur="clearText(this)" CssClass="txt_field_yo" placeholder="Retype Password" Width="243px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtConfirmPassword" Display="None"
                                ValidationGroup="Submit" runat="server" ErrorMessage="Retype Password is Required "></asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" Display="None"
                                CssClass="ValidationError" ControlToCompare="txtNewPassword" ValidationGroup="Submit" ErrorMessage="Password don't Match" ToolTip="Password must be the same" />

                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>
                            <br />

                            <asp:Button ID="btnSubmit" runat="server" Text="Change Password" OnClick="btnSubmit_Click"
                                ValidationGroup="Submit" CssClass="btn btn-primary " />
                            <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Submit"
                                ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" runat="server" />

                            <br />
                            <br />
                        </td>
                    </tr>
                </table>

            </div>

        </div>
    </div>
</asp:Content>

