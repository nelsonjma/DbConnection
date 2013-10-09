using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DbConnection
{
    class SqliteConn
    {
        /*********************** GET DATA ***********************/
        static public DataTable GetData(string strConn, string strSql)
        {
            DataTable dt = new DataTable("td");

            using (SQLiteConnection conn = new SQLiteConnection(strConn))
            {
                conn.Open();

                SQLiteCommand cmd = null;
                SQLiteDataAdapter da = null;

                try
                {
                    cmd = new SQLiteCommand(strSql, conn);
                    da = new SQLiteDataAdapter { SelectCommand = cmd };

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

            using (SQLiteConnection conn = new SQLiteConnection(strConn))
            {
                conn.Open();

                SQLiteCommand cmd = null;
                SQLiteDataAdapter da = null;

                try
                {
                    cmd = new SQLiteCommand(strSql, conn) { CommandTimeout = timeout };
                    da = new SQLiteDataAdapter { SelectCommand = cmd };

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

            using (SQLiteConnection conn = new SQLiteConnection(strConn))
            {
                conn.Open();

                SQLiteCommand cmd = null;
                SQLiteDataAdapter da = null;

                try
                {
                    cmd = new SQLiteCommand(strSql, conn);
                    da = new SQLiteDataAdapter { SelectCommand = cmd };

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

            using (SQLiteConnection conn = new SQLiteConnection(strConn))
            {
                conn.Open();

                SQLiteCommand cmd = null;
                SQLiteDataAdapter da = null;

                try
                {
                    cmd = new SQLiteCommand(strSql, conn) { CommandTimeout = timeout };
                    da = new SQLiteDataAdapter { SelectCommand = cmd };

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

        static public DataTable GetData(SQLiteConnection conn, string strSql)
        {
            DataTable dt = new DataTable("td");

            using (conn)
            {
                SQLiteCommand cmd = null;
                SQLiteDataAdapter da = null;

                try
                {
                    cmd = new SQLiteCommand(strSql, conn);
                    da = new SQLiteDataAdapter { SelectCommand = cmd };

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
            using (SQLiteConnection conn = new SQLiteConnection(strConn))
            {
                SQLiteCommand objCmd = null;
                conn.Open();

                try
                {
                    foreach (string sql in sqlList)
                    {
                        objCmd = new SQLiteCommand(sql, conn);
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
            using (SQLiteConnection conn = new SQLiteConnection(strConn))
            {
                SQLiteCommand objCmd = null;
                conn.Open();

                try
                {
                    objCmd = new SQLiteCommand(sql, conn);
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

        static public void SetData(SQLiteConnection conn, string sql)
        {
            using (conn)
            {
                SQLiteCommand cmd = null;

                try
                {
                    cmd = new SQLiteCommand(sql, conn);
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

        static public void SetData(SQLiteConnection conn, List<string> sqlList)
        {
            using (conn)
            {
                SQLiteCommand objCmd = null;

                try
                {
                    foreach (string sql in sqlList)
                    {
                        objCmd = new SQLiteCommand(sql, conn);
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