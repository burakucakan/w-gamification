using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnc2.Models
{
    public class LogonUserModel
    {
        public string Mssidn { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfileImage { get; set; }
        public int Point { get; set; }
    }
}