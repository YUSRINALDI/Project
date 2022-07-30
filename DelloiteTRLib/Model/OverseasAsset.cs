using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class OverseasAsset
    {
        public int id { get; set; }
        public int type { get; set; }
        public string TaxPlayerNumber { get; set; }
        public string form { get; set; }
        public string year { get; set; }
        public int ammend { get; set; }
        public string as_id { get; set; }
        public string as_description { get; set; }
        public string as_refnumber { get; set; }
        public string as_details { get; set; }
        public string as_currency { get; set; }
        public string as_balancedate { get; set; }
        public string as_interval { get; set; }
        public string as_originalcurrency { get; set; }
        public string as_exchrate { get; set; }
        public string as_inrupiah { get; set; }
        public string as_owner { get; set; }
        public string as_address { get; set; }
        public string as_account { get; set; }
        public string as_country { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
        public string updatedby { get; set; }
        public string updateddate { get; set; }
    }
}
