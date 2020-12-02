<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="highslide/highslide.css" />

    <script type="text/javascript" src="highslide/highslide-with-gallery.js">
    </script>

    <script type="text/javascript">
        hs.graphicsDir = 'highslide/graphics/';
        hs.align = 'center';
        hs.transitions = ['expand', 'crossfade'];
        hs.outlineType = 'rounded-white';
        hs.fadeInOut = true;
        hs.numberPosition = 'caption';
        hs.dimmingOpacity = 0.75;

        // Add the controlbar
        if (hs.addSlideshow) hs.addSlideshow({
            //slideshowGroup: 'group1',
            interval: 500,
            repeat: false,
            useControls: true,
            fixedControls: 'fit',
            overlayOptions: {
                opacity: .75,
                position: 'bottom center',
                hideOnMouseOut: true
            }
        });
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 151px;
            text-align: left;
        }

        .auto-style2 {
            width: 209px;
        }

        .auto-style3 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 66.66666667%;
            left: 0px;
            top: 17px;
            height: 3px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <br />
        <br />
        <div class="container" style="box-shadow: 1px 1px 5px 4px #bab4b4;">
            <div class="row" style="margin-top: 15px">
                <div>
                    <div class="col-md-3">
                        <img src="images/orderdetails.png" width="300px" />
                    </div>
                    <div class="col-md-6">
                        <h2 style="color: #27c97b; margin-left: 100px"><b>Thank You For Your Order !</b></h2>
                    </div>
                </div>

            </div>
        </div>
        <br />
        <br />
        <div class="container" style="border: 1px solid #bab4b4; box-shadow: 1px 1px 5px 4px #bab4b4;">
            <asp:Repeater runat="server" ID="rep_orderdetails">
                <ItemTemplate>
                    <div>
                        <div class="row" style="margin-left: 20px; margin-right: 20px; border-bottom: 1px solid #bab4b4">

                            <div class="col-md-6">
                                <table class="auto-style3">
                                    <tr>
                                        <h4 style="color: #27c97b">Order Details </h4>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">Order ID</td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">Order Date</td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("AddDate") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-6" style="border-left: 1px solid #bab4b4">


                                <h4 style="color: #27c97b">Address </h4>

                                <h4><b><%# Eval("Name") %></b></h4>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Mobile_No") %>'></asp:Label>
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("Address") %>'></asp:Label><b>,</b>
                                </p>
                                <p>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("City") %>'></asp:Label><b>,</b>

                                    <asp:Label ID="Label5" runat="server" Text=' <%# Eval("State") %>'></asp:Label><b>,</b>

                                    <asp:Label ID="Label6" runat="server" Text=' <%# Eval("Country") %>'></asp:Label><b>,</b>

                                    <asp:Label ID="Label7" runat="server" Text=' <%# Eval("Zip") %>'>,</asp:Label></td>
                                </p>
                                <p>
                                    <%#Eval("Locality") %> <b>,</b>
                                    <%#Eval("Landmark") %><b>,</b>
                                    <%#Eval("Alternate_MobileNo") %>
                                </p>
                                <br />
                            </div>

                        </div>
                        <br />
                        <div class="row" style="margin-left: 20px">

                            <div class="col-md-4">
                                <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="150" height="150" alt='<%# Eval("title") %>' />
                            </div>
                            <div class="col-md-3">
                                <%# Eval("Title") %>
                            </div>

                            <div class="col-md-2">
                                <%#Eval("TaxRate")%>%
                            </div>
                            <div class="col-md-2">
                                <span class="WebRupee">
                                    <img src="images/inr.png" alt="" style="float: left;" /></span><%#Eval("Total_Amount")%>
                            </div>

                        </div>
                        <br />
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>
        <br />
        <br />
    </div>

</asp:Content>

