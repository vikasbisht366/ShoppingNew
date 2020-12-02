using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AustraliaDAL;

namespace BLL
{
   public class clsAlbum
    {
       public int AddEditAlbum(int AlbumID, string AlbumName)
        {
            int pageval;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter())
            {
                dt = _ObjTA.AddEditAlbum(AlbumID,AlbumName);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["AlbumID"].ToString());
            return pageval;
        }

       public DataTable GetAlbum(int AlbumID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter())
            {
                dt = _ObjTA.GetAlbum(AlbumID);
            }
            return dt;
        }
    
     
       public DataTable GetAlbumAll(int AlbumID)
       {
           DataTable dt = new DataTable();
           using (AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter())
           {
               dt = _ObjTA.GetAlbumAll(AlbumID);
           }
           return dt;
       }
       public void DeleteAlbum(int AlbumID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter())
            {
                _ObjTA.DeleteAlbum(AlbumID);
            }
        }

       public void ActiveDeactiveAlbum(int AlbumID)
       {
           using (AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblAlbumTableAdapter())
           {
               _ObjTA.ActiveDeactiveAlbum(AlbumID);
           }
       }
      
    }
}
