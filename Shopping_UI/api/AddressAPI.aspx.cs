using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Newtonsoft.Json;
using System.Net;

public partial class api_AddressAPI : System.Web.UI.Page
{
    Cls_DataAccess objaccess = new Cls_DataAccess();
    DataTable dt = new DataTable();
    int AddressID = 0;
    string cusid = "";
    string username = "";
    string mobileNumber = "";
    string Address = "";
    string Country = "";
    string State = "";
    string City = "";
    string Zip = "";
    string Locality = "";
    string Landmark = "";
    string alternatemobile = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            AddressID = Convert.ToInt32(Request.QueryString["AddID"]);
            cusid = Request.QueryString["CustomerID"];
            username = Request.QueryString["UserName"];
            mobileNumber = Request.QueryString["mobileno"];
            Address = Request.QueryString["Address"];
            Country = Request.QueryString["Country"];
            State = Request.QueryString["State"];
            City = Request.QueryString["City"];
            Zip = Request.QueryString["Zip"];
            Locality = Request.QueryString["Locality"];
            Landmark = Request.QueryString["Landmark"];
            alternatemobile = Request.QueryString["AlternateMobile"];


            if (Request.QueryString["Type"].ToString() == "AddAddress")
            {
                addAddress();
            }
            else
            {
                dt = MasterMassage("Status", "false", "Message", "Invalid Type");
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Type is required");
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
        }
    }

    public void addAddress()
    {
        if (cusid != "" && cusid != null && username != "" && username != null && mobileNumber != "" && mobileNumber != null && Address != "" && Address != null && Country != "" && Country != null && State != "" && State != null && City != "" && City != null && Zip != "" && Zip != null && Locality != "" && Locality != null && Landmark != "" && Landmark != null && alternatemobile != "" && alternatemobile != null)
        {
            if (AddressID == 0)
            {
                string query = "Exec proc_AddEditAddressMaster'" + AddressID + "','" + cusid + "','" + username + "','" + mobileNumber + "','" + Address + "','" + Country + "','" + State + "','" + City + "','" + Zip + "','" + Locality + "','" + Landmark + "','" + alternatemobile + "' ";

                dt = objaccess.GetDatatable(query);
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));


            }
            else
            {
                string query = "Exec proc_AddEditAddressMaster'" + AddressID + "','" + cusid + "','" + username + "','" + mobileNumber + "','" + Address + "','" + Country + "','" + State + "','" + City + "','" + Zip + "','" + Locality + "','" + Landmark + "','" + alternatemobile + "' ";

                dt = objaccess.GetDatatable(query);
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented));
            }
        }
        else
        {
            dt = MasterMassage("Status", "false", "Message", "Mandatory feilds are required");
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