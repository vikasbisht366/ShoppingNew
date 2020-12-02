<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="CompleteOrder.aspx.cs" Inherits="CompleteOrder" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript">
        function changeTab() {
            document.getElementById("skirts-tab").click();
        }

    </script>--%>
    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function isCharKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return true;
            return false;
        }
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- breadcrumbs -->
    <div class="breadcrumb_dress" style="margin-top: 0px;">
        <div class="container">
            <ul>
                <li><a href="Index.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a> <i>/</i></li>
                <li>Payment</li>
            </ul>
        </div>
    </div>
    <!-- breadcrumbs -->
    <!-- banner-bottom -->
    <h3 style="text-align: center;"><b>Payment</b></h3>
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
    <div class="banner-bottom">
        <div class="container">
            <div id="div_address" runat="server">
                <div class="col-md-12" style="background-color: #fafafa; display: none" runat="server" id="newaddress">
                    <br />
                    <center> <h2 > <b><u> Add New Address </u>  </b></h2></center>
                    <br />
                    <div class="form">
                        <asp:HiddenField runat="server" ID="hidden_ID" />
                        <asp:HiddenField runat="server" ID="hidden_Customerid" />
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Name :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_name" onkeypress="return isCharKey(event)" MaxLength="30" type="text" CssClass="form-control" placeholder="Full Name" />
                                    <asp:RequiredFieldValidator ID="Require1" runat="server" Display="None" ControlToValidate="txt_name" ValidationGroup="login" ErrorMessage="Name is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Mobile No :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_mobile" type="text" MaxLength="10" onkeypress="return isNumberKey(event)" CssClass="form-control" placeholder="Mobile No" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ControlToValidate="txt_mobile" ValidationGroup="login" ErrorMessage="Mobile Number is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Address :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_Address" MaxLength="40" type="text" CssClass="form-control" placeholder="Address" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" runat="server" ControlToValidate="txt_Address" ValidationGroup="login" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Locality :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_Locality" onkeypress="return isCharKey(event)" MaxLength="25" type="text" CssClass="form-control" placeholder="Locality" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="None" runat="server" ControlToValidate="txt_Locality" ValidationGroup="login" ErrorMessage="Locality is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Country :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_country" type="text" CssClass="form-control" placeholder="Country" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" runat="server" ControlToValidate="txt_country" ValidationGroup="login" ErrorMessage="Country is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>State :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_state" type="text" CssClass="form-control" placeholder="State" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="txt_state" ValidationGroup="login" ErrorMessage="State is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>City :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_city" type="text" CssClass="form-control" placeholder="City" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None" ControlToValidate="txt_city" ValidationGroup="login" ErrorMessage="City is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Zip :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_Zip" type="text" MaxLength="6" onkeypress="return isNumberKey(event)" CssClass="form-control" placeholder="Pin Code" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="None" runat="server" ControlToValidate="txt_Zip" ValidationGroup="login" ErrorMessage="Pin Code is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Landmark :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_landmark" type="text" MaxLength="25" onkeypress="return isCharKey(event)" CssClass="form-control" placeholder="Landmark" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="None" ControlToValidate="txt_landmark" ValidationGroup="login" ErrorMessage="Landmark is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="controls">
                                    <asp:Label runat="server"><b>Alternate Mobile No. :</b></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txt_alternatemobile" MaxLength="10" onkeypress="return isNumberKey(event)" type="text" CssClass="form-control" placeholder="Alternate Mobile No." />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="None" ControlToValidate="txt_alternatemobile" ValidationGroup="login" ErrorMessage="Alternate mobile number is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div align="center">
                        <asp:Button runat="server" Text="Add Address" ValidationGroup="login" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                            Font-Bold="true" Width="180px" ID="btn_AddAddress" OnClick="btn_AddAddress_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="login" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" runat="server" />
                    </div>
                    <br />
                    <br />

                </div>
                <div class="col-md-12" style="background-color: #fafafa;" runat="server" id="listaddress">
                    <div>
                        <br />
                        <asp:Button runat="server" ID="btn_AddNewAddress" Text="Add New Address" OnClick="btn_AddNewAddress_Click"
                            BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px" Font-Bold="true" Width="180px" />
                        <div align="center">
                            <br />
                            <center> <h2 > <b><u> Address List </u>  </b></h2></center>
                            <br />
                        </div>
                        <div>
                            <asp:Repeater ID="Address_get_Repeater" runat="server" OnItemCommand="Address_get_Repeater_ItemCommand">
                                <ItemTemplate>
                                    <div style="float: left; margin-left: 60px">

                                        <p>
                                            <asp:Label runat="server" ID="label_Name" Text='<%# Eval("Name") %>'></asp:Label>

                                            <span style="float: right;"><a href="#">
                                                <asp:Button runat="server" ID="btn_Delete" CommandArgument='<%# Eval("Id") %>'
                                                    OnClientClick="return confirm('Are you sure want to delete this Address. ')" ToolTip="Delete Address"
                                                    CommandName="addressdelete" Text="Delete" BorderStyle="None" BackColor="#fafafa" Font-Bold="true" /></a>

                                            </span>&nbsp

                                            <span style="float: right;"><a href="#"><i class="glyphicon glyphicon-pencil"></i>
                                                <asp:Button runat="server" ID="btnEdit" CommandArgument='<%# Eval("Id") %>' CommandName="addressedit"
                                                    Text="Edit" BorderStyle="None" BackColor="#fafafa" Font-Bold="true" /></a>
                                            </span>

                                        </p>
                                        <p>
                                            <asp:Label runat="server" ID="label_Mobile" Text='<%# Eval("Mobile_No") %>'></asp:Label>
                                        </p>
                                        <p>
                                            <span>
                                                <asp:Label runat="server" ID="label_Address" Text='<%# Eval("Address") %>'></asp:Label></span>
                                        </p>
                                        <p>
                                            <span>
                                                <asp:Label runat="server" ID="label_City" Text='<%# Eval("City") %>'></asp:Label></span>
                                            <span>
                                                <asp:Label runat="server" ID="label_State" Text='<%# Eval("State") %>'></asp:Label></span>
                                            <span>
                                                <asp:Label runat="server" ID="label_country" Text='<%# Eval("Country") %>'></asp:Label></span>
                                            <span>
                                                <asp:Label runat="server" ID="label_Zip" Text='<%# Eval("Zip") %>'></asp:Label></span>
                                        </p>
                                        <p>
                                            <span>
                                                <asp:Label runat="server" ID="label_locality" Text='<%# Eval("Locality") %>'></asp:Label></span>
                                            <span>
                                                <asp:Label runat="server" ID="label_landmark" Text='<%# Eval("LandMark") %>'></asp:Label></span>
                                        </p>
                                        <p>
                                            <span>
                                                <asp:Label runat="server" ID="label_alternatemobile" Text='<%# Eval("Alternate_MobileNo") %>'></asp:Label></span>
                                        </p>
                                        <p>
                                            <span>
                                                <asp:Button runat="server" Text="Deliver this Address" CommandArgument='<%# Eval("Id") %>' CommandName="DevelerthisAddress"
                                                    BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px" Font-Bold="true" Width="180px" ID="btn_DevelerAddress" />
                                                </a>
                                            </span>
                                        </p>

                                        <br />
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>

            <div id="div_CahsOnDelivery" runat="server" style="display: none">
                <div class="col-md-12" style="background-color: #fafafa;">
                    <br />
                    <center> <h2 > <b><u> Cash On Delivery </u>  </b></h2></center>
                    <br />
                    <div style="text-align: center;">
                        <p>
                            <asp:HiddenField runat="server" ID="hidden_IDsaveaddress" />
                            <asp:Label runat="server" ID="label_Name"></asp:Label>
                        </p>
                        <p>
                            <asp:Label runat="server" ID="label_Mobile"></asp:Label>
                        </p>
                        <p>
                            <span>
                                <asp:Label runat="server" ID="label_Address"></asp:Label></span>
                        </p>
                        <p>
                            <span>
                                <asp:Label runat="server" ID="label_City"></asp:Label></span>
                            <span>
                                <asp:Label runat="server" ID="label_State"></asp:Label></span>
                            <span>
                                <asp:Label runat="server" ID="label_country"></asp:Label></span>
                            <span>
                                <asp:Label runat="server" ID="label_Zip"></asp:Label></span>
                        </p>
                        <p>
                            <span>
                                <asp:Label runat="server" ID="label_locality"></asp:Label></span>
                            <span>
                                <asp:Label runat="server" ID="label_landmark"></asp:Label></span>
                        </p>
                        <p>
                            <span>
                                <asp:Label runat="server" ID="label_alternatemobile"></asp:Label></span>
                        </p>

                        <br />
                        
                        <asp:Button runat="server" ID="btn_Cashondelevery" Text="Proceed" OnClick="btn_Cashondelevery_Click" Font-Bold="true"
                          BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px" Width="180px" />
                         
                    </div>

                    <asp:HiddenField runat="server" ID="hidden_Quantity" />
                    <asp:HiddenField runat="server" ID="hidden_productID" />
                    <asp:HiddenField runat="server" ID="Hidden_Cartid" />
                    <asp:HiddenField runat="server" ID="hidden_orderid" />
                    <br />
                    <br />

                    <div align="center">
                        <asp:Button runat="server" Text="Manage Address" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                            Font-Bold="true" Width="180px" ID="btn_ManageAddress" OnClick="btn_ManageAddress_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Credit / Debit Card" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_Creditdebit" OnClick="btn_Creditdebit_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Net Banking" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_netBanking" OnClick="btn_netBanking_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="PayPal" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_paypal" OnClick="btn_paypal_Click" />
                    </div>

                    <br />
                    <br />
                    <br />
                </div>
            </div>

            <div id="div_debitcredit" runat="server" style="display: none">
                <div class="col-md-12" style="background-color: #fafafa;">
                    <br />
                    <center> <h2> <b><u> Creadit / Debit</u>  </b></h2></center>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label class="control-label">Name on Card</label>
                        </div>
                        <div class="col-md-8">
                            <input class="billing-address-name form-control" type="text" name="name" placeholder="John Smith">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label class="control-label">Card Number</label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txt_cardno" class="form-control" type="number"
                                placeholder="Card Number" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label class="control-label">CVV</label>
                        </div>
                        <div class="col-md-8">
                            <input class="security-code form-control" inputmode="numeric" type="text" name="security-code" placeholder="&#149;&#149;&#149;">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label class="control-label">Expiration Date</label>
                        </div>
                        <div class="col-md-8">
                            <input class="expiration-month-and-year form-control" type="text" name="expiration-month-and-year" placeholder="MM / YY">
                        </div>
                    </div>
                    <br />
                    <div align="center">
                        <asp:Button runat="server" Text="Proceed" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px" Font-Bold="true" Width="180px" />
                    </div>
                    <br />
                    <br />

                    <div align="center">
                        <asp:Button runat="server" Text="Manage Address" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                            Font-Bold="true" Width="180px" ID="btn_ManageAddres" OnClick="btn_ManageAddres_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Cash On Delivery" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_CashOn" OnClick="btn_CashOn_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Net Banking" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_netbankingforcredit" OnClick="btn_netbankingforcredit_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="PayPal" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_Paypalforcredit" OnClick="btn_Paypalforcredit_Click" />
                    </div>
                    <br />
                    <br />
                    <br />

                </div>
            </div>

            <div id="div_Netbanking" runat="server" style="display: none">
                <div class="col-md-12" style="background-color: #fafafa;">
                    <br />
                    <center> <h2 > <b><u> Net Banking </u>  </b></h2></center>
                    <br />

                    <div class="swit-radio" style="margin-left: 30px;">
                        <div class="check_box_one">
                            <div class="radio_one">
                                <label>
                                    <input type="radio" name="radio" checked="">
                                    <i></i>Syndicate Bank</label>
                            </div>
                        </div>
                        <div class="check_box_one">
                            <div class="radio_one">
                                <label>
                                    <input type="radio" name="radio">
                                    <i></i>Bank of Baroda</label>
                            </div>
                        </div>
                        <div class="check_box_one">
                            <div class="radio_one">
                                <label>
                                    <input type="radio" name="radio">
                                    <i></i>Canara Bank</label>
                            </div>
                        </div>
                        <div class="check_box_one">
                            <div class="radio_one">
                                <label>
                                    <input type="radio" name="radio">
                                    <i></i>ICICI Bank</label>
                            </div>
                        </div>
                        <div class="check_box_one">
                            <div class="radio_one">
                                <label>
                                    <input type="radio" name="radio">
                                    <i></i>State Bank Of India</label>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <center><h4><b> Select Other Bank</b></h4></center>
                    <div class="section_room_pay" style="margin-left: 30px;">
                        <select class="year">
                            <option value="">=== Other Banks ===</option>
                            <option value="ALB-NA">Allahabad Bank NetBanking</option>
                            <option value="ADB-NA">Andhra Bank</option>
                            <option value="BBK-NA">Bank of Bahrain and Kuwait NetBanking</option>
                            <option value="BBC-NA">Bank of Baroda Corporate NetBanking</option>
                            <option value="BBR-NA">Bank of Baroda Retail NetBanking</option>
                            <option value="BOI-NA">Bank of India NetBanking</option>
                            <option value="BOM-NA">Bank of Maharashtra NetBanking</option>
                            <option value="CSB-NA">Catholic Syrian Bank NetBanking</option>
                            <option value="CBI-NA">Central Bank of India</option>
                            <option value="CUB-NA">City Union Bank NetBanking</option>
                            <option value="CRP-NA">Corporation Bank</option>
                            <option value="DBK-NA">Deutsche Bank NetBanking</option>
                            <option value="DCB-NA">Development Credit Bank</option>
                            <option value="DC2-NA">Development Credit Bank - Corporate</option>
                            <option value="DLB-NA">Dhanlaxmi Bank NetBanking</option>
                            <option value="FBK-NA">Federal Bank NetBanking</option>
                            <option value="IDS-NA">Indusind Bank NetBanking</option>
                            <option value="IOB-NA">Indian Overseas Bank</option>
                            <option value="ING-NA">ING Vysya Bank (now Kotak)</option>
                            <option value="JKB-NA">Jammu and Kashmir NetBanking</option>
                            <option value="JSB-NA">Janata Sahakari Bank Limited</option>
                            <option value="KBL-NA">Karnataka Bank NetBanking</option>
                            <option value="KVB-NA">Karur Vysya Bank NetBanking</option>
                            <option value="LVR-NA">Lakshmi Vilas Bank NetBanking</option>
                            <option value="OBC-NA">Oriental Bank of Commerce NetBanking</option>
                            <option value="CPN-NA">PNB Corporate NetBanking</option>
                            <option value="PNB-NA">PNB NetBanking</option>
                            <option value="RSD-DIRECT">Rajasthan State Co-operative Bank-Debit Card</option>
                            <option value="RBS-NA">RBS (The Royal Bank of Scotland)</option>
                            <option value="SWB-NA">Saraswat Bank NetBanking</option>
                            <option value="SBJ-NA">SB Bikaner and Jaipur NetBanking</option>
                            <option value="SBH-NA">SB Hyderabad NetBanking</option>
                            <option value="SBM-NA">SB Mysore NetBanking</option>
                            <option value="SBT-NA">SB Travancore NetBanking</option>
                            <option value="SVC-NA">Shamrao Vitthal Co-operative Bank</option>
                            <option value="SIB-NA">South Indian Bank NetBanking</option>
                            <option value="SBP-NA">State Bank of Patiala NetBanking</option>
                            <option value="SYD-NA">Syndicate Bank NetBanking</option>
                            <option value="TNC-NA">Tamil Nadu State Co-operative Bank NetBanking</option>
                            <option value="UCO-NA">UCO Bank NetBanking</option>
                            <option value="UBI-NA">Union Bank NetBanking</option>
                            <option value="UNI-NA">United Bank of India NetBanking</option>
                            <option value="VJB-NA">Vijaya Bank NetBanking</option>
                        </select>
                    </div>

                    <br />
                    <div align="center">
                        <asp:Button runat="server" Text="Make a payment" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px" Font-Bold="true" Width="180px" />
                    </div>
                    <br />
                    <br />
                    <div align="center">
                        <asp:Button runat="server" Text="Manage Address" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                            Font-Bold="true" Width="180px" ID="btn_manageaddressfornet" OnClick="btn_manageaddressfornet_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Cash On Delivery" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_cashfornet" OnClick="btn_cashfornet_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Credit / Debit" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_creditfornet" OnClick="btn_creditfornet_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="PayPal" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_paypalfornet" OnClick="btn_paypalfornet_Click" />
                    </div>
                    <br />
                    <br />

                </div>
            </div>

            <div id="div_paypal" runat="server" style="background-color: #fafafa; display: none">

                <br />
                <center> <h2 > <b><u> PayPal </u>  </b></h2></center>
                <br />
                <div class="row" style="margin-left: 50px">
                    <div class="col-md-6">
                        <br />
                        <img class="pp-img" src="web/popup box/img/paypal.png" alt="Image Alternative text" title="Image Title" width="500px" />
                        <br />
                        <p>Important: You will be redirected to PayPal's website to securely complete your payment.</p>
                        <br />
                        <asp:Button runat="server" ID="btn_paypall" class="btn btn-primary" Text="Checkout via Paypal" />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                    </div>
                    <div class="col-md-6">
                        <br />
                        <div class="row">
                            <div class="col-md-10">
                                <div class="clearfix">
                                    <div class="form-group form-group-cc-number">
                                        <label>Card Number</label>
                                        <input class="form-control" placeholder="xxxx xxxx xxxx xxxx" type="text">
                                        <span class="cc-card-icon"></span>
                                    </div>
                                    <div class="form-group form-group-cc-cvc">
                                        <label>CVV</label>
                                        <input class="form-control" placeholder="xxxx" type="text">
                                    </div>
                                </div>
                                <div class="clearfix">
                                    <div class="form-group form-group-cc-name">
                                        <label>Card Holder Name</label>
                                        <input class="form-control" type="text">
                                    </div>
                                    <div class="form-group form-group-cc-date">
                                        <label>Valid Thru</label>
                                        <input class="form-control" placeholder="mm/yy" type="text">
                                    </div>
                                </div>
                                <div>
                                    <asp:CheckBox runat="server" ID="check_paypal" type="checkbox" />
                                    <label>Add to My Cards</label>
                                </div>
                            </div>
                            <div align="center">
                                <asp:Button runat="server" Text="Proceed Payment" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px" Font-Bold="true" Width="180px" />
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
                <br />
                <br />
                <div align="center">
                    <asp:Button runat="server" Text="Manage Address" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_addressforpay" OnClick="btn_addressforpay_Click" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Cash On Delivery" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_cashforpay" OnClick="btn_cashforpay_Click" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Credit / Debit" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_creditforpay" OnClick="btn_creditforpay_Click" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button runat="server" Text="Net Banking" BackColor="Black" ForeColor="White" BorderStyle="None" Height="40px"
                        Font-Bold="true" Width="180px" ID="btn_netforpay" OnClick="btn_netforpay_Click" />
                </div>
                <br />
                <br />
            </div>
        </div>
        <div class="clearfix"></div>
    </div>


</asp:Content>

