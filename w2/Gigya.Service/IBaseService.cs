using Gigya.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gigya.Service
{
    public interface IBaseService<T> where T : class, IBaseEntity
    {
        T GetById(Guid Id);
        IEnumerable<T> GetAll();
        void Save(T entity);
    }
}
