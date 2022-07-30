using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class OverseasCapital
    {
        public int id { get; set; }
        public string TaxPlayerNumber { get; set; }
        public string form { get; set; }
        public string year { get; set; }
        public int ammend { get; set; }
        public string cap_description { get; set; }
        public string cap_country { get; set; }
        public string cap_currency { get; set; }
        public string cap_sellingdate { get; set; }
        public string cap_interval { get; set; }
        public string cap_exchrate { get; set; }
        public string cap_proceeds { get; set; }
        public string cap_cost { get; set; }
        public string cap_gainloss { get; set; }
        public string cap_taxpaid { get; set; }
        public string cap_gainlossrp { get; set; }
        public string cap_taxpaidrp { get; set; }
        public string cap_irregularincome { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
        public string updatedby { get; set; }
        public string updateddate { get; set; }
    }
}
