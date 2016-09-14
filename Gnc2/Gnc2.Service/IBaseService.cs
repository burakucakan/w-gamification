using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnc2.DB;

namespace Gnc2.Service
{
    public interface IBaseService<T> where T:class, IBaseEntity<T>
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllIncludingInActive();
        void Save(T entity, bool IsCommit = true, bool Log = true);
        void Delete(T entity, bool IsCommit = true);
        void DeleteAndCommit(T entity);
        void Commit();

    }
}
