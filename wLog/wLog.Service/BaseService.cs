﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using wLog.DB;
using System.ComponentModel.DataAnnotations;

namespace wLog.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, IBaseEntity
    {
        private Context c;

        public T GetById(Guid Id)
        {
            using (Context e = new Context())
            {
                return e.GetTable<T>().SingleOrDefault(p => p.Id == Id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (c = new Context())
            {
                return c.GetTable<T>().OrderBy(s => s.Id).ToList();
            }
        }


        public void Save(T entity)
        {
            using (c = new Context())
            {
                if (entity.Id ==null)
                {
                    entity.CreateDate = DateTime.Now;
                    c.GetTable<T>().Add(entity);
                }
                else
                    c.Entry<T>(entity).State = EntityState.Modified;

                c.SaveChanges();
            }
        }
    }
}