using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;

namespace BLL
{
    public class StoreProc
    {

        #region LoginUser
        public DataTable loginUser(string userid, string password)
        {
            DataTable dt = new DataTable();
            using(AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter _ObjTA=new AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter())
          
            {
                dt = _ObjTA.loginUser(userid, password);
            }
            return dt;
        }
        public int UpdateAdminPassword(int AdminID, string NewPassword, string OldPassword)
        {
            int pageval;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter())
            {
                dt = _ObjTA.UpdateAdminPassword(AdminID, NewPassword, OldPassword);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["userid"].ToString());
            return pageval;
        }
        #endregion

        #region StaticPage Functions
        public int AddEditStaticPage(int pageid, string pagenam, string pagedesc, string pageTitle, string Mtitle, string MKey, string MDesc, bool isactive, string IPaddr, int ParentId)
        {
            int pageval;
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter())
            {
                dt = _ObjTA.AddeditStaticpage(pageid, pagenam, pagedesc, pageTitle, Mtitle, MKey, MDesc, isactive, IPaddr, ParentId);
            }
            pageval = Convert.ToInt32(dt.Rows[0]["pageid"].ToString());
            return pageval;
        }

        public DataTable GetStaticPages(int pageid)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter())
            {
                dt = _ObjTA.GetStaticPageAll(pageid);
            }
            return dt;
        }

        public DataTable GetVirtualPath(string virtualURl)
        {
            DataTable dt = new DataTable();
            using (AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter _ObjTA = new AustraliaDAL.DataSet1TableAdapters.tblStaticTableAdapter())
            {
                dt = _ObjTA.getPhyPath(virtualURl);
            }
            return dt;
        }
    
        
        #endregion


       
    }
}
