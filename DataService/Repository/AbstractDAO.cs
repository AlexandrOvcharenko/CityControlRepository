using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface AbstractDAO<T>
    {
        Task<List<T>>  GetAll();
        Task<T> GetById(Guid? id);
        Task<T> Create(T model);
        Task<T> Update(T model);
    }
}