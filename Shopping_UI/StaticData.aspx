<%@ Page Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true" CodeFile="StaticData.aspx.cs"
    Inherits="StaticData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style type="text/css">
    .static
    {
    }
 .static p
{
    line-height:20px;
    text-align:justify;
}
 .static ol
{
  margin-bottom:20px;
  margin-top:10px;
}
 .static li
{
   list-style-type :decimal;
     text-align:justify;
     line-height:20px;
     margin-left:20px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h2 class="heading">   <asp:Literal ID="litPageHeading" runat="server"></asp:Literal></h2>
   

<div class="static text"> <asp:Literal ID="litPageDesc" runat="server" ></asp:Literal>
    
   
  





    </div>
     
  
</asp:Content>
