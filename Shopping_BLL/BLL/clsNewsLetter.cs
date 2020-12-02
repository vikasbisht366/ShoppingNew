using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;
namespace BLL
{
   public class clsNewsLetter
    {
        public int AddEditNewsLetter(int NewsLetterID,string Name,string Email,string IPAddress)
        {
            int id;
            DataTable dt = new DataTable();
       
            using (AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter objNewsLetter = new AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter())
            {
                dt = objNewsLetter.AddEditNewsLetter(NewsLetterID, Name, Email, IPAddress);
            }
            id = Convert.ToInt32(dt.Rows[0]["NewsLetterID"].ToString());
            return id;
        }
        public DataTable GetNewsLetter(int NewsLetterID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter objNewsLetter = new AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter())
            {
                dt = objNewsLetter.GetNewsLetter(NewsLetterID);
            }
            return dt;
        }
        public DataTable GetAllNewsLetter(int NewsLetterID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter objNewsLetter = new AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter())
            {
                dt = objNewsLetter.GetAllNewsLetter(NewsLetterID);
            }
            return dt;
        }
        public void DeleteNewsLetter(int NewsLetterID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter objNewsLetter = new AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter())
            {
                objNewsLetter.DeleteNewsLetter(NewsLetterID);
            }

        }
        public void ActiveDeactiveNewsLetter(int NewsLetterID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter objNewsLetter = new AustraliaDAL.DataSet1TableAdapters.tblNewsLetterTableAdapter())
            {
                objNewsLetter.ActiveDeactiveNewsLetter(NewsLetterID);
            }
        }

    }
}
