using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class ClscontactUs
    {
        public void AddEditContactDetails(int id,string name,string mobile,string address,string email)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_ContactUsTableAdapter objcontact = new AustraliaDAL.DataSet1TableAdapters.tbl_ContactUsTableAdapter())
            {
                objcontact.AddEditContactDetails(id,name,mobile,address,email);
            }
        }
    }
}
