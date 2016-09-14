using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsActive { get; set; }
        System.DateTime CreateDate { get; set; }
        System.DateTime ModifyDate { get; set; }
    }
}
