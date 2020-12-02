using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class clsCart
    {
        public void AddEditCartMaster(int id, string CustomerID, string ProductID,string quentity)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter objcartitem = new AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter())
            {
                dt = objcartitem.AddEditCartMaster(id, CustomerID, ProductID, quentity);
            }
        }
        public DataTable GetCartMaster(string CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter objcartitem = new AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter())
            {
                dt = objcartitem.GetCartMaster(CustomerID);
            }
            return dt;
        }

        public DataTable DeleteItemfromCartMaster(int cartid,string cusid)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter objcartitem = new AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter())
            {
                objcartitem.DeleteItemfromCartMaster(cartid,cusid);
            }
            return dt;
        }
        public DataTable UpdateCartProductQuentity(int AddCartID, string cusid,string ProductID,string Quantity)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter objcartitem = new AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter())
            {
                objcartitem.UpdateCartProductQuentity(AddCartID, cusid,ProductID,Quantity);
            }
            return dt;
        }

        public DataTable GetCartDetailsbyCustomerAndProduct(string CustomerID,string productid)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter objcartitem = new AustraliaDAL.DataSet1TableAdapters.CartMasterTableAdapter())
            {
                dt = objcartitem.GetCartDetailsbyCustomerAndProduct(CustomerID,productid);
            }
            return dt;
        }


    }
}
