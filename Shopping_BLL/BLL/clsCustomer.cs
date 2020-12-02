using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsCustomer
    {
        public int AddEditCustomer(int CustomerID, string username,  string Email, string ContactNo1, string ImageUrl, string Password, string Address, string Country, string State, string City, string ZIP, string IPAddress, string Remark, int CountryID, int StateID, int CityID)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.AddEditCustomer(CustomerID, username, Email, ContactNo1, ImageUrl, Password, Address, Country, State, City, ZIP, IPAddress, Remark, CountryID, StateID, CityID);
            }
            id = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
            return id;
        }

        public DataTable AddEditAccountDetails(int id,string CustomerID, string aadharcard, string Pancard, string Accno, string ifsc, string branchname, string branchaddress, string ip)
        {
            
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_AccountDetailsTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tbl_AccountDetailsTableAdapter())
            {
                dt = objCustomer.AddEditAccountDetails(id,CustomerID, aadharcard,Pancard,Accno,ifsc,branchname,branchaddress,ip);
            }
            
            return dt;
        }


        public void AddEditCustomerRegistration(int Customerid, string username, string email, string password, string ip, string MobileNo,string memberid,string referral)
        {

            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.AddEditCustomerRegistration(Customerid, username, email, password, ip, MobileNo,memberid,referral);
            }

        }
        public DataTable GetCustomer(int CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.GetCustomer(CustomerID);
            }
            return dt;
        }
        public DataTable CustomerLogin(string Email, string Password)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.CustomerLogin(Email, Password);
            }
            return dt;
        }

        public DataTable GetAllCustomer(int CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.GetAllCustomer(CustomerID);
            }
            return dt;
        }
        public DataTable GetCustomerByEmail(string Email)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.GetCustomerByEmail(Email);
            }
            return dt;
        }
        public DataTable GetCustomerBymobile(string mobile)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.GetCustomerBymobile(mobile);
            }
            return dt;
        }
        public void DeleteCustomer(int CustomerID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                objCustomer.DeleteCustomer(CustomerID);
            }

        }
        public void ActiveDeactiveCustomer(int CustomerID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                objCustomer.ActiveDeactiveCustomer(CustomerID);
            }
        }
        public void UpdateCustomerPassword(int CustomerID, string CurrentPassword, string NewPassword)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                objCustomer.UpdateCustomerPassword(CustomerID, CurrentPassword, NewPassword);
            }
        }
        public DataTable Getmemberbyid(string memberid)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.Getmemberbyid(memberid);
            }
            return dt;
        }
        public DataTable getnetwork(string memberid)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.getnetwork(memberid);
            }
            return dt;
        }

        public DataTable GetLoginforbulk(string mobileno ,string password)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter objCustomer = new AustraliaDAL.DataSet1TableAdapters.tblCustomerTableAdapter())
            {
                dt = objCustomer.GetLoginforbulk(mobileno,password);
            }
            return dt;

        }

    }
}

