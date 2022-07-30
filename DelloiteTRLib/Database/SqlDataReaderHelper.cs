using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DelloiteTRLib.Database
{
    public static class SqlDataReaderHelper
    {
        public static string GetStringOrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return String.Empty;
            }
            return dataReader.GetString(i);
        }

        public static int GetInt32OrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return 0;
            }
            return dataReader.GetInt32(i);
        }

        public static short GetInt16OrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return 0;
            }
            return dataReader.GetInt16(i);
        }

        public static long GetInt64OrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return 0;
            }
            return dataReader.GetInt64(i);
        }

        public static decimal GetDecimalOrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return 0;
            }
            return dataReader.GetDecimal(i);
        }

        public static Byte GetByteOrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return 0;
            }
            return dataReader.GetByte(i);
        }


        public static bool IsNull(SqlDataReader dataReader, int i)
        {
            object tempValue = dataReader.GetValue(i);
            if (tempValue.Equals(System.DBNull.Value))
            {
                return true;
            }

            return false;
        }

        public static bool GetBooleanOrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return false;
            }

            return dataReader.GetBoolean(i);
        }

        public static DateTime GetDateTimeOrDefault(this SqlDataReader dataReader, int i)
        {
            if (SqlDataReaderHelper.IsNull(dataReader, i))
            {
                return DateTime.Parse ("1900-01-01");
            }

            return dataReader.GetDateTime(i);
        }
    }
}
