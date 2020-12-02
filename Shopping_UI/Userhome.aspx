<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Userhome.aspx.cs" Inherits="Userhome" %>

<%@ Register Src="UC/Slider.ascx" TagName="Slider" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <!-- //banner -->
    <div class="slider">


        <div class="container-fluid">
            <div class="row">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="web/images/banner2.jpg" alt="Los Angeles" style="width: 100%;">
                        </div>

                        <div class="item">
                            <img src="web/images/banner3.jpg" alt="Chicago" style="width: 100%;">
                        </div>

                        <div class="item">
                            <img src="web/images/banner4.jpg" alt="New york" style="width: 100%;">
                        </div>
                    </div>

                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>

        </div>

    </div>



    <!-- marque Tag Header -->
    <div style="color: Red; font-size: 14px; font-weight: bold; margin-top: 10px;">
        <marquee onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="1" direction="left" behavior="scroll">    
                    <asp:Literal ID="litMarqueeText" runat="server"></asp:Literal></marquee>
    </div>
    <!-- marque Tag Header -->
    <!-- banner-bottom -->
    <div class="banner-bottom">

        <div class="col-md-12 wthree_banner_bottom_right">
            <asp:Repeater ID="repFeaturedProducts" runat="server" OnItemCommand="repFeaturedProducts_ItemCommand ">
                <ItemTemplate>
                    <div class="col-md-3 agile_ecommerce_tab_left">
                        <div class="hswrapper">
                            <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimgs" runat="server" />
                        </div>
                        <h5><a href="#">
                            <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label></a>
                        </h5>
                        <div class="simpleCart_shelfItem">
                            <span>
                                <img src="images/inr.png" alt="" />
                                <asp:Label ID="lblPrice" runat="server" src="images/inr.png" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                            <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" Style="display: none;"></asp:Label>
                            <br />
                            <br />
                            <div class="simpleCart_shelfItem">
                                <p><a class="item_add" href="Item_Details.aspx?proid=<%#Eval("ProductID") %>">View Product</a></p>
                            </div>

                        </div>
                    </div>
                  
                </ItemTemplate>
            </asp:Repeater>
            <!--modal-video-->

        </div>
        <div class="clearfix"></div>

    </div>
 
    <!-- newsletter -->

</asp:Content>

