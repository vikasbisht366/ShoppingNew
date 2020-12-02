using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using BLL;
using System.Net;
using System.Data;

public partial class api_PurchaseQuantityCheck : System.Web.UI.Page
{

    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    clsOrder objorder = new clsOrder();
    clsOrderDetail objorderdetails = new clsOrderDetail();
    int productid;
    int quantity;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            productid = Convert.ToInt32(Request.QueryString["productid"]);
            quantity = Convert.ToInt32(Request.QueryString["quantity"]);

            #region update profile
            if (Request.QueryString["Type"].ToString() == "PRODUCTQTYCHECK")
            {
                if (productid != 0 && quantity != 0)
                {
                    dt = productQTY(productid);
                    if (dt.Rows.Count > 0)
                    {
                        int QTYvalue = Convert.ToInt32(dt.Rows[0]["OrderMaxQTY"]);
                        if (QTYvalue != 0)
                        {
                            if (quantity > QTYvalue)
                            {
                                dt = MasterMassage("Status", "false", "Message", "You cant Purchase this item more than '" + QTYvalue + "' Quantity");
                                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                                HttpContext.Current.Response.End();
                            }
                            else if (quantity <= QTYvalue)
                            {
                                dt = MasterMassage("Status", "true", "Message", "Success");
                                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                                HttpContext.Current.Response.End();
                            }
                        }
                        else
                        {
                            dt = MasterMassage("Status", "true", "Message", "Success");
                            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                            HttpContext.Current.Response.End();
                        }
                    }
                    else
                    {
                        dt = MasterMassage("Status", "false", "Message", "Invalid ProductID");
                        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                        HttpContext.Current.Response.End();
                    }
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "ProductID cant be null or Zero");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                    HttpContext.Current.Response.End();
                }

            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Invalid Type");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                HttpContext.Current.Response.End();
            }
            #endregion

        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type is required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            HttpContext.Current.Response.End();
        }
    }

    public DataTable productQTY(int productID)
    {
        string query = "select OrderMaxQTY from tblproduct where ProductID='" + productID + "'";
        DataTable dtquantity = objaccess.GetDatatable(query);
        return dtquantity;
    }


    public DataTable MasterMassage(string Variablename, string values, string Message, string values1)
    {
        DataTable tb = new DataTable();
        DataRow dr;
        tb.Columns.Add(Variablename, typeof(string));
        tb.Columns.Add(Message, typeof(string));
        dr = tb.NewRow();
        dr[Variablename] = values;
        dr[Message] = values1;
        tb.Rows.Add(dr);
        return tb;

    }
}