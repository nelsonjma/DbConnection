using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace DbConnection
{
    class OleConn
    {
        /*********************** GET DATA ***********************/
        static public DataTable GetData(string strConn, string strSql, int timeout)
        {
            DataTable dt = new DataTable("td");

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                OleDbCommand cmd = null;
                OleDbDataAdapter da = null;

                try
                {
                    cmd = new OleDbCommand(strSql, conn) { CommandTimeout = timeout };
                    da = new OleDbDataAdapter { SelectCommand = cmd };

                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("error getting data " + ex.Message);
                }
                finally
                {
                    if (da != null) { da.Dispose(); }
                    if (cmd != null) { cmd.Dispose(); }

                    conn.Close();
                }
            }
        }

        static public DataTable GetData(string strConn, string strSql)
        {
            DataTable dt = new DataTable("td");

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                OleDbCommand cmd = null;
                OleDbDataAdapter da = null;

                try
                {
                    cmd = new OleDbCommand(strSql, conn);
                    da = new OleDbDataAdapter { SelectCommand = cmd };

                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("error getting data " + ex.Message);
                }
                finally
                {
                    if (da != null) { da.Dispose(); }
                    if (cmd != null) { cmd.Dispose(); }

                    conn.Close();
                }
            }
        }

        static public DataTable GetData(string strConn, string strSql, int startRecord, int maxRecords)
        {
            DataSet ds = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                OleDbCommand cmd = null;
                OleDbDataAdapter da = null;

                try
                {
                    cmd = new OleDbCommand(strSql, conn);
                    da = new OleDbDataAdapter { SelectCommand = cmd };

                    da.Fill(ds, startRecord, maxRecords, "tb");

                    return ds.Tables["tb"];
                }
                catch (Exception ex)
                {
                    throw new Exception("error getting data " + ex.Message);
                }
                finally
                {
                    if (da != null) { da.Dispose(); }
                    if (cmd != null) { cmd.Dispose(); }

                    conn.Close();
                }
            }
        }

        static public DataTable GetData(string strConn, string strSql, int startRecord, int maxRecords, int timeout)
        {
            DataSet ds = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                OleDbCommand cmd = null;
                OleDbDataAdapter da = null;

                try
                {
                    cmd = new OleDbCommand(strSql, conn) { CommandTimeout = timeout };
                    da = new OleDbDataAdapter { SelectCommand = cmd };

                    da.Fill(ds, startRecord, maxRecords, "tb");

                    return ds.Tables["tb"];
                }
                catch (Exception ex)
                {
                    throw new Exception("error getting data " + ex.Message);
                }
                finally
                {
                    if (da != null) { da.Dispose(); }
                    if (cmd != null) { cmd.Dispose(); }

                    conn.Close();
                }
            }
        }

        static public DataTable GetData(OleDbConnection conn, string strSql)
        {
            DataTable dt = new DataTable("td");

            using (conn)
            {
                OleDbCommand cmd = null;
                OleDbDataAdapter da = null;

                try
                {
                    cmd = new OleDbCommand(strSql, conn);
                    da = new OleDbDataAdapter { SelectCommand = cmd };

                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("error getting data " + ex.Message);
                }
                finally
                {
                    if (da != null) { da.Dispose(); }
                    if (cmd != null) { cmd.Dispose(); }

                    conn.Close();
                }
            }
        }

        /*********************** SET DATA ***********************/
        static public void SetData(string strConn, List<string> sqlList)
        {
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                OleDbCommand objCmd = null;
                conn.Open();

                try
                {
                    foreach (string sql in sqlList)
                    {
                        objCmd = new OleDbCommand(sql, conn);
                        objCmd.ExecuteNonQuery();
                        objCmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("error setting data " + ex.Message);
                }
                finally
                {
                    if (objCmd != null) { objCmd.Dispose(); }

                    conn.Close();
                }
            }
        }

        static public void SetData(string strConn, string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                OleDbCommand objCmd = null;
                conn.Open();

                try
                {
                    objCmd = new OleDbCommand(sql, conn);
                    objCmd.ExecuteNonQuery();
                    objCmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception("error setting data " + ex.Message);
                }
                finally
                {
                    if (objCmd != null) { objCmd.Dispose(); }

                    conn.Close();
                }
            }
        }

        static public void SetData(OleDbConnection conn, string sql)
        {
            using (conn)
            {
                OleDbCommand cmd = null;

                try
                {
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception("error setting data " + ex.Message);
                }
                finally
                {
                    if (cmd != null) { cmd.Dispose(); }
                }
            }
        }

        static public void SetData(OleDbConnection conn, List<string> sqlList)
        {
            using (conn)
            {
                OleDbCommand objCmd = null;

                try
                {
                    foreach (string sql in sqlList)
                    {
                        objCmd = new OleDbCommand(sql, conn);
                        objCmd.ExecuteNonQuery();
                        objCmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("error setting data " + ex.Message);
                }
                finally
                {
                    if (objCmd != null) { objCmd.Dispose(); }
                }
            }
        }
    }
}
    
