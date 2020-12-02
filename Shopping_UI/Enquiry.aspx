<%@ Page Title="" Language="C#" MasterPageFile="~/Front.master" AutoEventWireup="true"
    CodeFile="Enquiry.aspx.cs" Inherits="Enquiry" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="middlepart">
        <h2 class="heading">
            Enquiry Form
        </h2>
        <p class="text">
            <i>Please provide the details below.</i><br /><br /><br />
       
         
           
        </p>
       <div>
       <div style="float:left;width:400px;"><table width="400px" border="0" cellpadding="0" cellspacing="0" >
                <tr align="left">
                    <td>
                        Your Name :
                    </td>
                </tr>
                <tr align="left">
                    <td>
                        <asp:TextBox ID="txtName" runat="server"  MaxLength="50" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter Your Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvYourName" runat="server" ControlToValidate="txtName"
                            Display="Dynamic" ErrorMessage="Please Enter Your Name" SetFocusOnError="True"
                            ValidationGroup="v" InitialValue="Enter Your Name">*
                                            
                                            
                        </asp:RequiredFieldValidator><br />
                        <br />
                    </td>
                </tr>
                <tr align="left">
                    <td >
                        &nbsp;Email :
                    </td>
                </tr>
                <tr align="left">
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"  MaxLength="50" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter Your Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="Please Enter Your Email" SetFocusOnError="True"
                            ValidationGroup="v" InitialValue="Enter Your Email">*
                                            
                                            
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="Email is not valid" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="v">*</asp:RegularExpressionValidator><br />
                        <br />
                    </td>
                </tr>
                <tr align="left">
                    <td>
                        Contact No :
                    </td>
                </tr>
                <tr align="left">
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="50" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="---------"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtPhone_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Custom,Numbers" TargetControlID="txtPhone" ValidChars=".,-, ,">
                        </cc1:FilteredTextBoxExtender>
                    
                        <asp:RequiredFieldValidator ID="rfvYourName1" runat="server" ControlToValidate="txtPhone"
                            Display="Dynamic" ErrorMessage="Please Enter Contact No." SetFocusOnError="True"
                            ValidationGroup="v" InitialValue="---------">*</asp:RequiredFieldValidator><br />
                        <br />
                    </td>
                </tr>
                <tr align="left">
                    <td>
                        Enquiry :
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            <asp:TextBox ID="txtComment" runat="server" cols="45" Rows="5" Style="height: 100px;
                                width: 350px;" TextMode="MultiLine" onfocus="clearText(this)"
                        onblur="clearText(this)" CssClass="txt_field_yo" value="Enter Your Enquiry" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvYourName2" runat="server" ControlToValidate="txtComment"
                                Display="Dynamic" ErrorMessage="Please Enter Enquiry" SetFocusOnError="True"
                                ValidationGroup="v" InitialValue="Enter Your Enquiry">*</asp:RequiredFieldValidator>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                         <asp:Button ID="btnSubmit" runat="server" Text="Submit"  
                                    onclick="btnSubmit_Click" ValidationGroup="v" CssClass="btnSubmit"/>
                      
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="v" />
                    </td>
                </tr>
              
            </table></div>
          <div style="float:right;width:250px;text-align:justify;font-weight:bold;margin-right:20px;">  <p style="margin:0 0 20px 10px;line-height:25px;">Thank you for contacting us. We aim to respond to your enquiry within 48 hours of receipt (excludes weekends and public holidays).</p>
          <img src="Images/enquiry_img.jpg" alt="" style="float:right;width:250px;" /></div>
       </div>
    
        
     
         
        
          
    </div>
</asp:Content>
