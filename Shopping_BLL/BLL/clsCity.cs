using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsCity
    {

        public int AddEditCity(int CityID, string CityName, int StateID)
        {
            int pageval;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
            {
                dt = _ObjTA.AddEditCity(CityID,CityName,StateID);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["CityID"].ToString());
            return pageval;
        }
        public DataTable GetCity(int CityID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
            {
                dt = _ObjTA.GetCity(CityID);
            }
            return dt;
        }
        public DataTable GetCityAll(int CityID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
            {
                dt = _ObjTA.GetCityAll(CityID);
            }
            return dt;
        }
        public DataTable GetCityByStateID(int StateID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
            {
                dt = _ObjTA.GetCitybyStateID(StateID);
            }
            return dt;
        }
        //public DataTable GetCityAutoComplete(int CityID, string CityName, int StateID)
        //{
        //    DataTable dt = new DataTable();
        //    using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
        //    {
        //        dt = _ObjTA.GetCityAutoComplete(CityID,CityName,StateID);
        //    }
        //    return dt;
        //}
        //public DataTable GetCityIDbyCityName(string CityName)
        //{
        //    DataTable dt = new DataTable();
        //    using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
        //    {
        //        dt = _ObjTA.GetCityIDbyCityName(CityName);
        //    }
        //    return dt;
        //}
        //public DataTable GetCitybyStateID_CityName(int StateID, string CityName)
        //{
        //    DataTable dt = new DataTable();
        //    using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
        //    {
        //        dt = _ObjTA.GetCitybyStateID_CityName(StateID,CityName);
        //    }
        //    return dt;
        //}
        public void DeleteCity(int CityID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
            {
                _ObjTA.DeleteCity(CityID);
            }
        }
        public void ActiveDeactiveCity(int CityID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblCityTableAdapter())
            {
                _ObjTA.ActiveDeactiveCity(CityID);
            }
        }










    }
}

