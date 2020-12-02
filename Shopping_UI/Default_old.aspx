<%@ Page Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true" CodeFile="Default_old.aspx.cs"
    Inherits="_Default" Title="Untitled Page" %>

<%@ Register Src="UC/Slider.ascx" TagName="Slider" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="highslide/highslide.css" />
    <script type="text/javascript" src="highslide/highslide-with-gallery.js"></script>
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
        .discount
        {
            
    font-weight:bold;
    font-size:14px;
    color:Black;
        }
       .discount span
       {
           width:70px;
           float:left;
       }
    
    
    </style>
   <script type="text/javascript">

       function pop(location) {

           var winWidth = 480;

           var winHeight = 470;

           var posLeft = (screen.width - winWidth) / 2;

           var posTop = (screen.height - winHeight) / 2;

           myWindow = window.open(location, 'My Shopping Club', 'width=' + winWidth + ',height=' + winHeight + ',top=' + posTop + ',left=' + posLeft +

',resizable=yes,scrollbars=yes,toolbar=no,titlebar=no,' +

'location=no,directories=no,status=no,menubar=no,copyhistory=no');



       }
    </script>
  
    <link href="css/product.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="color: Red; font-size: 14px; font-weight: bold;">
        <marquee onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="1"
            direction="left" behavior="scroll">    <asp:Literal ID="litMarqueeText" runat="server"></asp:Literal></marquee>
    </div>
    <iframe src="Slider.aspx" frameborder="0" scrolling="no" width="700" height="220">
    </iframe>
    <div class="clear">
    </div>
    <!--add-->
    <!--featured product-->
    <div class="featuredproduct">
        <h3 class="featuredproductheading">
            <span>Featured Products</span>
        </h3>
        <!--product start-->
        <asp:Repeater ID="repFeaturedProducts" runat="server" OnItemCommand="repFeaturedProducts_ItemCommand">
            <ItemTemplate>
              <div class="product">
                    <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                        <a id="thumb1" href='<%# "images/Product/actual/"+ Eval("ImageUrl") %>' class="highslide"
                            onclick="return hs.expand(this);">
                            <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                        </a>
                    </div>
                    <p class="productname">
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                    </p>
                    <div class="left">
                        <img src="images/inr.png" alt="" style="float:left;" />
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" style="font-weight:bold;"></asp:Label>
                        <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" style="display:none;"></asp:Label>
                    </div>
                    <div class="right">

                     <a onclick="pop('ProjectDescription.aspx?pid=<%#Eval("ProductID")%>')" style="cursor:pointer;">
                      <span>
                       
                                <img src="images/show_description.png" alt="" /> </a>
                        <asp:ImageButton ID="lnkbtn_addtocart" runat="server" CommandArgument='<%#Eval("ProductID") %>'
                            CommandName="AddToCart" ImageUrl='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "images/addtocart.jpg" : "images/OutofStock.jpg" %>'
                            AlternateText='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "Add To Cart" : "Out of Stock" %>'
                            Enabled='<%# Convert.ToBoolean(Eval("IsStock")) == true ? true : false %>' />
                    </div>
                </div>
              <%--  <div class="product">
                    <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                        <a id="thumb1" href='<%# "images/Product/actual/"+ Eval("ImageUrl") %>' class="highslide"
                            onclick="return hs.expand(this);">
                            <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                        </a>
                    </div>
                    <p class="productname">
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                    </p>
                    <p class="discount">
                      <img src="images/inr.png" alt="" style="float:left;"/>
                    <span > <del> 699 </del> </span>
                      <span>30% OFF</span>
                    </p>
                    <div class="left">
                        <img src="images/inr.png" alt="" style="float:left;"/>
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" style="font-size:14px;font-weight:bold;"></asp:Label>
                       


                        <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" style="display:none;"></asp:Label>
                    </div>
                    <div class="right">
                        <a href="ProjectDescription.aspx?pid=<%#Eval("ProductID")%>" style="cursor: pointer;">
                            <span>
                                <img src="images/show_description.png" alt="" /> </a>
                        <asp:ImageButton ID="lnkbtn_addtocart" runat="server" CommandArgument='<%#Eval("ProductID") %>'
                            CommandName="AddToCart" ImageUrl='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "images/addtocart.jpg" : "images/OutofStock.jpg" %>'
                            AlternateText='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "Add To Cart" : "Out of Stock" %>'
                            Enabled='<%# Convert.ToBoolean(Eval("IsStock")) == true ? true : false %>' />
                    </div>
                </div>--%>
            </ItemTemplate>
        </asp:Repeater>
        <!--product start-->
        <div style="float: right;">
            <a href="Product.aspx?fid=1" style="font-weight: bold;">view all..</a>
        </div>
    </div>
    <!--featured product-->
    <!--new product-->
    <div class="featuredproduct">
        <br />
        <h3 class="featuredproductheading">
            <span>New Products</span>
        </h3>
        <!--product start-->
        <asp:Repeater ID="repNewProducts" runat="server" OnItemCommand="repNewProducts_ItemCommand">
            <ItemTemplate>
                <div class="product">
                    <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                        <a id="thumb1" href='<%# "images/Product/actual/"+ Eval("ImageUrl") %>' class="highslide"
                            onclick="return hs.expand(this);">
                            <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                        </a>
                    </div>
                    <p class="productname">
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                    </p>
                    <div class="left">
                       <img src="images/inr.png" alt="" style="float:left;" />
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" style="font-weight:bold;"></asp:Label>
                        <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" style="display:none;"></asp:Label>
                    </div>
                    <div class="right">
                        <a onclick="pop('ProjectDescription.aspx?pid=<%#Eval("ProductID")%>')" style="cursor:pointer;">
                      <span>
                       
                                <img src="images/show_description.png" alt="" /> </a>
                        <asp:ImageButton ID="lnkbtn_addtocart" runat="server" CommandArgument='<%#Eval("ProductID") %>'
                            CommandName="AddToCart" ImageUrl='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "images/addtocart.jpg" : "images/OutofStock.jpg" %>'
                            AlternateText='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "Add To Cart" : "Out of Stock" %>'
                            Enabled='<%# Convert.ToBoolean(Eval("IsStock")) == true ? true : false %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <!--product start-->
        <div class="right">
            <a href="Product.aspx?nid=1" style="font-weight: bold;">view all..</a>
            <br />
        </div>
        </div>
    <!--new product-->

    <!--Popular product-->
    <div class="featuredproduct">
        <br />
        <h3 class="featuredproductheading">
            <span>Popular Products</span>
        </h3>
        <!--product start-->
        <asp:Repeater ID="repPopularProducts" runat="server" OnItemCommand="repPopularProducts_ItemCommand">
            <ItemTemplate>
                <div class="product">
                    <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                        <a id="thumb1" href='<%# "images/Product/actual/"+ Eval("ImageUrl") %>' class="highslide"
                            onclick="return hs.expand(this);">
                            <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                        </a>
                    </div>
                    <p class="productname">
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                    </p>
                    <div class="left">
                        <img src="images/inr.png" alt="" style="float:left;" />
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" style="font-weight:bold;"></asp:Label>
                        <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" style="display:none;"></asp:Label>
                    </div>
                    <div class="right">
                        <a onclick="pop('ProjectDescription.aspx?pid=<%#Eval("ProductID")%>')" style="cursor:pointer;">
                      <span>
                       
                                <img src="images/show_description.png" alt="" /> </a>
                        <asp:ImageButton ID="lnkbtn_addtocart" runat="server" CommandArgument='<%#Eval("ProductID") %>'
                            CommandName="AddToCart" ImageUrl='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "images/addtocart.jpg" : "images/OutofStock.jpg" %>'
                            AlternateText='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "Add To Cart" : "Out of Stock" %>'
                            Enabled='<%# Convert.ToBoolean(Eval("IsStock")) == true ? true : false %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <!--product start-->
        <div class="right">
            <a href="Product.aspx?pid=1" style="font-weight: bold;">view all..</a>
            <br />
        </div>
        </div>
    <!--popular product-->
</asp:Content>
