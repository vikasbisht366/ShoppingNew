using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AustraliaDAL;

namespace BLL
{
   public class clsVideo
    {
       public int AddEditVideo(int VideoID, string Title, string VideoUrl)
        {
            int pageval;
            DataTable dt = new DataTable();
          
            using (AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter())
            {
                dt = _ObjTA.AddEditVideo(VideoID,Title,VideoUrl);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["VideoID"].ToString());
            return pageval;
        }

       public DataTable GetVideo(int VideoID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter())
            {
                dt = _ObjTA.GetVideo(VideoID);
            }
            return dt;
        }
       //public DataTable GetVideoTop1(int VideoID)
       //{
       //    DataTable dt = new DataTable();
       //    using (AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter())
       //    {
       //        dt = _ObjTA.GetVideoTop1(VideoID);
       //    }
       //    return dt;
       //}
     
       public DataTable GetVideoAll(int VideoID)
       {
           DataTable dt = new DataTable();
           using (AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter())
           {
               dt = _ObjTA.GetVideoAll(VideoID);
           }
           return dt;
       }
       public void DeleteVideo(int VideoID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter())
            {
                _ObjTA.DeleteVideo(VideoID);
            }
        }

       public void ActiveDeactiveVideo(int VideoID)
       {
           using (AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblVideoTableAdapter())
           {
               _ObjTA.ActiveDeactiveVideo(VideoID);
           }
       }
      
    }
}
