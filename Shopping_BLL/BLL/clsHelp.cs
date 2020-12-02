using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsHelp
    {
        public int AddEditHelp(int HelpID,string Question,string Answer,int HelpCategoryID)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter objHelp = new AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter())
            {
                dt = objHelp.AddEditHelp(HelpID, Question, Answer, HelpCategoryID);
            }
            id = Convert.ToInt32(dt.Rows[0]["HelpID"].ToString());
            return id;
        }
        public DataTable GetHelp(int HelpID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter objHelp = new AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter())
            {
                dt = objHelp.GetHelp(HelpID);
            }
            return dt;
        }
        public DataTable GetAllHelp(int HelpID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter objHelp = new AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter())
            {
                dt = objHelp.GetAllHelp(HelpID);
            }
            return dt;
        }
        public void DeleteHelp(int HelpID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter objHelp = new AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter())
            {
                objHelp.DeleteHelp(HelpID);
            }

        }
        public void ActiveDeactiveHelp(int HelpID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter objHelp = new AustraliaDAL.DataSet1TableAdapters.tblHelpTableAdapter())
            {
                objHelp.ActiveDeactiveHelp(HelpID);
            }

        }
    }
}
