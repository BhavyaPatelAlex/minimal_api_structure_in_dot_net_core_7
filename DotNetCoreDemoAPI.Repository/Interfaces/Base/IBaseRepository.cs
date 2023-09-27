using InfucareRx.PatientHealthApp.Database.Entity.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfucareRx.PatientHealthApp.Repository.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        void Add(T entity);
        Task<bool> SaveChangesAsync();
        Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
