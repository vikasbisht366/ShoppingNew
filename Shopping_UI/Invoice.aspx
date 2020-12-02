<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> GharTak | Invoice </title>

     <style>
         .main {
             width: 980px;
             margin: auto;
             height: auto;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">

        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td> <img src="images/logo (2).png" width="150px" /> </td>
                <td style="vertical-align:top; text-align:right;">
                    <h3>  <strong>Ghartak Invoice Receipt </strong> </h3>
                    (Original for Recipient)
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td style="vertical-align:top; text-align:right;">&nbsp;</td>
            </tr>
            <tr>
                <td height="156">
                    <p>
                        <strong style="font-size:18px;">Sold By :</strong>  <br />
                        Auro Fruit and Nut Pvt. Ltd <br />
                        Unit No. 1, Khewat/ Khata No: 373/ 400 Mustatil * <br />
                        No 31,, Village Taoru, Tehsil Taoru, District <br />
                        Mewat,, On Bilaspur Taoru Road <br />
                        Mewat, Haryana, 122105 <br />
                        IN
                    </p>
                </td>
                <td style="vertical-align:top; text-align:right;">


                    <p>
                        <strong style="font-size:18px;"> Billing Address : </strong> <br />
                        demo kumar <br />
                        dsfsdfsdfI - B, fsdfaddress<br />
                        dsdnu, RAJdsfsdHAN, 33504 <br />
                        IN
                    </p>


                </td>
            </tr>
            <%--<tr>
                <td height="93">
                    <strong style="font-size:18px;">PAN No:</strong> AAFCAdfsfdsfs <br />
                    <strong style="font-size:18px;">GST Registration No:</strong> 06AAFCA3069H1ZS <br />


                </td>
                <td style="vertical-align:top; text-align:right;">


                    <strong style="font-size:18px;">  Shipping Address : </strong>  <br />
                    demo kumar <br />
                    demo kumar <br />
                    ffsdfsdfdf f sfsshri Kanhaiya <br />
                    masion A-12, Ashryf sdf fs ba Bhave Nagar, <br />
                    Vaf fsdali nagar <br />
                    JAIPUR, RAJASTHAN, 302021 <br />
                    IN


                </td>
            </tr>--%>
            <tr>
                <td height="98">

                    <strong style="font-size:18px;">  Order Number:  </strong> 408-9094141-9126701   <br />
                    
                </td>
                <td style="vertical-align:middle; text-align:right;">

                    <strong style="font-size:18px;"> Order Date: </strong> 24.12.2018
                    <%--<strong style="font-size:18px;"> Invoice Number : </strong> DEL2-6035 <br />
                    <strong style="font-size:18px;"> Invoice Details : </strong> HR-DEL2-154799761-1819 <br />
                    <strong style="font-size:18px;"> Invoice Date : </strong> 24.12.2018--%>

                </td>
            </tr>

        </table>


        <table width="100%" border="1" cellspacing="0" cellpadding="0">
            <tr style="background-color:#999; text-align:center;">
                <td width="4%" height="32"> Sr. No. </td>
                <td width="49%"> Product Name </td>
                <td width="5%"> Uint Price </td>
                <td width="6%"> Discount </td>
                <td width="3%"> Qty </td>
                <td width="7%"> Net Amount </td>
                <td width="5%"> Tax Rate </td>
                <td width="5%"> Tax Type </td>
                <td width="7%"> Tax Amount </td>
                <td width="9%"> Total Amount </td>
            </tr>
            <tr style=" text-align:center;"=text-align:center;">
                <td height="65"> 1 </td>
                <td>
                    Nutraj Recipe Ready Walnut Kernels, 2 x 250 Gms |
                    B01ABU09H2 ( NUT-RR-WKR-8906019770328-PO2 )
                    HSN:0802
                </td>
                <td> 45 </td>
                <td>454</td>
                <td>453</td>
                <td>56</td>
                <td>656</td>
                <td>77</td>
                <td>546</td>
                <td>5464</td>
            </tr>
            <tr style=" text-align:left;"=text-align:left;">
                <td height="34" colspan="9" style="padding:5px;"> <strong>Total</strong> </td>
                <td style="background-color:#999; padding:5px;"> 4331313 </td>
            </tr>
            <tr style=" text-align:left;"=text-align:left;">
                <td height="70" colspan="10" style="padding:5px;">
                    <strong>
                        Amount in Words:  <br />
                        Five Hundred And Ninety-nine only
                    </strong>
                </td>
            </tr>

            <tr style=" text-align:right;"=text-align:right;">
                <td height="70" colspan="10" style="padding:5px;">
                    <strong>
                        For Auro Fruit and Nut Pvt. Ltd: <br /> <br /><br />
                        Authorized Signatory
                    </strong>
                </td>
            </tr>

        </table>



    </div>
    </form>
</body>
</html>
