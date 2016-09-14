using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace w2.Service
{
    public class GigyaParameter : Attribute
    {
        public bool IsRequired { get; set; } 
    }
}