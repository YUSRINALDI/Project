using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class OverseasIncome
    {
        public int id { get; set; }
        public int type { get; set; }
        public string TaxPlayerNumber { get; set; }
        public string form { get; set; }
        public string year { get; set; }
        public int ammend { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public string line { get; set; }
        public string currency { get; set; }
        public string dateofreceipt { get; set; }
        public string interval { get; set; }
        public string exchrate { get; set; }
        public string fullyearincome { get; set; }
        public string incomecurrency { get; set; }
        public string taxpaidcurrency { get; set; }
        public string incomerp { get; set; }
        public string taxpaidrp { get; set; }
        public string treatyrate { get; set; }
        public string ftc { get; set; }
        public string allowedftc { get; set; }
        public string irregularincome { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
        public string updatedby { get; set; }
        public string updateddate { get; set; }
    }
}
