using InfucareRx.PatientHealthApp.Database;
using InfucareRx.PatientHealthApp.Database.Entity.NewFolder;
using InfucareRx.PatientHealthApp.Repository.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfucareRx.PatientHealthApp.Repository.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly InfucareRxPatientHealthAppDbContext _context;
        private readonly DbSet<T> _entities;
        public BaseRepository(InfucareRxPatientHealthAppDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return  await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            _entities.Add(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}
