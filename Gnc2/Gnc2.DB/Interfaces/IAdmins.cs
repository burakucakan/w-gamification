using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnc2.Com.App_GlobalResources;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnc2.DB.Interfaces
{
    public interface IAdmins : IBaseEntity<Admins>
    {
        [Display(Name = "Username", ResourceType = typeof(rsrcAdmins))]
        [Required(ErrorMessageResourceName = "UsernameReq", ErrorMessageResourceType = typeof(rsrcAdmins))]
        string Username { get; set; }

        [Display(Name = "Password", ResourceType = typeof(rsrcAdmins))]
        [Required(ErrorMessageResourceName = "PasswordReq", ErrorMessageResourceType = typeof(rsrcAdmins))]
        string Password { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(rsrcAdmins))]
        [Required(ErrorMessageResourceName = "FirstNameReq", ErrorMessageResourceType = typeof(rsrcAdmins))]
        string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(rsrcAdmins))]
        [Required(ErrorMessageResourceName = "LastNameReq", ErrorMessageResourceType = typeof(rsrcAdmins))]
        string LastName { get; set; }

        [Display(Name = "FileName", ResourceType = typeof(rsrcAdmins))]
        string FileName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(rsrcAdmins))]
        string Description { get; set; }

        [Display(Name = "FullAuth", ResourceType = typeof(rsrcAdmins))]
        [Required(ErrorMessageResourceName = "FullAuthReq", ErrorMessageResourceType = typeof(rsrcAdmins))]
        bool FullAuth { get; set; }

        [Display(Name = "LastLoginDate", ResourceType = typeof(rsrcAdmins))]
        DateTime? LastLoginDate { get; set; }
    }
}
