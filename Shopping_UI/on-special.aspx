<%@ Page Title="" Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true" CodeFile="on-special.aspx.cs" Inherits="on_special" %>


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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="middlepart">
        <h2 class="heading">
    <asp:Literal ID="litPageHeading" runat="server"></asp:Literal></h2>
        <!--product subcategory Description start-->
        <p style="text-align: justify;">
           <asp:Literal ID="litPageDesc" runat="server" ></asp:Literal></p><br /><br />
        <!--product start-->
        <asp:DataList ID="repProducts" runat="server" RepeatColumns="4" OnItemCommand="repProducts_ItemCommand">
            <ItemTemplate>
                <div class="product">
                    <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                        <a id="thumb1" href='<%# "images/Product/actual/"+ Eval("ImageUrl") %>' class="highslide"
                            onclick="return hs.expand(this);">
                            <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="176" height="169"
                                alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                        </a>
                    </div>
                    <p class="productname">
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                    </p>
                    <div class="left">$<del style="font-weight:bold;"><%#Eval("OnSaleDiscount")%></del> |
                       
                        $ <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" style="font-weight:bold;font-size:14px;"></asp:Label>|
                        <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off"></asp:Label> 
                    </div>
                    <div class="right">
                     <a onclick="pop('ProjectDescription.aspx?pid=<%#Eval("ProductID")%>')" style="cursor:pointer;"> <span>
                         <img src="Images/description1.png" alt=""/> </a>
                        <asp:ImageButton ID="lnkbtn_addtocart" runat="server" CommandArgument='<%#Eval("ProductID") %>'
                            CommandName="AddToCart" ImageUrl="images/addtocart.jpg" AlternateText="Add To Cart" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div style="margin: 10px;">
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

