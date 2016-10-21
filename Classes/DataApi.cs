using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace CIS.Classes
{
    public class DataApi
    {

        public static DataTable ExecuteReader(string script, string connstr)
        {
            try
            {
                DataTable reso = new DataTable();
                using (SqlConnection sqlConnection1 = new SqlConnection(connstr))
                {
                    using (SqlCommand myScalar = new SqlCommand(script, sqlConnection1))
                    {
                        sqlConnection1.Open();
                        myScalar.CommandTimeout = 100;
                        reso.Load(myScalar.ExecuteReader());
                        myScalar.Dispose();
                        sqlConnection1.Close();
                        return reso;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debugger.Break();
                return null;
            }
        }
        public static object ExecuteScalar(string script, string connstr)
        {
            try
            {
                using (SqlConnection sqlConnection1 = new SqlConnection(connstr))
                {
                    sqlConnection1.Open();
                    using (SqlCommand myScalar = new SqlCommand(script, sqlConnection1))
                    {
                        myScalar.CommandTimeout = 100;
                        object reso = myScalar.ExecuteScalar();
                        myScalar.Dispose();
                        sqlConnection1.Close();
                        return reso;
                    }

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debugger.Break();
                return null;
            }

        }
        public static SqlDataReader GetReader(string script, string con2)
        {

            SqlConnection con = new SqlConnection(con2);
            SqlCommand cmd = new SqlCommand(script, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public static string GetJsonFromDt(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();

        }
        public static string GetStringFromDt(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append(string.Format("{0}\"draw\":{1} , \"recordsTotal\":{2} , \"recordsFiltered\":{3}", "{",1, table.Rows.Count, table.Rows.Count));
                JSONString.Append(",\"data\":[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            if (j == 0)
                            {
                               
                                //JSONString.Append("\"" + table.Columns[j].ToString() + "\""+":" + "\"" + table.Rows[i][j].ToString() + "\",");
                                JSONString.Append("\"" + "DT_RowId" + "\"" + ":" + "\"" + table.Rows[i][j].ToString() + "\",");
                                
                            }
                            else
                            {
                                JSONString.Append("\"" + table.Columns[j].ToString() + "\"" + ":" + "\"" + table.Rows[i][j].ToString() + "\",");
                            }
                            
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ToString() + "\"" + ":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("] }");
            }
            return JSONString.ToString();
            //if (table.Rows.Count > 0)
            //{
            //    JSONString.Append(string.Format("\"draw\":{0} , \"recordsTotal\":{1} , \"recordsFiltered\":{2}", 1, table.Rows.Count, table.Rows.Count));
            //    JSONString.Append("\"data\":[");
            //    for (int i = 0; i < table.Rows.Count; i++)
            //    {
            //        JSONString.Append("[");
            //        for (int j = 0; j < table.Columns.Count; j++)
            //        {
            //            if (j < table.Columns.Count - 1)
            //            {
            //                JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
            //            }
            //            else if (j == table.Columns.Count - 1)
            //            {
            //                JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
            //            }
            //        }
            //        if (i == table.Rows.Count - 1)
            //        {
            //            JSONString.Append("]");
            //        }
            //        else
            //        {
            //            JSONString.Append("],");
            //        }
            //    }
            //    JSONString.Append("] }");
            //}
        }

        public static string GetStringFromDtHeader(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append(string.Format("{0}\"draw\":{1} , \"recordsTotal\":{2} , \"recordsFiltered\":{3}", "{", 1, table.Rows.Count, table.Rows.Count));
                JSONString.Append(",\"data\":[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("[");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            if (j == 0)
                            {
                                JSONString.Append("\"" + table.Rows[i][j].ToString() + "\",");

                            }
                            else
                            {
                                JSONString.Append("\"" + table.Rows[i][j].ToString() + "\",");
                            }

                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("]");
                    }
                    else
                    {
                        JSONString.Append("],");
                    }
                }
                JSONString.Append("] }");
            }
            return JSONString.ToString();
           
        }


        public static List<String[]> GetVector(DbConnection db, String query, bool def)
        {
            List<String[]> _res = new List<string[]>();
            db.Open();
            DbCommand c = new SqlCommand();
            c.Connection = db;
            c.CommandText = query;
            DbDataReader r = c.ExecuteReader();
            String[] res;
            while (r.Read())
            {
                int cnt = r.FieldCount;
                res = new String[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    Object o = r[i];
                    res[i] = o != null ? o.ToString() : null;
                }
                _res.Add(res);
            }
            r.Close();
            db.Close();
            return _res;
        }
        public static List<Object[]> GetVectorOfObjects(DbConnection db, String query, bool def)
        {
            List<Object[]> _res = new List<object[]>();
            db.Open();
            DbCommand c = new SqlCommand();
            c.Connection = db;
            c.CommandText = query;
            DbDataReader r = c.ExecuteReader();
            Object[] res;
            while (r.Read())
            {
                int cnt = r.FieldCount;
                res = new Object[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    //Object o = r[i];
                    //res[i] = o != null ? o.ToString() : null;
                    res[i] = r[i];
                }
                _res.Add(res);
            }

            r.Close();
            db.Close();
            return _res;
        }
        public static System.Data.DataTable GetDataTable(string dbcstring, string query)
        {
            SqlConnection db = new SqlConnection(dbcstring);
            System.Data.DataTable table = new System.Data.DataTable();
            System.Data.SqlClient.SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            adapter.Fill(table);
            return table;
        }
        
        /**
         * 
         * Vraci pocet affected rows
         * 
         * */
        //public static int ExecuteUpdate(GRC_ZaznamySJEntities db, String u)
        //{
        //    return GetObjectContext(db).ExecuteStoreCommand(u);
        //    /*
        //    DbCommand c = new SqlCommand();
        //    checkConnectionState(db.Database.Connection);
        //    if (T!=null) c.Transaction=T;
        //    c.Connection = db.Database.Connection;
        //    c.CommandText = u;
        //    return c.ExecuteNonQuery();*/
        //}

        //public static DbDataReader GetDbDataReader(string db, String cSELECT)
        //{
        //    DbCommand c = new SqlCommand();
        //    //DataApi.checkConnectionState(db.Database.Connection);
        //    DataApi.ExecuteUpdate(db, cSELECT);
        //    c.Connection = db.Database.Connection;
        //    c.CommandText = cSELECT;
        //    checkConnectionState(db.Database.Connection);
        //    DbDataReader r = c.ExecuteReader();
        //    return r;
        //}
        


    }
}