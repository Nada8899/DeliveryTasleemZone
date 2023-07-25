using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.Repository.Interfaces
{
    public interface IGenericRepository<T, Y>
    {
        IQueryable<T> GetAll(params string[] includePaths);
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> expression, params string[] includePaths);
        T GetByID(Y id, params string[] includePaths);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Update(T entity, params string[] properties);
        void Delete(Y id);
    }
}
