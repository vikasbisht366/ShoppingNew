<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ViewAll_Product.aspx.cs" Inherits="ViewAll_Product" %>

<%@ Register Src="UC/Slider.ascx" TagName="Slider" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<asp:Label runat="server" ID="hidden_BrandID" CssClass="hidden"></asp:Label>
    <asp:HiddenField runat="server" ID="hiddenID" />

    <div style="background-color: #f0f0f0;margin-top:-20px;">
        <asp:Repeater runat="server" ID="Brand_Details_Repeater">
            <ItemTemplate>
                <span style="font-size:25px;margin-left:30px;">
                <asp:Label runat="server" ID="LABEL_brandName" Text='<%#Eval("BrandName")%>'></asp:Label></span>
                <br />
                <br />
               <span style="font-size:10px;color:#808080 ;margin-left:30px;"> <asp:Label runat="server" ID="brand_Discription" Text='<%#Eval("Description")%>'></asp:Label></span>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
        <div class="container-fluid" style="background-color: white; width: 98%;">
            <div class="row" style="border-bottom: 1px solid #eae3e3; font-size: 20px; border-top: 1px solid #eae3e3;">
                <br />
                <div class="col-md-10" style="margin-left: 20px;">
                    <asp:Label runat="server" ID="Label3"> <b> Letest Product</b></asp:Label>
                    <br />
                    <br />
                </div>
                <div class="col-md-2" style="float: right; margin-top: -58px;">
                    <a href="All_Product.aspx?lid=newUrl">
                        <span style="background-color:#337ab7;color:white;padding:10px;">View All</span></a>
<%--                <script>
                        $(document).ready(function () {

        $('.pageNum').live('keyup', function (e) {
            e.preventDefault();
            if (e.which == 13) {

                var currentUrl = window.location.href;

                var parsedUrl = $.url(currentUrl);

                var currentPageNum = parsedUrl.param('page');

                var newPageNum = $(this).val();

                var newUrl = //

                window.location.href = newUrl;

            }
        });

    });</script>--%>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row" style="border-bottom: 1px solid #eae3e3; box-shadow: 0px 1px #eae3e3;">
                <br />
                <%--  <div class="product" align="center">
                    <asp:Repeater ID="Repeater_Letest" runat="server">
                        <ItemTemplate>
                                                        <div class="product" style="float: right; margin-left: 20px; margin-right: 5px;">
                                <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">

                                    <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                        alt="" id="pimg" runat="server" />

                                </div>
                                <br />
                                <p class="productname">
                                    <a href='Item_Details.aspx?id=<%#Eval("ProductID") %>'>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                                    </a>
                                </p>
                                <div class="left">
                                    <span>
                                        <img src="images/inr.png" alt="" />
                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" Style="display: none;"></asp:Label>
                                </div>
                                <br />
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>--%>
                <div role="tabpanel" class="tab-pane fade active in" id="home" aria-labelledby="home-tab">
                    <div class="agile_ecommerce_tabs">
                        <asp:Repeater ID="repFeaturedProducts" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3 agile_ecommerce_tab_left">
                                    <div class="hs-wrapper">
                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimgs" runat="server" />
                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img1" runat="server" />
                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img2" runat="server" />
                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img3" runat="server" />
                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img4" runat="server" />
                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img5" runat="server" />

                                        <div class="w3_hs_bottom">
                                            <ul>
                                                <li>
                                                    <a href="#" data-toggle="modal" data-target="#myModal<%# Eval ("ProductID") %>"><span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span></a>
                                                </li>
                                            </ul>
                                        </div>
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
                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="modal video-modal fade" id="myModal<%# Eval ("ProductID") %>" tabindex="-1" role="dialog" aria-labelledby="myModal">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            </div>
                                            <section>
                                                <div class="modal-body">
                                                    <div class="col-md-5 modal_body_left">
                                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimg" runat="server" />
                                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img11" runat="server" />
                                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img12" runat="server" />
                                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img13" runat="server" />
                                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img14" runat="server" />
                                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img15" runat="server" />

                                                    </div>
                                                    <div class="col-md-7 modal_body_right">
                                                        <h4>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Title")%>'></asp:Label></h4>
                                                        <p>
                                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label></h4>
                                                        </p>
                                                        <div class="rating">
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="modal_body_right_cart simpleCart_shelfItem">
                                                            <p>
                                                                <i class="item_price"></i><span>
                                                                    <img src="images/inr.png" alt="" />
                                                                    <asp:Label ID="Label4" runat="server" src="images/inr.png" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                                            </p>
                                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                                        </div>
                                                        <h5>Color</h5>
                                                        <div class="color-quality">
                                                            <ul>
                                                                <li><a href="#"><span></span>Red</a></li>
                                                                <li><a href="#" class="brown"><span></span>Yellow</a></li>
                                                                <li><a href="#" class="purple"><span></span>Purple</a></li>
                                                                <li><a href="#" class="gray"><span></span>Violet</a></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </section>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>

        </div>

        <br />
        <br />
        <div class="container-fluid" style="background-color: white; width: 98%;">
            <div class="row" style="border-bottom: 1px solid #eae3e3; font-size: 20px; border-top: 1px solid #eae3e3;">
                <br />
                <div class="col-md-10" style="margin-left: 20px;">
                    <asp:Label runat="server" ID="Label2"> <b> Budget Product</b></asp:Label>
                    <br />
                    <br />
                </div>
                <div class="col-md-2" style="float: right; margin-top: -58px;">
                    <a href="All_Product.aspx?id=<%#Eval("BrandID")%>">
                         <span style="background-color:#337ab7;color:white;padding:10px;">View All</span></a>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row" style="border-bottom: 1px solid #eae3e3; box-shadow: 0px 1px #eae3e3;">
                <br />
                <%-- <div class="product" align="center">
                    <asp:Repeater ID="Repeater_Budget" runat="server">
                        <ItemTemplate>
                            <div class="product" style="float: right; margin-left: 20px; margin-right: 5px;">
                                <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                                    <a href='Item_Details.aspx?id=<%#Eval("ProductID") %>'>
                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                            alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                                    </a>
                                </div>
                                <br />
                                <p class="productname">
                                    <a href='Item_Details.aspx?id=<%#Eval("ProductID") %>'>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label></a>
                                </p>
                                <div class="left">
                                    <span>
                                        <img src="images/inr.png" alt="" />
                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" Style="display: none;"></asp:Label>
                                </div>

                                <br />

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>--%>
                <div role="tabpanel" class="tab-pane fade active in" id="home" aria-labelledby="home-tab">
                    <div class="agile_ecommerce_tabs">
                        <asp:Repeater ID="Repeater_Budget" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3 agile_ecommerce_tab_left">
                                    <div class="hs-wrapper">
                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimgs" runat="server" />
                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img1" runat="server" />
                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img2" runat="server" />
                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img3" runat="server" />
                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img4" runat="server" />
                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img5" runat="server" />

                                        <div class="w3_hs_bottom">
                                            <ul>
                                                <li>
                                                    <a href="#" data-toggle="modal" data-target="#myModal2<%# Eval ("ProductID") %>"><span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span></a>
                                                </li>
                                            </ul>
                                        </div>
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
                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="modal video-modal fade" id="myModal2<%# Eval ("ProductID") %>" tabindex="-1" role="dialog" aria-labelledby="myModal2">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            </div>
                                            <section>
                                                <div class="modal-body">
                                                    <div class="col-md-5 modal_body_left">
                                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimg" runat="server" />
                                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img11" runat="server" />
                                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img12" runat="server" />
                                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img13" runat="server" />
                                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img14" runat="server" />
                                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img15" runat="server" />

                                                    </div>
                                                    <div class="col-md-7 modal_body_right">
                                                        <h4>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Title")%>'></asp:Label></h4>
                                                        <p>
                                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label></h4>
                                                        </p>
                                                        <div class="rating">
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="modal_body_right_cart simpleCart_shelfItem">
                                                            <p>
                                                                <i class="item_price"></i><span>
                                                                    <img src="images/inr.png" alt="" />
                                                                    <asp:Label ID="Label4" runat="server" src="images/inr.png" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                                            </p>
                                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                                        </div>
                                                        <h5>Color</h5>
                                                        <div class="color-quality">
                                                            <ul>
                                                                <li><a href="#"><span></span>Red</a></li>
                                                                <li><a href="#" class="brown"><span></span>Yellow</a></li>
                                                                <li><a href="#" class="purple"><span></span>Purple</a></li>
                                                                <li><a href="#" class="gray"><span></span>Violet</a></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </section>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>

        </div>

        <br />
        <br />
        <div class="container-fluid" style="background-color: white; width: 98%;">
            <div class="row" style="border-bottom: 1px solid #eae3e3; font-size: 20px; border-top: 1px solid #eae3e3;">
                <br />
                <div class="col-md-10" style="margin-left: 20px;">
                    <asp:Label runat="server" ID="Label1"> <b> Top Product </b></asp:Label>
                    <br />
                    <br />
                </div>
                <div class="col-md-2" style="float: right; margin-top: -58px;">
                    <a href="All_Product.aspx?id=<%#Eval("BrandID")%>">
                        <span style="background-color:#337ab7;color:white;padding:10px;">View All</span></a>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row" style="border-bottom: 1px solid #eae3e3; box-shadow: 0px 1px #eae3e3;">
                <br />
                <%-- <div class="product" align="center">
                    <asp:Repeater ID="Repeater_Top" runat="server">
                        <ItemTemplate>
                            <div class="product" style="float: right; margin-left: 20px; margin-right: 5px;">
                                <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                                    <a href='Item_Details.aspx?id=<%#Eval("ProductID") %>'>
                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                            alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                                    </a>
                                </div>
                                <br />
                                <p class="productname">
                                    <a href='Item_Details.aspx?id=<%#Eval("ProductID") %>'>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label></a>
                                </p>
                                <div class="left">
                                    <span>
                                        <img src="images/inr.png" alt="" />
                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" Style="display: none;"></asp:Label>
                                </div>


                                <br />

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>--%>
                <div role="tabpanel" class="tab-pane fade active in" id="home" aria-labelledby="home-tab">
                    <div class="agile_ecommerce_tabs">
                        <asp:Repeater ID="Repeater_Top" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3 agile_ecommerce_tab_left">
                                    <div class="hs-wrapper">
                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimgs" runat="server" />
                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img1" runat="server" />
                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img2" runat="server" />
                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img3" runat="server" />
                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img4" runat="server" />
                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img5" runat="server" />

                                        <div class="w3_hs_bottom">
                                            <ul>
                                                <li>
                                                    <a href="#" data-toggle="modal" data-target="#myModal3<%# Eval ("ProductID") %>"><span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span></a>
                                                </li>
                                            </ul>
                                        </div>
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
                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="modal video-modal fade" id="myModal3<%# Eval ("ProductID") %>" tabindex="-1" role="dialog" aria-labelledby="myModal3">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            </div>
                                            <section>
                                                <div class="modal-body">
                                                    <div class="col-md-5 modal_body_left">
                                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimg" runat="server" />
                                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img11" runat="server" />
                                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img12" runat="server" />
                                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img13" runat="server" />
                                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img14" runat="server" />
                                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img15" runat="server" />

                                                    </div>
                                                    <div class="col-md-7 modal_body_right">
                                                        <h4>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Title")%>'></asp:Label></h4>
                                                        <p>
                                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label></h4>
                                                        </p>
                                                        <div class="rating">
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="modal_body_right_cart simpleCart_shelfItem">
                                                            <p>
                                                                <i class="item_price"></i><span>
                                                                    <img src="images/inr.png" alt="" />
                                                                    <asp:Label ID="Label4" runat="server" src="images/inr.png" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                                            </p>
                                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                                        </div>
                                                        <h5>Color</h5>
                                                        <div class="color-quality">
                                                            <ul>
                                                                <li><a href="#"><span></span>Red</a></li>
                                                                <li><a href="#" class="brown"><span></span>Yellow</a></li>
                                                                <li><a href="#" class="purple"><span></span>Purple</a></li>
                                                                <li><a href="#" class="gray"><span></span>Violet</a></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </section>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>

        </div>
        <br />
        <br />
        <div class="container-fluid" style="background-color: white; width: 98%;">
            <div class="row" style="border-bottom: 1px solid #eae3e3; font-size: 20px; border-top: 1px solid #eae3e3;">
                <br />
                <div class="col-md-10" style="margin-left: 20px;">
                    <asp:Label runat="server" ID="Label5"> <b> Product under ₹20K</b></asp:Label>
                    <br />
                    <br />
                </div>
                <div class="col-md-2" style="float: right; margin-top: -58px;">
                    <a href="All_Product.aspx?id=<%#Eval("BrandID")%>">
                         <span style="background-color:#337ab7;color:white;padding:10px;">View All</span></a>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row" style="border-bottom: 1px solid #eae3e3; box-shadow: 0px 1px #eae3e3;">
                <br />
                <%--  <div class="product" align="center">
                    <asp:Repeater ID="Repeater_under_20K" runat="server">
                        <ItemTemplate>
                            <div class="product" style="float: right; margin-left: 20px; margin-right: 5px;">
                                <div class="highslide-gallery productimage" style="position: relative; z-index: 50;">
                                    <a href='Item_Details.aspx?id=<%#Eval("ProductID") %>'>
                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' width="156" height="149"
                                            alt=' <%#Eval("Title")%>' id="pimg" runat="server" />
                                    </a>
                                </div>
                                <br />
                                <p class="productname">
                                    <a href='Item_Details.aspx?id=<%#Eval("ProductID") %>'>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                                </p>
                                <div class="left">
                                    <span>
                                        <img src="images/inr.png" alt="" />
                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" Style="display: none;"></asp:Label>
                                </div>

                                <br />

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>--%>
                <div role="tabpanel" class="tab-pane fade active in" id="home" aria-labelledby="home-tab">
                    <div class="agile_ecommerce_tabs">
                        <asp:Repeater ID="Repeater_under_20K" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3 agile_ecommerce_tab_left">
                                    <div class="hs-wrapper">
                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimgs" runat="server" />
                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img1" runat="server" />
                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img2" runat="server" />
                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img3" runat="server" />
                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img4" runat="server" />
                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img5" runat="server" />

                                        <div class="w3_hs_bottom">
                                            <ul>
                                                <li>
                                                    <a href="#" data-toggle="modal" data-target="#myModal4<%# Eval ("ProductID") %>"><span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span></a>
                                                </li>
                                            </ul>
                                        </div>
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
                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="modal video-modal fade" id="myModal4<%# Eval ("ProductID") %>" tabindex="-1" role="dialog" aria-labelledby="myModal4">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            </div>
                                            <section>
                                                <div class="modal-body">
                                                    <div class="col-md-5 modal_body_left">
                                                        <img src='<%# "images/Product/medium/"+ Eval("ImageUrl") %>' alt='<%#Eval("Title")%>' id="pimg" runat="server" />
                                                        <img src='<%# "images/Product/medium/1/"+ Eval("Image1") %>' alt='<%#Eval("Title")%>' id="Img11" runat="server" />
                                                        <img src='<%# "images/Product/medium/2/"+ Eval("Image2") %>' alt='<%#Eval("Title")%>' id="Img12" runat="server" />
                                                        <img src='<%# "images/Product/medium/3/"+ Eval("Image3") %>' alt='<%#Eval("Title")%>' id="Img13" runat="server" />
                                                        <img src='<%# "images/Product/medium/4/"+ Eval("Image4") %>' alt='<%#Eval("Title")%>' id="Img14" runat="server" />
                                                        <img src='<%# "images/Product/medium/5/"+ Eval("Image5") %>' alt='<%#Eval("Title")%>' id="Img15" runat="server" />

                                                    </div>
                                                    <div class="col-md-7 modal_body_right">
                                                        <h4>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Title")%>'></asp:Label></h4>
                                                        <p>
                                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label></h4>
                                                        </p>
                                                        <div class="rating">
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star-.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="rating-left">
                                                                <img src="web/images/star.png" alt=" " class="img-responsive" />
                                                            </div>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="modal_body_right_cart simpleCart_shelfItem">
                                                            <p>
                                                                <i class="item_price"></i><span>
                                                                    <img src="images/inr.png" alt="" />
                                                                    <asp:Label ID="Label4" runat="server" src="images/inr.png" Text='<%#Eval("Price")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                                            </p>
                                                            <p><a class="item_add" href="Item_Details.aspx?id=<%#Eval("ProductID") %>">View Product</a></p>
                                                        </div>
                                                        <h5>Color</h5>
                                                        <div class="color-quality">
                                                            <ul>
                                                                <li><a href="#"><span></span>Red</a></li>
                                                                <li><a href="#" class="brown"><span></span>Yellow</a></li>
                                                                <li><a href="#" class="purple"><span></span>Purple</a></li>
                                                                <li><a href="#" class="gray"><span></span>Violet</a></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </section>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>

        </div>
        <br />
        <br />
    </div>
</asp:Content>

