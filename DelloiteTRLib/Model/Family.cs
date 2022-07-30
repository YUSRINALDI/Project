using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class Family
    {
        public int id { get; set; }
        public string TaxPlayerNumber { get; set; }
        public string form { get; set; }
        public string year { get; set; }
        public int ammend { get; set; }
        public string Name { get; set; }
        public int RelationshipID { get; set; }
        public string Relationship { get; set; }
        public string Birthdate { get; set; }
        public string Occupation { get; set; }
        public string NIK { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
        public string updatedby { get; set; }
        public string updateddate { get; set; }
    }
}
