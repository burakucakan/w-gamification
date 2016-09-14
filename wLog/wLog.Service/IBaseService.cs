using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wLog.DB;

namespace wLog.Service
{
    public interface IBaseService<T> where T : class, IBaseEntity
    {
        T GetById(Guid Id);
        IEnumerable<T> GetAll();
        void Save(T entity);
    }
}
