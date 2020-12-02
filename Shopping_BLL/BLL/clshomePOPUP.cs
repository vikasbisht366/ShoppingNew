using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class clshomePOPUP
    {
        public DataTable ManageHomePopup(int id, string title)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter objpopup = new AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter())
            {
                dt = objpopup.ManageHomePopup(id, title);
            }
            return dt;
        }
        public DataTable GetHomePopup(int id)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter objpop = new AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter())
            {
                dt = objpop.GetHomePopup(id);
            }
            return dt;
        }
        public DataTable GetAllHomePopup()
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter objpop = new AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter())
            {
                dt = objpop.GetAllHomePopup();
            }
            return dt;
        }
        public DataTable DeleteHomePopup(int id)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter objpop = new AustraliaDAL.DataSet1TableAdapters.tblHomePOPUPTableAdapter())
            {
                dt = objpop.DeleteHomePopup(id);
            }
            return dt;
        }


    }
}
