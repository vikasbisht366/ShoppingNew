using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class clsExtra
    {
        public int AddEditExtra(int ExtraID, string TopLine, string Number, string SearchExample, string Extra1, string Extra2, string Extra3, string Description, string CompanyName, string TagLine, string LogoName, string LogoURL, string LogoImage, string Ads1Name, string Ads1URL, string Ads1Image, string Ads2Name, string Ads2URL, string Ads2Image, string Twitter, string Facebook, string Youtube, string LinkedIn, string GooglePlus, string Copyright, string Designby)
        {
            int id;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter objExtra=new AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter())
            {
                dt = objExtra.AddEditExtra(ExtraID, TopLine, Number, SearchExample, Extra1, Extra2, Extra3, Description, CompanyName, TagLine, LogoName, LogoURL, LogoImage, Ads1Name, Ads1URL, Ads1Image, Ads2Name, Ads2URL, Ads2Image, Twitter, Facebook, Youtube, LinkedIn, GooglePlus, Copyright, Designby);
            }
            id = Convert.ToInt32(dt.Rows[0]["ExtraID"].ToString());
            return id;
        }
        public DataTable GetExtra(int ExtraID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter objExtra=new AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter())
            {
                dt = objExtra.GetExtra(ExtraID);
            }
            return dt;
        }
    
     
        public DataTable GetAllExtra(int ExtraID)
        {
            DataTable dt = new DataTable();
             using (AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter objExtra=new AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter())
            {
                dt = objExtra.GetAllExtra(ExtraID);
            }
            return dt;
        }
        public void DeleteExtra(int ExtraID)
        {

             using (AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter objExtra=new AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter())
            {
                objExtra.DeleteExtra(ExtraID);
            }

        }
        public void ActiveDeactiveExtra(int ExtraID)
        {

            using (AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter objExtra=new AustraliaDAL.DataSet1TableAdapters.tblExtraTableAdapter())
            {
                objExtra.ActiveDeactiveExtra(ExtraID);
            }
        }
      

    }
 }

