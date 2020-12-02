<%@ Page Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" Title="" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="css/expandcollaps.css" />
<script type="text/javascript" src="js/jquery-1.4.1.min.js"></script>

<script type="text/javascript">
        animatedcollapse.addDiv('flash-banner', 'fade=0,speed=400,group=pets')


        animatedcollapse.ontoggle = function($, divobj, state) { //fires each time a DIV is expanded/contracted
            //$: Access to jQuery
            //divobj: DOM reference to DIV being expanded/ collapsed. Use "divobj.id" to get its ID
            //state: "block" or "none", depending on state
        }

        animatedcollapse.init()

    </script>
<script type="text/javascript">

            $(document).ready(function() {

                $(".collapse_btn").each(function() {

                   $(this).click(function(event) {

                       $(this).hide();

                       var id = $(this).attr("id").replace("collapse_", "");



                       $("#expand_" + id).show();

                       $("#answer_" + id).slideUp("slow");



                        event.preventDefault();

                   });

                });

                $(".expand_btn").each(function() {

                    $(this).click(function(event) {

                        $(this).hide();

                        var id = $(this).attr("id").replace("expand_", "");



                        $("#collapse_" + id).show();

                        $("#answer_" + id).slideDown("slow");



                        event.preventDefault();

                    });

                });



                $(".back-to-top").each(function() {

                    $(this).click(function() {

                        var id = $(this).attr("id").replace("back_link_", "");

                        $("#collapse_" + id).click();

                    });                    

                });

            })

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="middlepart">
<h2 class="heading">   News</h2>


 <asp:Repeater ID="rptAllEvents" runat="server">
                             <ItemTemplate>
                            <div class="expanddiv">
<div class="tab-quest">

<div class="float-l">
<a name="answer1"></a>
<div class="expandimg"></div> 
    <b><%#Eval("EventName")%> </b> <br />
          <i style="margin-left:20px;"><%#String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(Eval("AddDate")))%></i>  
</div>
<div class="answer display-none"  id='<%# "answer_1"+ Eval("EventID") %>'>
 <p class="item-content"><asp:Literal ID="litEventDesc" runat="server" Text='<%#Eval("EventDesc")%>'></asp:Literal>
 </p>
 </div>
 <div class="float-r"><a href="#" class="expand_btn" id='<%# "expand_1"+ Eval("EventID") %>'><img src="images/expand-btn.png" alt="" width="81" height="20" class="png_bg" /></a><a href="#" class="display-none collapse_btn" id='<%# "collapse_1"+ Eval("EventID") %>'><img src="images/collaps-btn.png" class="png_bg" alt="" /></a> </div>
 <div class="clear"></div>
            </div>
            </div>
         </ItemTemplate>
                        </asp:Repeater>


</div>

    
   
    
</asp:Content>

