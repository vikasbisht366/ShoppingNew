<%@ Page Title="" Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true"
    CodeFile="Product.aspx.cs" Inherits="Product" %>

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
    <div class="middlepart">
        <h2 class="heading">
            <asp:Label ID="Label1" runat="server"></asp:Label>
            &nbsp;Products
            <%--<div>
             Sort by:
                <asp:DropDownList ID="ddlSortBy" runat="server">
                    <asp:ListItem Value="1">Popularity</asp:ListItem>
                    <asp:ListItem Value="2">Price -- High to Low</asp:ListItem>
                       <asp:ListItem Value="3">Price -- Low to High</asp:ListItem>
                          <asp:ListItem Value="4">Discount</asp:ListItem>
                             <asp:ListItem Value="5">Latest</asp:ListItem>
                               <asp:ListItem Value="5">Featured</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>

            
            </div>--%></h2>
        <!--product subcategory Description start-->
        <p style="text-align: justify; color: Black;">
            <asp:Literal ID="ltrDescription" runat="server"></asp:Literal></p>
        <!--product start-->
        <asp:DataList ID="repProducts" runat="server" RepeatColumns="4" OnItemCommand="repProducts_ItemCommand">
            <ItemTemplate>
                <div class="product">
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
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div style="margin: 10px;display:none;">
            <asp:ImageButton ID="btn_first" runat="server" ImageUrl="~/images/prev.gif" OnClick="btn_first_Click"
                AlternateText="First" ToolTip="First" Style="float: left; margin-right: 20px;" />
            <asp:ImageButton ID="btn_prev" runat="server" ImageUrl="~/images/prev0.gif" OnClick="btn_prev_Click"
                AlternateText="Pre" ToolTip="Previous" Style="display: none; float: left; margin-right: 20px;" />
            <asp:LinkButton ID="btn_firstt" runat="server" OnClick="btn_firstt_Click" Style="color: #fff;
                background-color: #FF0000; padding: 2px 6px 2px 6px; float: left; margin: -2px 5px 5px 5px;"
                Visible="false">1</asp:LinkButton>
            <asp:DataList ID="dlpaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlpaging_ItemCommand"
                OnItemDataBound="dlpaging_ItemDataBound" CssClass="left">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_paging" runat="server" CommandArgument='<%#Eval("PageIndex") %>'
                        CommandName="Paging" Style="color: #fff; background-color: #FF0000; padding: 2px 6px 2px 6px;
                        font-weight: bold;"><%#Eval("PageText") %></asp:LinkButton>&nbsp;&nbsp;
                </ItemTemplate>
            </asp:DataList>
            <asp:ImageButton ID="btn_next" runat="server" ImageUrl="~/images/next0.gif" OnClick="btn_next_Click"
                AlternateText="Next" ToolTip="Next" Style="float: left; margin-left: 20px; display: none;" />
            <asp:ImageButton ID="btn_last" runat="server" ImageUrl="~/images/next.gif" OnClick="btn_last_Click"
                AlternateText="Last" ToolTip="Last" Style="float: left; margin-left: 10px;" />
        </div>
    </div>
     <!--product start-->
</asp:Content>
