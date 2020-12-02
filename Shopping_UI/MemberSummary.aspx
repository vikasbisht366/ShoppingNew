<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="MemberSummary.aspx.cs" Inherits="MemberSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb_dress" style="margin-top: 0px;">
        <div class="container">
            <ul>
                <li><a href="Default.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a> <i>/</i></li>
                <li>Customer Summary</li>
            </ul>
        </div>
    </div>

    <h3 align="center">Transaction Details</h3>

    <div class="checkout" style="border-bottom: 1px solid #a59f9f;">
        <div class="container">

            <div class="checkout-right">
                <table class="timetable_sub">
                    <asp:Repeater runat="server" ID="rep_cart" OnItemCommand="rep_cart_ItemCommand">
                        <HeaderTemplate>
                            <tr style="background-color: #a59f9f;">
                                <th>Sno</th>
                                <th>Narration</th>
                                <th>Credit / Debit</th>
                                <th>Balance</th>
                                <th>Transaction Date</th>
                              
                               
                            </tr>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr class="rem1">
                                <th> <%# Container.ItemIndex+1 %>
                                    
                                </th>
                                <td class="invert"><%#Eval("Narration") %> </td>
                                <td class="invert"><%#Eval("Amount")%> </td>
                                <td class="invert"><%#Eval("Balance") %></td>
                                <td class="invert"><%#Eval("AddDate") %></td>
                              <%--  <td class="invert"><%#Eval("referral") %></td>
                                <td class="invert"><%#Eval("AddDate") %></td>--%>
                              

                            </tr>

                        </ItemTemplate>

                    </asp:Repeater>
                </table>
            </div>
            <!--Continue PAyment-->


        </div>
    </div>

</asp:Content>

