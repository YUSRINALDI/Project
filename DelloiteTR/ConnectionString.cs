using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DelloiteTR
{
    public class ConnectionString
    {
        public static string Value
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Delloite.Web"].ConnectionString;
            }
        }

    }
}
