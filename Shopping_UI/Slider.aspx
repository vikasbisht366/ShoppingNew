<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Slider.aspx.cs" Inherits="Slider" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- slider -->
<script src="js/jquery-1.4.4.min.js" type="text/javascript"></script>
<script src="js/slides.min.jquery.js" type="text/javascript"></script>
<script>
		$(function(){
			$('#slides').slides({
				preload: true,
				preloadImage: 'img/loading.gif',
				play: 5000,
				pause: 2500,
				hoverPause: true
			});
		});
	</script>
<link rel="stylesheet" href="css/global1.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
     <div id="example">
     <div id="slides">
     <div class="slides_container">
         <asp:Repeater ID="Repeater1" runat="server">
         <ItemTemplate>
           <div><%--<a href="" title="" target="_blank"></a>--%><img src='<%# "images/PhotoGallery/middle/"+ Eval("ImageUrl") %>' width="700" height="220" alt="Slide 1">
         
           
           </div>
         </ItemTemplate>
         </asp:Repeater>
   

	 </div>
     </div>
     </div>
     </div>
    </form>
</body>
</html>
