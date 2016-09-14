using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnc2.Admin.Models
{
    public class PanelMenuGroupModel
    {
        public string GroupDescription { get; set; }
        public List<PanelMenuModel> List { get; set; }
    }
}