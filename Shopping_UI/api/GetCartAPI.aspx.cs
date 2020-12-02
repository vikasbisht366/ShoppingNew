using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using BLL;
using Newtonsoft.Json;
using System.Net;



public partial class api_GetCartAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    string cusid = "";
    string query1;
    int cartID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            try
            {
                cusid = Request.QueryString["CustomerID"];
                cartID = Convert.ToInt32(Request.QueryString["CartID"]);

                #region Signup Api
                if (Request.QueryString["Type"].ToString() == "GetCart")
                {
                    getCartDetails();
                }
                else if (Request.QueryString["Type"].ToString() == "RemoveCartItem")
                {
                    RemoveCartitem();
                }
                else
                {
                    dt = MasterMassage("Status", "false", "Message", "Invalid Type");
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
                }
                #endregion
            }
            catch
            {
                dt = MasterMassage("status", "false", "massage", "Mendatory fields are required.");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Invalid Request");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }

    }

    public void RemoveCartitem()
    {
        if (cartID != 0)
        {
            objaccess.ExecuteQuery("delete from CartMaster where AddCart_Id=" + cartID + " ");

            dt = MasterMassage("Status", "true", "massage", "Success");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
        else
        {

            dt = MasterMassage("Status", "false", "massage", "AddCart_Id is Required.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }


    public void getCartDetails()
    {
        if (cusid != "" && cusid != null)
        {
            string query = "Exec proc_GetCartMaster'" + cusid + "' ";
            dt = objaccess.GetDatatable(query);
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));

            //query1 = "select Sum(Convert(decimal(18,2),TotalAmount)) as Amount from CartMaster where CustomerID='" + cusid + "' ";
            //dt = objaccess.GetDatatable(query1);
            //HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));



        }
        else
        {
            dt = MasterMassage("Status", "false", "massage", "CustomerID is Required.");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
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



