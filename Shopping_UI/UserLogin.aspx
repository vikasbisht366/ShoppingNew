<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .wrapper {
            right: 0px;
            margin: 0px auto;
            width: 40%;
            position: relative;
            border: 8px solid #036091;
            border-radius: 9px;
        }

        .clsloginpart {
            padding: 5px;
        }

        .logheader {
            text-align: center;
            border-bottom: 1px solid #036091;
        }
    </style>
    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function isCharKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return true;
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="body" style="background-color: #f0f0f0; margin-top: -20px;">
        <br />
        <div class="container">
            <asp:HiddenField runat="server" ID="hidden_memberid" />

            <section style="margin-top: 20px;">
                <div id="container_demo">

                    <div id="login" class="animate form" runat="server">
                        <div class="wrapper">
                            <h1 class="logheader">Log in</h1>
                            <div class="clsloginpart">
                                <label for="username" class="uname">Username </label>
                                <asp:TextBox runat="server" ID="txtusername" name="username" type="text" placeholder="CustomerID Or Mobile" MaxLength="25" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="Require1" runat="server" ControlToValidate="txtusername" ValidationGroup="login" ErrorMessage="Email Address is required"></asp:RequiredFieldValidator>
                                <br />
                                <label for="password" class="youpasswd">Password </label>
                                <asp:TextBox runat="server" ID="txtpassword" CssClass="form-control" name="password" MaxLength="18" TextMode="Password" type="password" placeholder="Password" />
                                <asp:RequiredFieldValidator ID="Required2" runat="server" ControlToValidate="txtpassword" ValidationGroup="login" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                                <br />
                                <asp:CheckBox runat="server" type="checkbox" name="loginkeeping" ID="loginkeeping" />
                                <label for="loginkeeping">Keep me logged in</label>
                                <asp:LinkButton runat="server" ID="lnkforgatepassword" class="to_register pull-right" OnClick="lnkforgatepassword_Click">Forgot Password</asp:LinkButton>
                                <asp:Button runat="server" ID="btn_login" type="submit" Text="Login" ValidationGroup="login" Font-Bold="true" OnClick="btn_login_Click" CssClass="btn btn-primary" Style="padding-left: 0px; width: 100%" />
                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="login" ShowSummary="false" ShowMessageBox="false" runat="server" />

                                <div>
                                    &nbsp
                                </div>
                                <div align="center">
                                    <b>Not a member yet ?
                                    <asp:LinkButton runat="server" ID="btnsignup" class="to_register" OnClick="btnsignup_Click">Create Account</asp:LinkButton>
                                    </b>
                                </div>
                                <div>
                                    &nbsp
                                </div>

                            </div>

                        </div>
                    </div>
                    <div id="ForgatePassword" class="animate form" runat="server" style="display: none">
                        <div class="wrapper">
                            <h1 class="logheader">Forgot Password</h1>
                            <div class="clsloginpart">
                                <label for="username" class="uname">Enter Your Registor Mobile No </label>
                                <asp:TextBox runat="server" ID="txtForgatemoile" name="username" type="text" MaxLength="10" placeholder="Email Or Mobile" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtForgatemoile" ValidationGroup="forgate" ErrorMessage="Mobile is required"></asp:RequiredFieldValidator>
                                <asp:Button runat="server" ID="btnforgatepass"  Text="Login" ValidationGroup="forgate" Font-Bold="true" CssClass="btn btn-primary" Style="padding-left: 0px; width: 100%" OnClick="btnforgatepass_Click" />
                                <asp:ValidationSummary ID="ValidationSummary3" ValidationGroup="forgate" ShowSummary="false" ShowMessageBox="false" runat="server" />
                            </div>

                        </div>
                    </div>


                    <div id="register" class="animate form" runat="server" style="display: none">
                        <div class="wrapper">
                            <asp:ScriptManager runat="server" ID="scriptmanager"></asp:ScriptManager>
                            <h1 class="logheader">Sign up </h1>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <div class="loading-overlay">
                                        <div class="wrapper">
                                            <div class="ajax-loader-outer">
                                                Loading...
                                            </div>
                                        </div>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txt_username" onkeypress="return isCharKey(event)" name="usernamesignup" type="text" MaxLength="25" placeholder="User Name" CssClass="form-control" /></td>
                                                 <asp:RequiredFieldValidator ID="Require3" ControlToValidate="txt_username" Display="None" ValidationGroup="Submit" runat="server" ErrorMessage="Name is Required "></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txt_email" type="email" MaxLength="30" placeholder="Email Address" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="Required4" ControlToValidate="txt_email" Display="None" ValidationGroup="Submit" runat="server" ErrorMessage="Email is Required"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">

                                            <asp:TextBox runat="server" ID="txtMobile" name="Mobilesignup" MaxLength="10" onkeypress="return isNumberKey(event)" placeholder="Mobile Number" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="Required5" ControlToValidate="txtMobile" Display="None" ValidationGroup="Submit" runat="server" ErrorMessage="Mobile Number is required"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txt_password" CssClass="form-control" MaxLength="18" name="passwordsignup" TextMode="Password" type="password" placeholder="Password" />
                                            <asp:RequiredFieldValidator ID="Required6" ValidationGroup="Submit" Display="None" ControlToValidate="txt_password" runat="server" ErrorMessage="Password is required "></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" MaxLength="18" CssClass="form-control" ID="passwordsignup_confirm" name="passwordsignup_confirm" type="password" TextMode="Password" placeholder="Retype Password" />
                                            <asp:RequiredFieldValidator ID="Required7" ValidationGroup="Submit" Display="None" ControlToValidate="passwordsignup_confirm" runat="server" ErrorMessage="Retype Password"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="passwordsignup_confirm" Display="None"
                                                CssClass="ValidationError" ControlToCompare="txt_password" ValidationGroup="Submit" ErrorMessage="Password don't Match" ToolTip="Password must be the same" />
                                        </div>




                                        <div class="form-group">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_referralid" name="referralid" placeholder="Referral ID" OnTextChanged="txt_referralid_TextChanged" AutoPostBack="true" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Submit" Display="None" ControlToValidate="txt_referralid" runat="server" ErrorMessage="Please Enter REFERRALID ( If You have No REFERRALID Then Enter 'WINSMART' ) "></asp:RequiredFieldValidator>
                                             <asp:HiddenField runat="server" ID="hidden_referral" />
                                        </div>
                                        <div class="form-group">
                                            <asp:Button runat="server" ID="txt_signup" type="submit" ValidationGroup="Submit" Text="Sign up" Font-Bold="true" OnClick="txt_signup_Click" CssClass="btn btn-primary" Style="width: 100%" />
                                            <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Submit" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" runat="server" />
                                            <div>
                                                &nbsp
                                            </div>
                                            <div class="col-md-12" align="center">
                                                <b>Already a member ? 
                                            <asp:LinkButton runat="server" ID="lnklogin" class="to_register" OnClick="lnklogin_Click">Go and log in</asp:LinkButton>
                                                    <b>
                                            </div>
                                             <div>
                                                &nbsp
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>


                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txt_signup" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="txt_referralid" EventName="TextChanged" />
                                    <asp:PostBackTrigger ControlID="lnklogin" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                    </div>

                </div>
            </section>
        </div>
        <br />
    </div>

</asp:Content>

