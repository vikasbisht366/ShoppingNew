<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        body {
            margin-top: 20px;
        }

        .fa {
            font-size: 50px;
            text-align: right;
            position: absolute;
            top: 7px;
            right: 27px;
            outline: none;
        }

        a {
            transition: all .3s ease;
            -webkit-transition: all .3s ease;
            -moz-transition: all .3s ease;
            -o-transition: all .3s ease;
        }
            /* Visitor */
            a.visitor i, .visitor h4.list-group-item-heading {
                color: #E48A07;
            }

            a.visitor:hover {
                background-color: #E48A07;
            }

                a.visitor:hover * {
                    color: #FFF;
                }
            /* Facebook */
            a.facebook-like i, .facebook-like h4.list-group-item-heading {
                color: #3b5998;
            }

            a.facebook-like:hover {
                background-color: #3b5998;
            }

                a.facebook-like:hover * {
                    color: #FFF;
                }
            /* Google */
            a.google-plus i, .google-plus h4.list-group-item-heading {
                color: #dd4b39;
            }

            a.google-plus:hover {
                background-color: #dd4b39;
            }

                a.google-plus:hover * {
                    color: #FFF;
                }
            /* Twitter */
            a.twitter i, .twitter h4.list-group-item-heading {
                color: #00acee;
            }

            a.twitter:hover {
                background-color: #00acee;
            }

                a.twitter:hover * {
                    color: #FFF;
                }
            /* Linkedin */
            a.linkedin i, .linkedin h4.list-group-item-heading {
                color: #0e76a8;
            }

            a.linkedin:hover {
                background-color: #0e76a8;
            }

                a.linkedin:hover * {
                    color: #FFF;
                }
            /* Tumblr */
            a.tumblr i, .tumblr h4.list-group-item-heading {
                color: #34526f;
            }

            a.tumblr:hover {
                background-color: #34526f;
            }

                a.tumblr:hover * {
                    color: #FFF;
                }
            /* Youtube */
            a.youtube i, .youtube h4.list-group-item-heading {
                color: #c4302b;
            }

            a.youtube:hover {
                background-color: #c4302b;
            }

                a.youtube:hover * {
                    color: #FFF;
                }
            /* Vimeo */
            a.vimeo i, .vimeo h4.list-group-item-heading {
                color: #44bbff;
            }

            a.vimeo:hover {
                background-color: #44bbff;
            }

                a.vimeo:hover * {
                    color: #FFF;
                }
    </style>
    <%-- <script>
        // Animate the element's value from x to y:
        $({ someValue: 0 }).animate({ someValue: Math.floor(Math.random() * 3000) }, {
            duration: 3000,
            easing: 'swing', // can be anything
            step: function () { // called on every step
                // Update the element's text with rounded-up value:
                $('.count').text(commaSeparateNumber(Math.round(this.someValue)));
            }
        });

        function commaSeparateNumber(val) {
            while (/(\d+)(\d{3})/.test(val.toString())) {
                val = val.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
            }
            return val;
        }
    </script>--%>
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
            <%--   <div class="col-md-6">
                <div class="list-group">
                    <a href="#" class="list-group-item visitor">
                        <h3 class="pull-right">
                            <i class="fa fa-eye"></i>
                        </h3>
                        <h4 class="list-group-item-heading count">
                            <asp:Label runat="server" ID="lblwalletbonus"></asp:Label>
                        </h4>
                        <p class="list-group-item-text">
                            Wallet Balance
                        </p>
                    </a>

                </div>
            </div>
            <div class="col-md-6">
                <div class="list-group">
                    <a href="#" class="list-group-item visitor">
                        <h3 class="pull-right">
                            <i class="fa fa-eye"></i>
                        </h3>
                        <h4 class="list-group-item-heading count">
                            <asp:Label runat="server" ID="lblbonuspoint"></asp:Label>

                        </h4>
                        <p class="list-group-item-text">
                            Bonus Point
                        </p>
                    </a>
                </div>
            </div>--%>

            <asp:ScriptManager runat="server" ID="scriptmanager"></asp:ScriptManager>

            <h3>Personal Information</h3>
            <div class="col-md-6">
                <asp:HiddenField runat="server" ID="hidden_Customerid" />
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtCustomerName" CssClass="form-control" placeholder="Customer Name" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtMoblie" CssClass="form-control" placeholder="Customer Mobile" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Customer Email"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtmemberid" CssClass="form-control" placeholder="Member ID" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Customer Address"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:UpdatePanel runat="server" ID="updatepanel">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlcountry" class="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:HiddenField runat="server" ID="hidden_countryid" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:UpdatePanel runat="server" ID="updatepanel1">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlstate" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                            </asp:DropDownList>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:HiddenField runat="server" ID="HiddenField1" />
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:UpdatePanel runat="server" ID="updatepanel2">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlcity" CssClass="form-control" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:HiddenField runat="server" ID="HiddenField2" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtzip" CssClass="form-control" placeholder="Pin Code"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_adddate" CssClass="form-control" placeholder="Joining Date" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-12">
                <asp:Button runat="server" ID="btnSaveData" Text="Save Information" CssClass="btn btn-primary" OnClick="btnSaveData_Click" />

            </div>
            &nbsp
            <div class="col-md-12" style="border-top: 1px solid black">
                &nbsp
            </div>

            <h3 style="margin-top: 20px">Account Details</h3>
            <asp:HiddenField runat="server" ID="hidden_id" />
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_Aadhar" CssClass="form-control" placeholder="Aadhar Card Number"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_PanCard" CssClass="form-control" placeholder="Pan Card Number" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_BankAccount" CssClass="form-control" placeholder="Account Number"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_ifsc" CssClass="form-control" placeholder="Ifsc Code"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_branchName" CssClass="form-control" placeholder="Branch Name"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txt_branchAddress" CssClass="form-control" placeholder="Branch Address"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-12">
                <asp:Button runat="server" ID="btn_accountsave" Text="Save Information" CssClass="btn btn-primary" OnClick="btn_accountsave_Click" />

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

