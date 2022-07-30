using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelloiteTRLib.Model
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public short suspended { get; set; }
        public short deleted { get; set; }
        public short roleid { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string token { get; set; }
        public string tokendate { get; set; }
    }
}
