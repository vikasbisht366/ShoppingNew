using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsCountry
    {

        public int AddEditCountry(int CountryID, string CountryName)
        {
            int pageval;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter())
            {
                dt = _ObjTA.AddEditCountry(CountryID,CountryName);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["CountryID"].ToString());
            return pageval;
        }
        public DataTable GetCountry()
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter())
            {
                dt = _ObjTA.GetCountry();
            }
            return dt;
        }
        public DataTable GetCountryAll(int CountryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter())
            {
                dt = _ObjTA.GetCountryAll(CountryID);
            }
            return dt;
        }
        public void DeleteCountry(int CountryID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter())
            {
                _ObjTA.DeleteCountry(CountryID);
            }
        }
        public void ActiveDeactiveCountry(int CountryID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCountryTableAdapter())
            {
                _ObjTA.ActiveDeactiveCountry(CountryID);
            }
        }










    }
}

