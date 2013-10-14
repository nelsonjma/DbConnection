using System;
using System.Data;

namespace DbConnection
{
    public class RunQuery
    {
        private int _startRecord;
        private int _maxRecords;

        private int _timeout;

        public RunQuery()
        {
            _startRecord = -1;
            _maxRecords = -1;
            _timeout = -1;
        }

        /************************ GET/SET ************************/
        /// <summary>
        /// Only usable in Sqlite and Oledb
        /// </summary>
        public int StartRecord
        {
            get { return _startRecord; }
            set { _startRecord = value; }
        }

        /// <summary>
        /// Only usable in Sqlite and Oledb
        /// </summary>
        public int MaxRecords
        {
            get { return _maxRecords; }
            set { _maxRecords = value; }
        }

        /// <summary>
        /// Only usable in Sqlite and Oledb
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        /************************ PRIVATE ************************/
        private string QuerySelector(string conn)
        {
            conn = conn.Trim().ToLower();

            if (conn.Contains("provider="))
                return "oledb";

            if (conn.Contains("data source=") && conn.Contains("version="))
                return "sqlite";

            if (conn.Contains("driver=") || conn.Contains("dsn="))
                return "odbc";

            return string.Empty;
        }

        /*************** GET DATA ***************/
        /// <summary>
        /// Gets data from Sqlite databases
        /// </summary>
        private DataTable GetSqliteData(string conn, string sql)
        {
            if (_startRecord != -1 && _maxRecords != -1)
            {
                return _timeout == -1
                                    ? SqliteConn.GetData(conn, sql, _startRecord, _maxRecords)
                                    : SqliteConn.GetData(conn, sql, _startRecord, _maxRecords, _timeout);
            }
            else
            {
                return _timeout == -1
                                    ? SqliteConn.GetData(conn, sql)
                                    : SqliteConn.GetData(conn, sql, _timeout);
            }
        }

        /// <summary>
        /// Gets data from databases that support oledb
        /// </summary>
        private DataTable GetOleDbData(string conn, string sql)
        {
            if (_startRecord != -1 && _maxRecords != -1)
            {
                return _timeout == -1
                                    ? OleConn.GetData(conn, sql, _startRecord, _maxRecords)
                                    : OleConn.GetData(conn, sql, _startRecord, _maxRecords, _timeout);
            }
            else
            {
                return _timeout == -1
                                    ? OleConn.GetData(conn, sql)
                                    : OleConn.GetData(conn, sql, _timeout);
            }
        }

        /// <summary>
        /// Gets data from databases that support odbc
        /// </summary>
        private DataTable GetOdbcData(string conn, string sql)
        {
            if (_startRecord != -1 && _maxRecords != -1)
            {
                return _timeout == -1
                                    ? OdbcConn.GetData(conn, sql, _startRecord, _maxRecords)
                                    : OdbcConn.GetData(conn, sql, _startRecord, _maxRecords, _timeout);
            }
            else
            {
                return _timeout == -1
                                    ? OdbcConn.GetData(conn, sql)
                                    : OdbcConn.GetData(conn, sql, _timeout);
            }
        }

        /************************ PUBLIC ************************/
        public DataTable GetData(string conn, string sql)
        {
            try
            {
                switch (QuerySelector(conn))
                {
                    case "sqlite":
                        return GetSqliteData(conn, sql);
                    case "oledb":
                        return GetOleDbData(conn, sql);
                    case "odbc":
                        return GetOdbcData(conn, sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting data from db: " + ex.Message);
            }

            return new DataTable("dt");
        }

        private void SetData(string conn, string sql)
        {
            try
            {
                switch (QuerySelector(conn))
                {
                    case "sqlite":
                        SqliteConn.SetData(conn, sql);
                        break;
                    case "oledb":
                        OleConn.SetData(conn, sql);
                        break;
                    case "odbc":
                        OdbcConn.SetData(conn, sql);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending data to db: " + ex.Message);
            }
        }

    }
}
