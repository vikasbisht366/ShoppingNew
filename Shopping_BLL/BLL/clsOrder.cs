using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsOrder
    {
        public int AddEditOrder(int ID,int CustomerID,string OrderStatus,bool IsApproved,string TransactionID,int Extra1,string Extra2,string OrderID,string Amount, string DelivaryDate, string Name, string Mobile_No, string Address, string Country, string State, string City, string Zip, string Locality, string LandMark, string Alternate_MobileNo)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                dt = objOrder.AddEditOrder(ID,CustomerID,OrderStatus,IsApproved,TransactionID,Extra1,Extra2,OrderID,Amount,DelivaryDate, Name, Mobile_No, Address, Country, State, City, Zip, Locality, LandMark, Alternate_MobileNo);
            }
            id = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
            return id;
        }
        public DataTable GetOrder(int ID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                dt = objOrder.GetOrder(ID);
            }
            return dt;
        }
        public DataTable GetAllOrder(int ID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                dt = objOrder.GetAllOrder(ID);
            }
            return dt;
        }
        public DataTable GetOrderByDate(string AddDate)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                dt = objOrder.GetOrderByDate(AddDate);
            }
            return dt;
        }
        public DataTable GetOrderByCustomerID(int CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                dt = objOrder.GetOrderByCustomerID(CustomerID);
            }
            return dt;
        }
        public void DeleteOrder(int ID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                objOrder.DeleteOrder(ID);
            }

        }
        public void ActiveDeactiveOrder(int ID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                objOrder.ActiveDeactiveOrder(ID);
            }

        }
        public void IsApproved(int ID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter objOrder = new AustraliaDAL.DataSet1TableAdapters.tblOrderTableAdapter())
            {
                objOrder.IsApproved(ID);
            }

        }
    }
}
