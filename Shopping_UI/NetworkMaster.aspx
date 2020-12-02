<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="NetworkMaster.aspx.cs" Inherits="NetworkMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/product.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //        var GB_ROOT_DIR = "./greybox/";
        function pop(location) {

            var winWidth = 420;

            var winHeight = 650;

            var posLeft = (screen.width - winWidth) / 2;

            var posTop = (screen.height - winHeight) / 2;

            myWindow = window.open(location, 'My Shopping Club Store', 'width=' + winWidth + ',height=' + winHeight + ',top=' + posTop + ',left=' + posLeft +

',resizable=yes,scrollbars=yes,toolbar=no,titlebar=no,' +

'location=no,directories=no,status=no,menubar=no,copyhistory=no');



        }
    </script>
    <style>
        body {
           
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="breadcrumb_dress" style="margin-top: 0px;">
        <div class="container">
            <ul>
                <li><a href="Default.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a> <i>/</i></li>
                <li>Network</li>
            </ul>
        </div>
    </div>
    <br />
    <div>
        <div class="col-md-6">
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
                <a href="MemberSummary.aspx" class="list-group-item visitor">
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
        </div>

    </div>
    <h3 align="center">Network Master</h3>

    <div class="checkout" style="border-bottom: 1px solid #a59f9f;">
        <div class="container">

            <div class="checkout-right">
                <table class="timetable_sub">
                    <asp:Repeater runat="server" ID="rep_cart" OnItemCommand="rep_cart_ItemCommand">
                        <HeaderTemplate>
                            <tr style="background-color: #a59f9f;">
                                <th>Member Name</th>
                                <th>Email</th>
                                <th>Mobile</th>
                                <th>MemberID</th>
                                <th>Lavel</th>
                                <th>SponcerID</th>
                                <th>Joining Date</th>
                                <th>Active/DeActive</th>
                                <th>Summary</th>
                            </tr>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr class="rem1">
                                <td class="invert"><%#Eval("UserName")%> </td>
                                <td class="invert"><%#Eval("Email") %></td>
                                <td class="invert"><%#Eval("Mobile_No") %> </td>
                                <td class="invert"><%#Eval("memberid") %> </td>
                                <td class="invert"><%#Eval("State") %></td>
                                <td class="invert"><%#Eval("referral") %></td>
                                <td class="invert"><%#Eval("AddDate") %></td>
                                <td class="invert">
                                    <asp:ImageButton runat="server" ImageUrl='<%# Convert.ToString(Eval("IsActive"))=="True"?"~/images/active_icon.png":"~/images/deactivate_Icon.png" %>'
                                        AlternateText='<%# Convert.ToString(Eval("IsActive"))=="True"?"Active":"Deactive" %>' title="Active Or Deactive"
                                        ID="btnActive" CommandName="Active" CommandArgument='<%# Eval("CustomerID") %>' /></td>
                                <td class="invert">
                                    <asp:LinkButton runat="server" ID="btn_Summary" Text="Summary" CommandName="Summary" CommandArgument='<%#Eval("CustomerID") %>'>
                                       
                                    </asp:LinkButton>
                                </td>

                            </tr>

                        </ItemTemplate>

                    </asp:Repeater>
                </table>
            </div>
            <!--Continue PAyment-->


        </div>
    </div>
</asp:Content>

