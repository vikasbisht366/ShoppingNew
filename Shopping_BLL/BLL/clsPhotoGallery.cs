using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AustraliaDAL;

namespace BLL
{
   public class clsPhotoGallery
    {
       public int AddEditPhotoGallery(int PhotoGalleryID, string Title, string ImageUrl, int AlbumID)
        {
            int pageval;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter())
            {
                dt = _ObjTA.AddEditPhotoGallery(PhotoGalleryID,Title,ImageUrl,AlbumID);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["PhotoGalleryID"].ToString());
            return pageval;
        }

       public DataTable GetPhotoGallery(int PhotoGalleryID, int AlbumID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter())
            {
                dt = _ObjTA.GetPhotoGallery(PhotoGalleryID,AlbumID);
            }
            return dt;
        }

       public DataTable GetPhotoGalleryAll(int PhotoGalleryID, int AlbumID)
       {
           DataTable dt = new DataTable();
           using (AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter())
           {
               dt = _ObjTA.GetPhotoGalleryAll(PhotoGalleryID,AlbumID);
           }
           return dt;
       }
       public void DeletePhotoGallery(int PhotoGalleryID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter())
            {
                _ObjTA.DeletePhotoGallery(PhotoGalleryID);
            }
        }

       public void ActiveDeactivePhotoGallery(int PhotoGalleryID)
       {
           using (AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblPhotoGalleryTableAdapter())
           {
               _ObjTA.ActiveDeactivePhotoGallery(PhotoGalleryID);
           }
       }
      
    }
}
