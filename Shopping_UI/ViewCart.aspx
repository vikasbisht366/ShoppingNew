<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="Cart_ViewCart" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- breadcrumbs -->
    <div class="breadcrumb_dress" style="margin-top: -20px;">
        <div class="container">
            <ul>
                <li><a href="Index.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a> <i>/</i></li>
                <li>Checkout</li>
            </ul>
        </div>
    </div>
    <!-- breadcrumbs -->

    <!-- checkout -->
   <div class="checkout" style="border-bottom: 1px solid #a59f9f;">
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <h3 style="float: left; margin-left: 0px;"><b>MY Cart :
                        <asp:Label runat="server" ID="label_cart_quentity">
                            <asp:Label runat="server" ID="Label_TotalInCart"></asp:Label>
                        </asp:Label></b> </h3>
                </div>
                <div class="col-md-2">
                    <h3><b>Pin : </b><i class="glyphicon glyphicon-map-marker"></i>
                        <asp:Label runat="server" ID="label1">284001</asp:Label></h3>
                </div>
                <div class="col-md-1">
                    <h3><a href="#" style="text-decoration: none; color: blue;"><b>Change</b></a></h3>
                </div>
            </div>

            <div class="checkout-right">
                <table class="timetable_sub">
                    <asp:Repeater runat="server" ID="rep_cart" OnItemCommand="rep_cart_ItemCommand">
                        <HeaderTemplate>
                            <tr style="background-color: #a59f9f;">
                                <th>Product</th>
                                <th>Product Name</th>
                                <th>Price</th>
                                <th>Quality</th>
                                <th>Total Price</th>
                                <th>Remove</th>
                            </tr>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr class="rem1">
                                            <asp:HiddenField runat="server" ID="hidden_cartid" Value='<%#Eval("AddCart_ID") %>' />
                                <asp:HiddenField runat="server" ID="Hidden_CustomerID" Value='<%#Eval("CustomerID") %>' />
                                <asp:HiddenField runat="server" ID="Hidden_ProductID" Value='<%#Eval("ProductID") %>' />
                                <td class="invert-image"><a href="single.html">
                                    <img src='<%# "images/Product/small/"+ Eval("ImageUrl") %>' alt="" width="50px" height="50px" class="img-responsive" />
                                </a></td>
                                <td class="invert"><%#Eval("Title")%> </td>
                                <td class="invert"><span class="WebRupee">
                                    <img src="images/inr.png" alt="" style="float: left;" />
                                </span><%#Eval("Total_Amount") %></td>
                                <td class="invert">
                                    <asp:TextBox ID="txt_Qty" runat="server" Text='<%#Eval("Quantity") %>'  ToolTip="enter more quantity"
                                        MaxLength="2" Style="border: solid 1px #cfcfcf; width: 25px;"></asp:TextBox>
                                    <cc2:FilteredTextBoxExtender ID="txt_Qty_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txt_Qty">
                                    </cc2:FilteredTextBoxExtender>

                                    <asp:ImageButton ID="imgbtn_update" runat="server" Width="20px" Height="20px" ImageUrl="~/images/add.png"
                                        CommandArgument='<%#Eval("ProductID") %>' CommandName="update" ToolTip="ADD" />
                                    
                                </td>
                                <td class="invert"><span class="WebRupee">
                                    <img src="images/inr.png" alt="" style="float: left;" /></span>
                                    <%# Convert.ToDouble(Eval("Total_Amount")) * Convert.ToInt32(Eval("Quantity"))%>
                                    
                                </td>
                                <td class="invert">
                                    <div class="rem">
                                        <div class="">
                                            <asp:ImageButton ID="img_delete" runat="server" ImageUrl="~/Images/delete_cart.gif"
                                                OnClientClick="return confirm('Are you sure want to remove this item from Cart?')"
                                                CommandArgument='<%#Eval("AddCart_Id") %>' CommandName="delete" ToolTip="Remove Product" />
                                        </div>
                                    </div>

                                </td>
                            </tr>

                        </ItemTemplate>

                    </asp:Repeater>
                </table>
            </div>
            <!--Continue PAyment-->
            <div class="container">
                <div class="row">
                    <div class="col-lg-6">
                        <div style="margin-right: 330px; margin-top: 90px;">
                            <div class="blank">
                                <div class="total">
                                    <ul>
                                        <li class="last"><span class="text"><strong>Grand Total - </strong></span><span class="number"><span
                                            class="WebRupee">
                                            <img src="images/inr.png" alt="" style="float: left;" />&nbsp;</span><asp:Label ID="lbl_total" runat="server"></asp:Label>
                                        </span></li>
                                        <%--  <li class="last"><span class="text"><strong>Total Weight</strong></span><span class="number"><span
                                    class="WebRupee">Kg&nbsp;</span><asp:Label ID="lbl_totalweight" runat="server"></asp:Label>
                                </span></li>--%>
                                    </ul>
                                </div>
                                <div class="clear">
                                </div>
                                <%-- <div class="right">
                            <div style="margin: 15px 0 0 0;">
                            <span style="text-align:right;color:#000;font-size:12px;"> * Shipping Charges Extra</span>
                                <br />
                                
                                <a onclick="pop('ParcelAPI.aspx?weight=<%=lbl_totalweight.Text%>')" style="text-align: right;
                                    font-weight: bold; font-size: 14px;cursor:pointer;">Calculate Shipping Charges</a>
                              
                            </div>
                        </div>--%>
                                <%--<a href="ParcelAPI.aspx?weight=<%=lbl_totalweight.Text%>"
                                    title="My Shopping Club Store" rel="gb_page_center[420,650]" style="text-align: right;
                                    font-weight: bold; font-size: 14px;">Calculate Shipping Charges</a>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3">
                        <div class="checkout-right-basket">

                            <a href="Userhome.aspx"><span class="glyphicon glyphicon-menu-left" aria-hidden="true"></span>Continue Shopping</a>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="checkout-right-basket">
                            &nbsp &nbsp<a href="CompleteOrder.aspx"><span class="glyphicon glyphicon-menu-right" aria-hidden="true"></span>Place Order</a>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>



    <!-- //checkout -->
</asp:Content>

