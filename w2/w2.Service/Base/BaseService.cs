using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w2.DB;

namespace w2.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, IBaseEntity<T>
    {

        public T GetById(int Id)
        {
            using (Context c = new Context())
            {
                return c.GetTable<T>().Where(m => m.Id == Id).FirstOrDefault();
            }
        }


        public IEnumerable<T> GetAll()
        {
            using (Context c = new Context())
            {
                return c.GetTable<T>().OrderBy(s => s.Id).ToList();
            }
        }

        public void Save(T entity)
        {
            using (Context c = new Context())
            {
                if (entity.Id == 0)
                {
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.CreateDate = DateTime.Now;
                    c.GetTable<T>().Add(entity);
                }
                else
                {
                    entity.ModifyDate = DateTime.Now;
                    ChangeEntityState(entity, EntityState.Modified);
                }
                Save(c);
            }
        }

        public void DeleteById(int Id)
        {
            using (Context c = new Context())
            {
                var entity = GetById(Id);
                if (entity != null && entity.Id > 0)
                {
                    entity.ModifyDate = DateTime.Now;
                    entity.IsDeleted = true;
                    ChangeEntityState(entity, EntityState.Modified);
                    Save(c);
                }
            }
        }

        private void ChangeEntityState(T entity, EntityState State)
        {
            Context c = new Context();
            var set = c.Set<T>();
            T attachedEntity = set.Find(entity.Id);

            if (attachedEntity != null)
            {
                var attachedEntry = c.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
                attachedEntry.State = State;
            }
            else
            {
                c.Entry<T>(entity).State = State;
            }
        }

        private void Save(Context c)
        {
            try
            {
                c.SaveChanges();
            }
            catch { }
        }
    }
}
