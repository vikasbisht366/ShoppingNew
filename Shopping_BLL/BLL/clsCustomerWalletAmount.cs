using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BLL
{
    public class clsCustomerWalletAmount
    {

        public DataTable AddEditWalletAmount(int WalletID,string debit,string credit,string Amount,string CustomerID )
        {
           
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.ShoppingwalletTableAdapter objShoppingwallet = new AustraliaDAL.DataSet1TableAdapters.ShoppingwalletTableAdapter())
            {
                dt = objShoppingwallet.AddEditWalletAmount(WalletID,debit,credit,Amount,CustomerID);
            }
            return dt;
        }
        public DataTable GetCustomerWalletAmount(string CustomerID)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.ShoppingwalletTableAdapter objShoppingwallet = new AustraliaDAL.DataSet1TableAdapters.ShoppingwalletTableAdapter())
            {
                dt = objShoppingwallet.GetCustomerWalletAmount(CustomerID);
            }
            return dt;
        }
        

    }
}
