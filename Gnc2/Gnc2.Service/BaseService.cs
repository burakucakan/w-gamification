using System.Data.Metadata.Edm;
using Gnc2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;
using System.Data.Objects;

namespace Gnc2.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, IBaseEntity<T>
    {
        protected Context c = new Context();

        public T GetById(int Id)
        {
            c = new Context();

            return c.GetTable<T>().SingleOrDefault(p => p.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            var query = GetAllIncludingInActive();

            return query.Where(p => p.IsActive == true).ToList();
        }

        public IEnumerable<T> GetAllIncludingInActive()
        {
            //c.Configuration.LazyLoadingEnabled = false;

            //c.Configuration.ProxyCreationEnabled = false; 

            c = new Context();

            c.Configuration.ProxyCreationEnabled = false;

            return c.GetTable<T>().Where(p => p.IsDeleted == false).OrderByDescending(p => p.Id).ToList();
        }


        public int Save(T entity, bool IsCommit = true, bool Log = true)
        {
            int _result = 0;
            using (c = new Context())
            {
                int transactionId = 0;
                AdminTransaction.TransactionTypes TransactionType;
                if (entity.Id == 0)
                {
                    TransactionType = AdminTransaction.TransactionTypes.Insert;
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    c.GetTable<T>().Add(entity);

                }
                else
                {
                    TransactionType = AdminTransaction.TransactionTypes.Update;
                    c.Entry<T>(entity).State = EntityState.Modified;
                }

                if (IsCommit)
                {
                    c.SaveChanges();
                    _result = entity.Id;
                }
                //entity.Id
                   // Commit();

                if (Log)
                    LogTransaction(entity, TransactionType);

                return _result;
            }
        }

        public void Delete(T entity, bool IsCommit = true)
        {
            AdminTransaction.TransactionTypes TransactionType;
            entity.IsActive = true;
            entity.IsDeleted = true;
            c.Entry<T>(entity).State = EntityState.Modified;
            TransactionType = AdminTransaction.TransactionTypes.UpdateForDelete;

            if (IsCommit)
                Commit();
            LogTransaction(entity, TransactionType);
        }

        public void DeleteAndCommit(T entity)
        {
            Delete(entity);
            Commit();
        }

        public void Commit()
        {
            c.SaveChanges();
            //c.Dispose();
        }

        private void LogTransaction(T entity, AdminTransaction.TransactionTypes TransactionType)
        {
            /*string tableName = "test";
            AdminTransaction transaction = new AdminTransaction();
            transaction.CreateDate = DateTime.Now;
            transaction.CreatedBy = 1;
            transaction.TableName = tableName;
            transaction.TransactionId = entity.Id;
            transaction.TransactionType = (int)TransactionType;
            SaveLog(transaction);
            */

            var context = (c as IObjectContextAdapter).ObjectContext;
            string tableName = c.GetTableName<T>(context);
            AdminTransaction transaction = new AdminTransaction();
            transaction.CreateDate = DateTime.Now;
            //transaction.CreatedBy = (int)System.Web.HttpContext.Current.Session["AdminId"];
            transaction.CreatedBy = 0;
            transaction.TableName = tableName;
            transaction.TransactionId = entity.Id;
            transaction.TransactionType = (int) TransactionType;
            SaveLog(transaction);
        }

        private void SaveLog(AdminTransaction entity)
        {
            if (entity.Id == 0)
            {
                c.AdminTransaction.Add(entity);
            }
            else
            {
                c.Entry<AdminTransaction>(entity).State = EntityState.Modified;
            }
            Commit();
        }

        public void Dispose()
        {
            c.Dispose();
        }
    }
}
