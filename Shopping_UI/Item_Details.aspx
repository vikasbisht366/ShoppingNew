<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Item_Details.aspx.cs" Inherits="Item_Details" %>

<%@ Register Src="UC/Slider.ascx" TagName="Slider" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="web/popup%20box/css/style.css" rel="stylesheet" />
    <script src="web/popup%20box/js/bootstrap.js"></script>
    <script src="web/popup%20box/js/jquery-1.11.1.min.js"></script>

    <script src="web/popup%20box/js/jquery.flexslider.js"></script>
    <link href="web/popup%20box/css/flexslider.css" rel="stylesheet" />
    <script>
        // Can also be used with $(document).ready()
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                controlNav: "thumbnails"
            });
        });
    </script>

    <script src="web/popup%20box/js/imagezoom.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="products">
        <div class="container">
            <div class="single-page">
                <div class="single-page-row" id="detail-21">
                    <asp:Repeater runat="server" ID="reponeitemdetails" OnItemCommand="reponeitemdetails_ItemCommand">
                        <ItemTemplate>
                            <div class="col-md-6 single-top-left">
                                <div class="flexslider">
                                    <br />
                                    <ul class="slides">
                                        <li data-thumb="<%# "images/Product/medium/"+ Eval("ImageUrl") %>">
                                            <div class="thumb-image detail_images">
                                                <img src='<%# "images/Product/actual/"+ Eval("ImageUrl") %>' data-imagezoom="true" id="pimg" class="img-responsive" alt="<%#Eval("Title")%>" />
                                                <asp:HiddenField runat="server" ID="hidden_pimg" Value='<%#Eval("ImageUrl") %>' />
                                            </div>
                                        </li>
                                        <li data-thumb="<%# "images/Product/medium/1/"+ Eval("Image1") %>">
                                            <div class="thumb-image">
                                                <img src="<%# "images/Product/actual/1/"+ Eval("Image1") %>" data-imagezoom="true" class="img-responsive" alt="<%#Eval("Title")%>" />
                                            </div>
                                        </li>
                                       <%-- <li data-thumb="<%# "images/Product/medium/2/"+ Eval("Image2") %>">
                                            <div class="thumb-image">
                                                <img src="<%# "images/Product/actual/2/"+ Eval("Image2") %>" data-imagezoom="true" class="img-responsive" alt="<%#Eval("Title")%>" />
                                            </div>
                                        </li>
                                        <li data-thumb="<%# "images/Product/medium/3/"+ Eval("Image3") %>">
                                            <div class="thumb-image">
                                                <img src="<%# "images/Product/actual/3/"+ Eval("Image3") %>" data-imagezoom="true" class="img-responsive" alt="<%#Eval("Title")%>" />
                                            </div>
                                        </li>
                                        <li data-thumb="<%# "images/Product/medium/4/"+ Eval("Image4") %>">
                                            <div class="thumb-image">
                                                <img src="<%# "images/Product/actual/4/"+ Eval("Image4") %>" data-imagezoom="true" class="img-responsive" alt="<%#Eval("Title")%>" />
                                            </div>
                                        </li>
                                        <li data-thumb="<%# "images/Product/medium/5/"+ Eval("Image5") %>">
                                            <div class="thumb-image">
                                                <img src="<%# "images/Product/actual/5/"+ Eval("Image5") %>" data-imagezoom="true" class="img-responsive" alt="<%#Eval("Title")%>" />
                                            </div>
                                        </li>--%>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-6 single-top-right">
                                <h3 class="item_name">
                                    <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label></h3>
                                <p>Processing Time: Item will be shipped out within 2-3 working days. </p>
                                <div class="single-rating">
                                    <ul>
                                        <li><i class="glyphicon glyphicon-star" aria-hidden="true"></i></li>
                                        <li><i class="glyphicon glyphicon-star" aria-hidden="true"></i></li>
                                        <li><i class="glyphicon glyphicon-star" aria-hidden="true"></i></li>
                                        <li><i class="glyphicon glyphicon-star" aria-hidden="true"></i></li>
                                        <li><i class="glyphicon glyphicon-star" aria-hidden="true"></i></li>
                                        <li class="rating">20 reviews</li>
                                        <li><a href="#">Add your review</a></li>
                                    </ul>
                                </div>
                                <div class="single-price">
                                    <ul>
                                        <li><span>
                                            <img src="images/inr.png" alt="" />
                                            <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Total_Amount")%>' CssClass="amount" Style="font-weight: bold;"></asp:Label></span>
                                            <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight")%>' CssClass="off" Style="display: none;"></asp:Label></li>
                                        <li><del><%#Eval("Price") %> </del></li>
                                        <li><span class="w3off"><%#Eval("Discount") %> % OFF</span></li>
                                        <%--<li>Ends on: Oct,15th</li>--%>
                                        <%--<li><a href="#"><i class="glyphicon glyphicon-gift" aria-hidden="true"></i>Coupon</a></li>--%>
                                    </ul>
                                </div>

                               <%-- <p class="single-price-text"><%#Eval("Description") %> </p>--%>

                                <asp:HiddenField runat="server" ID="hidden_ProductID" />
                                <asp:Button runat="server" class="w3ls-cart" ID="btn_Addtocart" Text="Add To Cart" Font-Bold="true" CommandArgument='<%#Eval("ProductID") %>'
                                    CommandName="AddToCart" AlternateText='<%# Convert.ToBoolean(Eval("IsStock")) == true ? "Add To Cart" : "Out of Stock" %>'
                                    Enabled='<%# Convert.ToBoolean(Eval("IsStock")) == true ? true : false %>' />

                                <button class="w3ls-cart w3ls-cart-like"><i class="glyphicon glyphicon-heart" aria-hidden="true"></i>Add to Wishlist</button>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:HiddenField runat="server" ID="hidden_CartID" />
                    <asp:HiddenField runat="server" ID="hidden_Quantity" />
                    
                    <div class="clearfix"></div>
                </div>
            </div>

            <br />
            <br />
            <!-- collapse-tabs -->
            <div class="collpse tabs">
                <h2 align="center"><b>About this item</b></h2>
                <br />
                <br />

                <div class="panel-group collpse" id="accordion" role="tablist" aria-multiselectable="true">
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingOne">
                            <h4 class="panel-title">
                                <a class="pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" <%--href="#collapseOne"--%> aria-expanded="true" aria-controls="collapseOne">
                                    <i class="fa fa-file-text-o fa-icon" aria-hidden="true"></i>Description <span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                            <div class="panel-body">
                             <asp:Label runat="server" ID="labelDescription"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <%--<div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingTwo">
                            <h4 class="panel-title">
                                <a class="collapsed pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                    <i class="fa fa-info-circle fa-icon" aria-hidden="true"></i>additional information <span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                            <div class="panel-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingThree">
                            <h4 class="panel-title">
                                <a class="collapsed pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                    <i class="fa fa-check-square-o fa-icon" aria-hidden="true"></i>reviews (5) <span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                            <div class="panel-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingFour">
                            <h4 class="panel-title">
                                <a class="collapsed pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                                    <i class="fa fa-question-circle fa-icon" aria-hidden="true"></i>help <span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseFour" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingFour">
                            <div class="panel-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
                        </div>
                    </div>--%>
                </div>
                <br />
            </div>
            <!-- //collapse -->
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hidden_ProductID" />
    <!-- cart-js -->

    <script src="web/popup%20box/js/minicart.js"></script>
    <script>
        w3ls1.render();

        w3ls1.cart.on('w3sb1_checkout', function (evt) {
            var items, len, i;

            if (this.subtotal() > 0) {
                items = this.items();

                for (i = 0, len = items.length; i < len; i++) {
                    items[i].set('shipping', 0);
                    items[i].set('shipping2', 0);
                }
            }
        });
    </script>
    <!-- //cart-js -->
</asp:Content>

