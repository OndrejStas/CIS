using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization; 

namespace CIS.Classes
{
    public class DataMethods
    {
        public List<DataModel.KRTy> GetKrty()
        {
            List<DataModel.KRTy> _res = new List<DataModel.KRTy>();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TISconnectionString"].ConnectionString;
            SqlConnection c = new SqlConnection(connStr);
            String query = "select * from EEZIExtZadost";
            List<String[]> res = DataApi.GetVector(c,query,true);
            return _res;

        }

        public static DataTable GetOsoby()
        {

            DataTable dt = new DataTable();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["CISconnectionString"].ConnectionString;

            if (!string.IsNullOrEmpty(connStr))
            {
                dt = DataApi.ExecuteReader("select * from OSOby", connStr);
                return dt;
            }

            return null;
           

        }
        public List<String[]> GetKrtyS()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TISconnectionString"].ConnectionString;
            SqlConnection c = new SqlConnection(connStr);
            String query = "select * from EEZIExtZadost";
            List<String[]> res = DataApi.GetVector(c, query, true);
            return res;
        }
        public List<Object[]> GetKrtyO()
        {
            List<Object[]> _res ;
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TISconnectionString"].ConnectionString;
            SqlConnection c = new SqlConnection(connStr);
            String query = "select * from EEZIExtZadost";
            _res = DataApi.GetVectorOfObjects(c, query, true);
            return _res;
        }

    }
}