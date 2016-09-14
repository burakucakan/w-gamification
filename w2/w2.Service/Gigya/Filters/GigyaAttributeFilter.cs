using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using w2.Service;

namespace w2.Service
{
    public class GigyaAttributeFilter
    {
        public static bool IsRequired(PropertyInfo item)
        {
            GigyaParameter param = (GigyaParameter)item.GetCustomAttribute(typeof(GigyaParameter));
            if (param == null)
                return true;
            else
                return param.IsRequired;
        }
    }
}