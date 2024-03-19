using System.Collections.Generic;
using University.Domain.Entity;

namespace University.DAL.Repositories.Interfaces

{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task <T> Get(int id);

        Task<List<T>> Select();

        Task <bool> Delete(T entity);
        
    }
}
