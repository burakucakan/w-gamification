using w2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace w2.Service
{
    public interface IBaseService<T> where T : class, IBaseEntity<T>
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void Save(T entity);
        void DeleteById(int Id);
    }
}
