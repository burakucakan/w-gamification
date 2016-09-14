using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Gnc2.DB
{
    public class Context: Gnc2Entities
    {

        public DbSet<TEntity> GetTable<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }
        public string GetTableName<TEntity>(ObjectContext context) where TEntity : class
        {
            string sql = context.CreateObjectSet<TEntity>().ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
        }
    }
}
