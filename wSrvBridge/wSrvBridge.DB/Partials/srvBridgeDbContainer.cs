using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using wSrvBridge.Lib;

namespace wSrvBridge.DB
{
    public partial class srvBridgeDbContainer : DbContext, IDisposable
    {
        public srvBridgeDbContainer(string connectionName) : base(connectionName)
        {
        }

        public List<uspGetMeteringTransactions_Result> GetMeteringData()
        {
            var result = uspGetMeteringTransactions();
            return result.ToList<uspGetMeteringTransactions_Result>();
            
        }
    }
}
