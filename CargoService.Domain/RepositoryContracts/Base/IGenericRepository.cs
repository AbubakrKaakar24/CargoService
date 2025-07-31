using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Domain.RepositoryContracts.Base
{
    public interface IGenericRepository<T>
    {
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked=true);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties = null);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
