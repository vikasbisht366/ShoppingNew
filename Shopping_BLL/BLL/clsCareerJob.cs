using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsCareerJob
    {
        public int AddEditCareerJob(int CareerJobID,string Title,string Qualification,string jobType,string Location,string Experience,int NoOfPosition,string Skills)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter objCareerJob = new AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter())
            {
                dt = objCareerJob.AddEditCareerJob(CareerJobID, Title, Qualification, jobType, Location, Experience, NoOfPosition, Skills);
            }
            id = Convert.ToInt32(dt.Rows[0]["CareerJobID"].ToString());
            return id;
        }
        public DataTable GetCareerJob(int CareerJobID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter objCareerJob = new AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter())
            {
                dt = objCareerJob.GetCareerJob(CareerJobID);
            }
            return dt;
        }
        public DataTable GetAllCareerJob(int CareerJobID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter objCareerJob = new AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter())
            {
                dt = objCareerJob.GetAllCareerJob(CareerJobID);
            }
            return dt;
        }
        public void DeleteCareerJob(int CareerJobID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter objCareerJob = new AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter())
            {
                objCareerJob.DeleteCareerJob(CareerJobID);
            }

        }
        public void ActiveDeactiveCareerJob(int CareerJobID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter objCareerJob = new AustraliaDAL.DataSet1TableAdapters.tblCareerJobTableAdapter())
            {
                objCareerJob.ActiveDeactiveCareerJob(CareerJobID);
            }

        }
    }
}
