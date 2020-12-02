using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsOrderDetail
    {
        public int AddEditOrderDetail(int OrderDetailID, int CustomerID, int ProductID, int ID, int Qty, string Amount, string DelivaryDate, string orderno,
            string ProductName, string weight, decimal Price, decimal Discount, decimal AfterDiscount, decimal taxrate, decimal total_amount, string Deliverycharge, string productimg)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter objOrderDetail = new AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter())
            {
                dt = objOrderDetail.AddEditOrderDetail(OrderDetailID, CustomerID, ProductID, ID, Qty, Amount, DelivaryDate, orderno,
                    ProductName, weight, Price, Discount, AfterDiscount, taxrate, total_amount, Deliverycharge, productimg);
            }
            id = Convert.ToInt32(dt.Rows[0]["OrderDetailID"].ToString());
            return id;
        }
        public DataTable GetOrderDetail(int OrderDetailID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter objOrderDetail = new AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter())
            {
                dt = objOrderDetail.GetOrderDetail(OrderDetailID);
            }
            return dt;
        }
        public DataTable GetAllOrderDetail(int OrderDetailID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter objOrderDetail = new AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter())
            {
                dt = objOrderDetail.GetAllOrderDetail(OrderDetailID);
            }
            return dt;
        }
        public DataTable GetOrderDetailByOrderID(int ID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter objOrderDetail = new AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter())
            {
                dt = objOrderDetail.GetOrderDetailByOrderID(ID);
            }
            return dt;
        }
        public void DeleteOrderDetail(int OrderDetailID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter objOrderDetail = new AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter())
            {
                objOrderDetail.DeleteOrderDetail(OrderDetailID);
            }

        }
        public void ActiveDeactiveOrderDetail(int OrderDetailID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter objOrderDetail = new AustraliaDAL.DataSet1TableAdapters.tblOrderDetailTableAdapter())
            {
                objOrderDetail.ActiveDeactiveOrderDetail(OrderDetailID);
            }

        }
    }
}
