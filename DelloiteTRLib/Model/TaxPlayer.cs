using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class TaxPlayer
    {
        public int ParticularId { get; set; }
        public string TaxPayerNumber { get; set; }
        public string TaxRefNo { get; set; }
        public string TaxPayerName { get; set; }

        public int ID { get; set; }
        public string MasterId { get; set; }
        public string Company_Key { get; set; }
        public int LocalCompany_Key { get; set; }
        public string COY_NAME_Key { get; set; }
        public string PIC { get; set; }
    }
}
