using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
   public class clsRecieps
    {
       public int AddEditRecieps(int ReciepsID, string Title,string Description,string DocsUrl)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter objRecieps=new AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter())
            {
                dt = objRecieps.AddEditRecieps(ReciepsID, Title, Description, DocsUrl);
            }
            id = Convert.ToInt32(dt.Rows[0]["ReciepsID"].ToString());
            return id;
        }
        public DataTable GetRecieps(int ReciepsID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter objRecieps=new AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter())
            {
                dt = objRecieps.GetRecieps(ReciepsID);
            }
            return dt;
        }
        public DataTable GetAllRecieps(int ReciepsID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter objRecieps=new AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter())
            {
                dt = objRecieps.GetAllRecieps(ReciepsID);
            }
            return dt;
        }
        public void DeleteRecieps(int ReciepsID)
        {

             using (AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter objRecieps=new AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter())
            {
                objRecieps.DeleteRecieps(ReciepsID);
            }

        }
        public void ActiveDeactiveRecieps(int ReciepsID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter objRecieps=new AustraliaDAL.DataSet1TableAdapters.tblReciepsTableAdapter())
            {
                objRecieps.ActiveDeactiveRecieps(ReciepsID);
            }
        }

    }
 }

