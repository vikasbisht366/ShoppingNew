<%@ WebHandler Language="C#" Class="AutoComplete" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Data;
using BLL;

public class AutoComplete : IHttpHandler
{
    clsProduct objProduct = new clsProduct();
  
    public void ProcessRequest(HttpContext context)
    {
        StringBuilder sb = new StringBuilder();
        if (!String.IsNullOrEmpty(context.Request.QueryString["param1"]))
        {
            // To Fill City
            
            string prefixText = context.Request.QueryString["q"];
         //   Int32 StateID = Convert.ToInt32(context.Request.QueryString["StateID"]);
            Int32 SubCategoryID = 0;
            Int32 i;
            DataTable dt = new DataTable();
            dt = objProduct.GetProductbySubCategoryID_ProductName(SubCategoryID, prefixText);
     
            for (i = 0; i < dt.Rows.Count; i++)
            {

                sb.Append(dt.Rows[i]["Title"])
                    .Append(Environment.NewLine);

            }

            context.Response.Write(sb.ToString());

        
              
        }
     
     
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}