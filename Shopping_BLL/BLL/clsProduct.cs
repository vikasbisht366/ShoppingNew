using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
   public class clsProduct
    {
       public void AddEditProduct(int ProductID, string Title, string ImageUrl, string Description, string Weight, string Price, string Discount, string AfterDiscount, int Stock, bool IsFeartured, int CategoryID, int SubCategoryID, string MetaTitle, string MetaKeyword, string MetaDescription, bool IsOnSale, string OnSaleDiscount, string Image1, string Image2, string Image3, string Image4, string Image5,int brandID,string totalamount,string tax,string DeliveryCharge,int MaxQTY)
        {
            
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct=new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.AddEditProduct(ProductID, Title, ImageUrl, Description, Weight, Price, Discount, AfterDiscount, Stock, IsFeartured, CategoryID, SubCategoryID, MetaTitle, MetaKeyword, MetaDescription, IsOnSale, OnSaleDiscount, Image1, Image2, Image3, Image4, Image5,brandID,totalamount,tax, DeliveryCharge, MaxQTY);
            }
           
        }
        public DataTable GetProductAllByBrandID(int BrandID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductAllByBrandID(BrandID);
            }
            return dt;
        }
        public DataTable GetProduct(int ProductID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct=new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProduct(ProductID);
            }
            return dt;
        }
        public DataTable GetProductOnSale(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductOnSale(ProductID);
            }
            return dt;
        }
        public DataTable GetAllProduct(int ProductID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct=new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetAllProduct(ProductID);
            }
            return dt;
        }
        public DataTable GetProductBySubCategoryID(int SubCategoryID, bool IsActive)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductBySubCategoryID(SubCategoryID,IsActive);
            }
            return dt;
        }
        public DataTable GetProductByCategoryID(int CategoryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductByCategoryID(CategoryID);
            }
            return dt;
        }
        public DataTable GetProductAllBySubCategoryID(int SubCategoryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductAllBySubcategoryID(SubCategoryID);
            }
            return dt;
        }
        public DataTable GetProductAutoComplete(int ProductID, string Title)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductAutoComplete(ProductID,Title);
            }
            return dt;
        }
        public DataTable GetProductFeatured(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductFeatured(ProductID);
            }
            return dt;
        }
        public DataTable GetProductPopular(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductPopular(ProductID);
            }
            return dt;
        }
        public DataTable GetProductLatest(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductLatest(ProductID);
            }
            return dt;
        }
        public DataTable GetProductOnItemDetails(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.Getproductbyitem(ProductID);
            }
            return dt;
        }
        public DataTable GetProductTop4Featured(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductTop4Featured(ProductID);
            }
            return dt;
        }
        public DataTable GetTop7Product(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetTop7Product(ProductID);
            }
            return dt;
        }
        public DataTable GetProductTop4Popular(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductTop4Popular(ProductID);
            }
            return dt;
        }
        public DataTable GetProductTop4Latest(int ProductID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductTop4Latest(ProductID);
            }
            return dt;
        }
        public DataTable GetProductByProductName(string ProductName)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductByProductName(ProductName);
            }
            return dt;
        }
        public DataTable GetProductbySubCategoryID_ProductName(int SubCategoryID,string PrefixText)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductbySubCategoryID_ProductName(SubCategoryID,PrefixText);
            }
            return dt;
        }
        public void DeleteProduct(int ProductID)
        {

             using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct=new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                objProduct.DeleteProduct(ProductID);
            }

        }
        public void ActiveDeactiveProduct(int ProductID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct=new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                objProduct.ActiveDeactiveProduct(ProductID);
            }
        }
        public void ActiveDeactiveProductStock(int ProductID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                objProduct.ActiveDeactiveProductStock(ProductID);
            }
        }
        public void UpdateProductHits(int ProductID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                objProduct.UpdateProductHits(ProductID);
            }
        }
        public DataTable GetDataTotblProduct(int CategoryID,int SubCategory,string ProductName, string price)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetDataTotblProduct(CategoryID, SubCategory, ProductName, price);
            }
            return dt;
        }
        public DataTable GetProductBySubCategoryIDForNavMenu(int SubCategoryID, bool active)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter())
            {
                dt = objProduct.GetProductBySubCategoryIDForNavMenu( SubCategoryID,active);
            }
            return dt;
        }
        public DataTable GetProductByBrandIDForNavMenu(int BrandID, bool Active)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter objProduct = new AustraliaDAL.DataSet1TableAdapters.tblProductTableAdapter()) 
            {
                dt = objProduct.GetProductByBrandIDForNavMenu(BrandID, Active);
            }
            return dt;
        }

    }
 }

