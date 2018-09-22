using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IList<T> FindAll();
        T FindByID(String id);
        int Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
