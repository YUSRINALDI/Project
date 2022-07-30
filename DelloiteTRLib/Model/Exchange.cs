using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class Exchange
    {
        public int id { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string year { get; set; }
        public string interval { get; set; }
        public double amount { get; set; }
        public int type { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
        public string updatedby { get; set; }
        public string updateddate { get; set; }
    }
}
