<%@ Page Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true" CodeFile="ShoppingBag.aspx.cs"
    Inherits="ShoppingBag" %>

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

  <%--  <script type="text/javascript" src="static_files/help.js"></script>

    <script type="text/javascript" src="greybox/AJS.js"></script>

    <script type="text/javascript" src="greybox/AJS_fx.js"></script>

    <script type="text/javascript" src="greybox/gb_scripts.js"></script>

    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />--%>
    <%-- <link href="static_files/help.css" rel="stylesheet" type="text/css" media="all" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<h2 class="heading"> Shopping Cart</h2>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
          
     
                <div class="shoppingcart">
                    <!--heading-->
                    <div class="shopping_heading">
                        <div class="left">
                            <h4 class="pageheading">
                                Shopping Cart</h4>
                        </div>
                        <div class="right">
                     <a href="CheckOut.aspx">
                      <%--    <a href="CheckOut.aspx" rel="gb_page_center[730, 440]" title="Checkout">--%>
                                <img src="images/proceedto-checkout.png" hspace="10" border="0" alt=""/></a><a href="Product.aspx"><img
                                    src="images/shopingcontinure.png" border="0" alt=""/></a></div>
                    </div>
                    <!--heading-->
                    <!--car list-->
                    <div class="cartlist">
                      
                        <asp:Repeater ID="rep_cart" runat="server" OnItemCommand="rep_cart_ItemCommand">
                        <HeaderTemplate>
                          <ul class="cartlisthead">
                            <li class="product_image">Picture </li>
                            <li class="prduct_name">Product Name </li>
                          <%--  <li class="unit_price">Unit Weight</li>--%>
                            <li class="unit_price">Unit Price</li>
                            <li class="qty">QTY</li>
                            <li class="subtotalt">Sub Total</li>
                            <li class="close">&nbsp; </li>
                        </ul>
                        </HeaderTemplate>

                            <ItemTemplate>
                                <ul class="cartlisting">
                                    <li class="product_image">
                                        <img src='<%# "images/Product/small/"+ Eval("ImageUrl") %>' alt="" width="50px" height="50px" /></li>
                                    <li class="prduct_name txtpad">
                                        <%#Eval("ProductName")%></li>
                                        <%--  <li class="unit_price txtpad"><%#Eval("PWeight") %><asp:HiddenField
                                        ID="hidWeight" runat="server" Value='<%#Eval("weight") %>' />
                                    </li>--%>
                                    <li class="unit_price txtpad"><span class="WebRupee">
                                     <img src="images/inr.png" alt="" style="float:left;" />
                   
                                   </span><%#Eval("price") %></li>
                                  
                                    <li class="qty">
                                        <asp:TextBox ID="txt_Qty" runat="server" Text='<%#Eval("Quantity") %>' ToolTip="enter more quantity"
                                            MaxLength="2" style="border:solid 1px #cfcfcf;"></asp:TextBox>
                                        <cc2:FilteredTextBoxExtender ID="txt_Qty_FilteredTextBoxExtender" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="txt_Qty">
                                        </cc2:FilteredTextBoxExtender>
                                        <asp:ImageButton ID="imgbtn_update" runat="server" Width="15px" Height="15px" ImageUrl="~/images/add.png"
                                            CommandArgument='<%#Eval("ProductID") %>' CommandName="update" ToolTip="ADD" />
                                    </li>
                                    <li class="subtotalt txtpad"><span class="WebRupee"> <img src="images/inr.png" alt="" style="float:left;" /></span><%# Convert.ToDouble(Eval("price")) * Convert.ToInt32(Eval("Quantity"))%><%--<asp:HiddenField ID="hidweighttotal" runat="server" Value='<%# Convert.ToDouble(Eval("weight")) * Convert.ToInt32(Eval("Quantity"))%>' />--%></li>
                                    <li class="close txtpad">
                                        <asp:ImageButton ID="img_delete" runat="server" ImageUrl="~/Images/delete_cart.gif"
                                            OnClientClick="return confirm('Are you sure want to remove this item from shopping bag?')"
                                            CommandArgument='<%#Eval("ProductID") %>' CommandName="delete" ToolTip="Remove Product" /></li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!--car list-->
                    <!--cart total-->
                    <div class="blank">
                        <div class="total">
                            <ul>
                                <li class="last"><span class="text"><strong>*Grand Total</strong></span><span class="number"><span
                                    class="WebRupee"> <img src="images/inr.png" alt="" style="float:left;" />&nbsp;</span><asp:Label ID="lbl_total" runat="server"></asp:Label>
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
                    <!--cart total-->
                </div>
          
        </ContentTemplate>
    </asp:UpdatePanel>


 <%--   <div style="float:right; width: 215px; margin-top: 20px;">
                    
                        <div class="checkout"><a href="checkout.html" class="more">Proceed to Checkout</a></div>
                        <div class="cleaner h20"></div>
                        <div class="continueshopping"><a href="javascript:history.back()" class="more">Continue Shopping</a></div>
                    	
                    </div>--%>
</asp:Content>
