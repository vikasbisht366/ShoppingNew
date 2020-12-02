<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="MoneyTransfer.aspx.cs" Inherits="MoneyTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <br />

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

            <h3 style="margin-top: 20px">Account Details</h3>

            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_MEMBERID" CssClass="form-control" placeholder="Member ID" ReadOnly="true"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hidden_member" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_DefaultAmount" CssClass="form-control" placeholder="Amount" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_transmember" CssClass="form-control" placeholder="Customer ID For Transfer"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Submit" Display="None" ControlToValidate="txt_transmember" runat="server" ErrorMessage="Memberid is required "></asp:RequiredFieldValidator>
                    <asp:HiddenField runat="server" ID="hiddencustomer" />
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_Amount" CssClass="form-control" placeholder="Enter Amount"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Submit" Display="None" ControlToValidate="txt_Amount" runat="server" ErrorMessage="Amount is required "></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_narration" CssClass="form-control" placeholder="Description"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Submit" Display="None" ControlToValidate="txt_narration" runat="server" ErrorMessage="Description is required "></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_password" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit" Display="None" ControlToValidate="txt_password" runat="server" ErrorMessage="Password is required "></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <asp:Button runat="server" ID="btn_accountsave" ValidationGroup="Submit" Text="Save Information" CssClass="btn btn-primary" OnClick="btn_accountsave_Click" />
                <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Submit" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" runat="server" />
            </div>

            <div class="clearfix"></div>

        </div>
        <div class="col-md-12">
            &nbsp
            <br />
            &nbsp
        </div>
    </div>



</asp:Content>

