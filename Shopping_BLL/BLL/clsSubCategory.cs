using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
   public class clsSubCategory
    {
       public int AddEditSubCategory(int SubCategoryID, string Title, string ImageUrl, string Description, int CategoryID,string MetaTitle,string MetaKeyword,string MetaDescription)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory=new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                dt = objSubCategory.AddEditSubCategory(SubCategoryID, Title, ImageUrl, Description, CategoryID, MetaTitle, MetaKeyword, MetaDescription);
            }
            id = Convert.ToInt32(dt.Rows[0]["SubCategoryID"].ToString());
            return id;
        }
        public DataTable GetSubCategory(int SubCategoryID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory=new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                dt = objSubCategory.GetSubCategory(SubCategoryID);
            }
            return dt;
        }
        public DataTable GetSubCategoryByCategoryID(int CategoryID, bool IsActive)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory = new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                dt = objSubCategory.GetSubCategoryByCategoryID(CategoryID,IsActive);
            }
            return dt;
        }
        public DataTable GetSubCategoryAllByCategoryID(int CategoryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory = new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                dt = objSubCategory.GetSubCategoryAllByCategoryID(CategoryID);
            }
            return dt;
        }
        public DataTable GetAllSubCategory(int SubCategoryID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory=new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                dt = objSubCategory.GetAllSubCategory(SubCategoryID);
            }
            return dt;
        }
        public void DeleteSubCategory(int SubCategoryID)
        {

             using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory=new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                objSubCategory.DeleteAllSubCategory(SubCategoryID);
            }

        }
        public void ActiveDeactiveSubCategory(int SubCategoryID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory=new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                objSubCategory.ActiveDeactiveSubCategory(SubCategoryID);
            }
        }
        public DataTable GetDataTotblSubCategory(int CategoryID,string SubCategoryName)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter objSubCategory = new AustraliaDAL.DataSet1TableAdapters.tblSubCategoryTableAdapter())
            {
                dt = objSubCategory.GetDataTotblSubCategory(CategoryID, SubCategoryName);
            }
            return dt;
        }

        
    }
 }

