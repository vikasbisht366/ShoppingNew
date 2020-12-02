<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="All_Product.aspx.cs" Inherits="All_Product" %>

<%@ Register Src="UC/Slider.ascx" TagName="Slider" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="container-fluid" style="background-color:#f0f0f0;margin-top:-20px;">
        <asp:HiddenField runat="server" ID="HiddenfieldSubCategoey" />
         <asp:HiddenField runat="server" ID="HiddenField_Brand" />
            <div class="row" style="margin-top:10px;">
               
                <div style="background-color:white;">
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
                    <br />
                </div>
            </div>
       <br />
         <br />
    </div>
</asp:Content>

