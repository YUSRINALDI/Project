using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class OverseasRental
    {
        public int id { get; set; }
        public int type { get; set; }
        public string TaxPlayerNumber { get; set; }
        public string form { get; set; }
        public string year { get; set; }
        public int ammend { get; set; }
        public string ren_information { get; set; }
        public string ren_country { get; set; }
        public string ren_currency { get; set; }
        public string ren_dateofreceipt { get; set; }
        public string ren_interval { get; set; }
        public string ren_exchrate { get; set; }
        public string ren_amountcurrency { get; set; }
        public string ren_amountrp { get; set; }
        public string ren_irregularincome { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
        public string updatedby { get; set; }
        public string updateddate { get; set; }
    }
}
