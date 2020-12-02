using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
   public class clsCategory
    {
       public int AddEditCategory(int CategoryID, string Title, string ImageUrl, string Description,string MetaTitle,string MetaKeyword,string MetaDescription)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter objCategory=new AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter())
            {
                dt = objCategory.AddEditCategory(CategoryID,Title,ImageUrl,Description,MetaTitle,MetaKeyword,MetaDescription);
            }
            id = Convert.ToInt32(dt.Rows[0]["CategoryID"].ToString());
            return id;
        }
        public DataTable GetCategory(int CategoryID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter objCategory=new AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter())
            {
                dt = objCategory.GetCategory(CategoryID);
            }
            return dt;
        }
        public DataTable GetAllCategory(int CategoryID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter objCategory=new AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter())
            {
                dt = objCategory.GetAllCategory(CategoryID);
            }
            return dt;
        }
        public void DeleteCategory(int CategoryID)
        {

             using (AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter objCategory=new AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter())
            {
                objCategory.DeleteCategory(CategoryID);
            }

        }
        public void ActiveDeactiveCategory(int CategoryID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter objCategory=new AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter())
            {
                objCategory.ActiveDeactiveCategory(CategoryID);
            }
        }
        public DataTable GetDataTotblCategory(string CategoryName)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter objCategory = new AustraliaDAL.DataSet1TableAdapters.tblCategoryTableAdapter())
            {
                dt = objCategory.GetDataTotblCategory(CategoryName);
            }
            return dt;
        }

        

    }
 }

