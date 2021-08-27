using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Test.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> FetchAll();
        T GetById(int id);
        bool Create(T newItem);
        bool Update(T itemToUpdate);
        bool Delete(T itemToDelete);
    }
}
