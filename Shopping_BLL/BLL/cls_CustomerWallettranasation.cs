using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class cls_CustomerWallettranasation
    {
        public DataTable GetwalletTransaction(int customerid)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tbl_WalletTransactionTableAdapter objwall = new AustraliaDAL.DataSet1TableAdapters.tbl_WalletTransactionTableAdapter())
            {
                dt = objwall.GetwalletTransaction(customerid);
            }
            return dt;
        }


    }
}
