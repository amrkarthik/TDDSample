using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace EventData
{
    public class DBConnection
    {
        public static DbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
