using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsState
    {

        public int AddEditState(int StateID, string StateName, int CountryID)
        {
            int pageval;
            DataTable dt = new DataTable();
          
            using (AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter())
            {
                dt = _ObjTA.AddEditState(StateID,StateName,CountryID);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["StateID"].ToString());
            return pageval;
        }
        public DataTable GetState(int StateID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter())
            {
                dt = _ObjTA.GetState(StateID);
            }
            return dt;
        }
        public DataTable GetStateAll(int StateID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter())
            {
                dt = _ObjTA.GetStateAll(StateID);
            }
            return dt;
        }
        public DataTable GetStateByCountryID(int CountryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter())
            {
                dt = _ObjTA.GetStateByCountryID(CountryID);
            }
            return dt;
        }
        public DataTable GetStateAllByCountryID(int CountryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter())
            {
                dt = _ObjTA.GetStateAllByCountryID(CountryID);
            }
            return dt;
        }
        public void DeleteState(int StateID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter())
            {
                _ObjTA.DeleteState(StateID);
            }
        }
        public void ActiveDeactiveState(int StateID)
        {
            using (AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStateTableAdapter())
            {
                _ObjTA.ActiveDeactiveState(StateID);
            }
        }










    }
}

