﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB.CustomModels
{
    public class PanelMenuModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
        public string AdminPath { get; set; }
        public bool IsInAdminMenu { get; set; }
        public bool IsSubEndItem { get; set; }
    }
}
