﻿using Gnc2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    [MetadataType(typeof(IUserOrders))]
    public partial class UserOrders : BaseEntity<UserOrders>, IBaseEntity<UserOrders>
    {





    }
}
