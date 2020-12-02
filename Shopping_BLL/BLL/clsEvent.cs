using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AustraliaDAL;

namespace BLL
{
   public class clsEvent
    {
       public int AddEditEvent(int EventID, string EventName, string ImageUrl, string EventDesc, DateTime AddDate)
        {
            int pageval;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter())
            {
                dt = _ObjTA.AddEditEvent(EventID,EventName,ImageUrl,EventDesc,AddDate);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["EventID"].ToString());
            return pageval;
        }

       public DataTable GetEvent(int EventID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter())
            {
                dt = _ObjTA.GetEvent(EventID);
            }
            return dt;
        }
       //public DataTable GetEventTop5(int EventID)
       //{
       //    DataTable dt = new DataTable();
       //    using (AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter())
       //    {
       //        dt = _ObjTA.GetEventTop5(EventID);
       //    }
       //    return dt;
       //}
     
       public DataTable GetEventAll(int EventID)
       {
           DataTable dt = new DataTable();
           using (AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter())
           {
               dt = _ObjTA.GetEventAll(EventID);
           }
           return dt;
       }
       public void DeleteEvent(int EventID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter())
            {
                _ObjTA.DeleteEvent(EventID);
            }
        }

       public void ActiveDeactiveEvent(int EventID)
       {
           using (AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblEventTableAdapter())
           {
               _ObjTA.ActiveDeactiveEvent(EventID);
           }
       }
      
    }
}
