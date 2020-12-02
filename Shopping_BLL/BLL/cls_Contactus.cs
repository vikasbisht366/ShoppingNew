using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    class cls_Contactus
    {
        public void AddEditContactDetails(int id, string Name, string Mobile, string Addr, string Email)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_ContactUsTableAdapter objcontact = new AustraliaDAL.DataSet1TableAdapters.tbl_ContactUsTableAdapter())
            {
                dt = objcontact.AddEditContactDetails(id, Name, Mobile, Addr, Email);
            }
        }
    }
}
