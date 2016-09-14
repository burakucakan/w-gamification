using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnc2.Com.App_GlobalResources;

namespace Gnc2.DB
{
    public interface IUsers : IBaseEntity<Users>
    {
        Users GetByMsisdn(string Msisdn);



        [Required(ErrorMessageResourceName = "NameReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "Name", ResourceType = typeof(rsrcUsers))]
        string Name { get; set; }

        [Required(ErrorMessageResourceName = "SurnameReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "Surname", ResourceType = typeof(rsrcUsers))]
        string Surname { get; set; }

        [Required(ErrorMessageResourceName = "EmailReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "Email", ResourceType = typeof(rsrcUsers))]
        string Email { get; set; }

       // [Required(ErrorMessageResourceName = "ProfileImageReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "ProfileImage", ResourceType = typeof(rsrcUsers))]
        string ProfileImage { get; set; }

      //  [Required(ErrorMessageResourceName = "BirthDateReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "BirthDate", ResourceType = typeof(rsrcUsers))]
        DateTime? BirthDate { get; set; }

      //  [Required(ErrorMessageResourceName = "GenderReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "Gender", ResourceType = typeof(rsrcUsers))]
        string Gender { get; set; }

        [Required(ErrorMessageResourceName = "LoginDateReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "LoginDate", ResourceType = typeof(rsrcUsers))]
        DateTime? LoginDate { get; set; }

        [Required(ErrorMessageResourceName = "CityCodeReq", ErrorMessageResourceType = typeof(rsrcUsers))]
        [Display(Name = "CityCode", ResourceType = typeof(rsrcUsers))]
        int? CityCode { get; set; }
    }
}
