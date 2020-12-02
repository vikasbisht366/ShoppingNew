using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AustraliaDAL;
using System.Configuration;
using System.IO;


namespace BLL
{
    public class Cls_DataAccess : Cls_Comman
    {
        SqlConnection Conn = new SqlConnection();

        public static DataTable dtusermaster;
        public static string ConnectionString = AustraliaDAL.Cls_ConnectionString.GetBayrueConnectionString();


        private void ConnectionOpen()
        {
            Conn.ConnectionString = ConnectionString;
            Conn.Open();

        }
        private void ConnectionClosed()
        {
            if (Conn != null)
            {
                Conn.Close();
            }
        }

        public int ExecuteQuery(string Query)
        {
            int RetrunID;
            ConnectionOpen();
            SqlCommand cmd1 = new SqlCommand(Query, Conn);
            RetrunID = cmd1.ExecuteNonQuery();
            ConnectionClosed();
            return RetrunID;
        }
        public string ExecuteStringScalar(string Query)
        {
            string RetrunStr;
            ConnectionOpen();
            SqlCommand cmd1 = new SqlCommand(Query, Conn);
            RetrunStr = Convert.ToString(cmd1.ExecuteScalar());
            ConnectionClosed();
            return RetrunStr;
        }
        public int ExecuteIntScalar(string Query)
        {
            int RetrunStr;
            ConnectionOpen();
            SqlCommand cmd1 = new SqlCommand(Query, Conn);
            RetrunStr = Convert.ToInt32(cmd1.ExecuteScalar());
            Conn.Close();
            ConnectionClosed();
            return RetrunStr;
        }
        public DataTable GetDatatable(string Query)
        {
            ConnectionOpen();
            SqlCommand cmd1 = new SqlCommand(Query, Conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            ConnectionClosed();
            return ds.Tables[0];
        }
        public DataSet GetDataSet(string Query)
        {
            ConnectionOpen();
            SqlCommand cmd1 = new SqlCommand(Query, Conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            ConnectionClosed();
            return ds;
        }
    }
}
