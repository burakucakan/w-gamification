using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnc2.Com.App_GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Gnc2.DB.Interfaces
{
    public class User
    {
        public virtual string Msisdn { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Email { get; set; }

        public virtual string ProfileImage { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual string Gender { get; set; }

        public virtual DateTime LoginDate { get; set; }
    }
}
