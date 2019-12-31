using System.Collections.Generic;
using System.Threading.Tasks;
using CursoASPNetCoreBaltaIO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;

namespace CursoASPNetCoreBaltaIO.Repositories.Abstracts
{
    public abstract class AbstractRepositoryBase<TType, TKey> :
        IRepository<TType, TKey>
        where TType : class
    {
        private readonly StoreDataContext _context;

        public AbstractRepositoryBase(StoreDataContext context)
        {
            this._context = context;
        }

        public virtual async Task<IEnumerable<TType>> Get()
        {
            return await _context.Set<TType>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TType> Get(TKey id)
        {
            return await _context.Set<TType>().FindAsync(id);
        }

        public virtual async Task Save(TType entity)
        {
            await _context.Set<TType>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TType entity)
        {
            _context.Entry<TType>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TType entity) 
        {
            _context.Set<TType>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}