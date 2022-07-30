using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Database
{
    public class DatabaseFactory
    {
        public static SqlServerDatabase CreateDatabase(string connectionString)
        {
            SqlServerDatabase database = new SqlServerDatabase(connectionString);
            return database;
        }
    }
}
