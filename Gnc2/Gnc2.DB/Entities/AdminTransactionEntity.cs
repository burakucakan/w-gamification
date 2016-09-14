using Gnc2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    [MetadataType(typeof(IAdminTransaction))]
    public partial class AdminTransaction
    {
        public enum TransactionTypes
        {
            Insert = 1,
            Update = 2,
            Delete = 3,
            UpdateForDelete = 4,
            Select = 5
        }
    }
}
