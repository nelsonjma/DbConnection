using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace DbConnection
{
    class OdbcConn
    {
        /*********************** GET DATA ***********************/
        static public DataTable GetData(string strConn, string strSql)
        {
            DataTable dt = new DataTable("td");

            using (OdbcConnection conn = new OdbcConnection(strConn))
            {
                conn.Open();

                OdbcCommand cmd = null;
                OdbcDataAdapter da = null;

                try
                {
                    cmd = new OdbcCommand(strSql, conn);
                    da = new OdbcDataAdapter { SelectCommand = cmd };

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

        static public DataTable GetData(string strConn, string strSql, int timeout)
        {
            DataTable dt = new DataTable("td");

            using (OdbcConnection conn = new OdbcConnection(strConn))
            {
                conn.Open();

                OdbcCommand cmd = null;
                OdbcDataAdapter da = null;

                try
                {
                    cmd = new OdbcCommand(strSql, conn) { CommandTimeout = timeout };
                    da = new OdbcDataAdapter { SelectCommand = cmd };

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

            using (OdbcConnection conn = new OdbcConnection(strConn))
            {
                conn.Open();

                OdbcCommand cmd = null;
                OdbcDataAdapter da = null;

                try
                {
                    cmd = new OdbcCommand(strSql, conn);
                    da = new OdbcDataAdapter { SelectCommand = cmd };

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

            using (OdbcConnection conn = new OdbcConnection(strConn))
            {
                conn.Open();

                OdbcCommand cmd = null;
                OdbcDataAdapter da = null;

                try
                {
                    cmd = new OdbcCommand(strSql, conn) { CommandTimeout = timeout };
                    da = new OdbcDataAdapter { SelectCommand = cmd };

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

        static public DataTable GetData(OdbcConnection conn, string strSql)
        {
            DataTable dt = new DataTable("td");

            using (conn)
            {
                OdbcCommand cmd = null;
                OdbcDataAdapter da = null;

                try
                {
                    cmd = new OdbcCommand(strSql, conn);
                    da = new OdbcDataAdapter { SelectCommand = cmd };

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
            using (OdbcConnection conn = new OdbcConnection(strConn))
            {
                OdbcCommand objCmd = null;
                conn.Open();

                try
                {
                    foreach (string sql in sqlList)
                    {
                        objCmd = new OdbcCommand(sql, conn);
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
            using (OdbcConnection conn = new OdbcConnection(strConn))
            {
                OdbcCommand objCmd = null;
                conn.Open();

                try
                {
                    objCmd = new OdbcCommand(sql, conn);
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

        static public void SetData(OdbcConnection conn, string sql)
        {
            using (conn)
            {
                OdbcCommand cmd = null;

                try
                {
                    cmd = new OdbcCommand(sql, conn);
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

        static public void SetData(OdbcConnection conn, List<string> sqlList)
        {
            using (conn)
            {
                OdbcCommand objCmd = null;

                try
                {
                    foreach (string sql in sqlList)
                    {
                        objCmd = new OdbcCommand(sql, conn);
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
