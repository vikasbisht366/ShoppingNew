<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="MyOrder.aspx.cs" Inherits="MyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //        var GB_ROOT_DIR = "./greybox/";
        function pop(location) {

            var winWidth = 700;

            var winHeight = 400;

            var posLeft = (screen.width - winWidth) / 2;

            var posTop = (screen.height - winHeight) / 2;

            myWindow = window.open(location, 'My Shopping Club Store', 'width=' + winWidth + ',height=' + winHeight + ',top=' + posTop + ',left=' + posLeft +

    ',resizable=yes,scrollbars=yes,toolbar=no,titlebar=no,' +

    'location=no,directories=no,status=no,menubar=no,copyhistory=no');



        }
    </script>
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

        <div class="col-md-8 middlepart">
            <h2 align="center">My Order</h2>
            <div>
                <br />
                <div class="row" style="margin-left: 100px; border: 1px solid #bab4b4; box-shadow: 1px 1px 3px 0px #bab4b4; width: 749px">
                    <div class="col-md-3">Order ID </div>
                    <div class="col-md-3">Product Name </div>
                    <div class="col-md-3">Order Status </div>
                    <div class="col-md-3">AddDate</div>
                </div>
                <asp:Repeater runat="server" ID="rep_orderdetails">
                    <ItemTemplate>
                        <div style="border: 1px solid #bab4b4; box-shadow: 1px 1px 3px 0px #bab4b4; margin-left: 100px">

                            <div class="row" style="margin-left: 20px;">

                                <div class="col-md-3">
                                    <a onclick="pop('OrderDetail.aspx?odid=<%#Eval("OrderID")%>')" style="cursor: pointer;"><%#Eval("OrderID")%></a>
                                </div>
                                <div class="col-md-3">
                                    <%--  <%# Eval("Title") %>--%>
                                </div>
                                <div class="col-md-3">
                                    <%# Eval("OrderStatus") %>
                                </div>
                                <div class="col-md-3">
                                    <%#Eval("AddDate")%>
                                </div>
                                <div class="col-md-3">
                                </div>

                            </div>
                            <br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

            <br />
            <br />
            <h4 align="center" style="color: red">
                <asp:Label runat="server" ID="label_No_record_Found"></asp:Label></h4>

            <br />
            <br />

        </div>
    </div>
</asp:Content>

