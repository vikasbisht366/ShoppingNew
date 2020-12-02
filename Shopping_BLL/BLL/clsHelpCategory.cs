using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsHelpCategory
    {
        public int AddEditHelpCategory(int HelpCategoryID,string Title,string ImageUrl)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter objHelpCategory = new AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter())
            {
                dt = objHelpCategory.AddEditHelpCategory(HelpCategoryID, Title, ImageUrl);
            }
            id = Convert.ToInt32(dt.Rows[0]["HelpCategoryID"].ToString());
            return id;
        }
        public DataTable GetHelpCategory(int HelpCategoryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter objHelpCategory = new AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter())
            {
                dt = objHelpCategory.GetHelpCategory(HelpCategoryID);
            }
            return dt;
        }
        public DataTable GetAllHelpCategory(int HelpCategoryID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter objHelpCategory = new AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter())
            {
                dt = objHelpCategory.GetAllHelpCategory(HelpCategoryID);
            }
            return dt;
        }
        public void DeleteHelpCategory(int HelpCategoryID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter objHelpCategory = new AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter())
            {
                objHelpCategory.DeleteHelpCategory(HelpCategoryID);
            }

        }
        public void ActiveDeactiveHelpCategory(int HelpCategoryID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter objHelpCategory = new AustraliaDAL.DataSet1TableAdapters.tblHelpCategoryTableAdapter())
            {
                objHelpCategory.ActiveDeactiveHelpCategory(HelpCategoryID);
            }

        }
    }
}
