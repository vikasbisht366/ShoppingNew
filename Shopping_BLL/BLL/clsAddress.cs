using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class clsAddress
    {

        public void AddEditAddressMaster(int id, string CustomerID, string Name, string Mobile_No, string Address, string Country, string State, string City, string Zip, string Locality, string LandMark, string Alternate_MobileNo)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter objbrand = new AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter())
            {
                dt = objbrand.AddEditAddressMaster(id, CustomerID, Name, Mobile_No, Address, Country, State, City, Zip, Locality, LandMark, Alternate_MobileNo);
            }
        }

        public DataTable GetAddress(string CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter objAddress = new AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter())
            {
                dt = objAddress.GetAddress(CustomerID);
            }
            return dt;
        }

        public DataTable GetAddressForEdit(int id, string CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter objAddress = new AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter())
            {
                dt = objAddress.GetAddressForEdit(id, CustomerID);
            }
            return dt;
        }
        public DataTable UpdateAddressforDeliver(int id, string CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter objAddress = new AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter())
            {
                dt = objAddress.UpdateAddressforDeliver(id, CustomerID);
            }
            return dt;
        }

        public DataTable DeleteAddress(int id, string CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter objAddress = new AustraliaDAL.DataSet1TableAdapters.tblAddressMasterTableAdapter())
            {
                dt = objAddress.DeleteAddress(id, CustomerID);
            }
            return dt;
        }

    }
}
