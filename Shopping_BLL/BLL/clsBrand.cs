using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class clsBrand
    {

        public int AddEditBrand(int BrandID, string BrandName, string Description, string ImageUrl, int CategoryID, int SubcategoryID, string MetaTitle, string MetaKeyword, string MetaDescription)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objbrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objbrand.AddEditBrand(BrandID, BrandName, Description, ImageUrl, CategoryID, SubcategoryID, MetaTitle, MetaKeyword, MetaDescription);
            }
            id = Convert.ToInt32(dt.Rows[0]["BrandID"].ToString());
            return id;
        }
        public DataTable GetBrand(int BrandID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objBrand.GetBrand(BrandID);
            }
            return dt;
        }
        public DataTable GetBrandBySubCategoryID(int SubCategoryID, bool IsActive)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objBrand.GetBrandBySubCategoryID(SubCategoryID, IsActive);
            }
            return dt;
        }
        public DataTable GetBrandAllBySubCategoryID(int SubCategoryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objBrand.GetBrandAllBySubCategoryID(SubCategoryID);
            }
            return dt;
        }
        public DataTable GetAllBrand(int BrandID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objBrand.GetAllBrand(BrandID);
            }
            return dt;
        }
        public void DeleteAllBrand(int BrandID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                objBrand.DeleteAllBrand(BrandID);
            }

        }
        public void ActiveDeactiveBrand(int BrandID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                objBrand.ActiveDeactiveBrand(BrandID);
            }
        }
        public DataTable GetDataTotblBrand(int CategoryID,int SubCategoryID,string BrandID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objBrand.GetDataTotblBrand(CategoryID, SubCategoryID, BrandID);
            }
            return dt;
        }
        public DataTable GetBrandImages( int BrandID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objBrand.GetBrandImages(BrandID);
            }
            return dt;
        }

        public DataTable GetBrandDetailsforBrandName(int BrandID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter objBrand = new AustraliaDAL.DataSet1TableAdapters.tbl_BrandTableAdapter())
            {
                dt = objBrand.GetBrandDetailsforBrandName(BrandID);
            }
            return dt;
        }
      


    }

}
