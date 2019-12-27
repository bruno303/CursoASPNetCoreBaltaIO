using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;

namespace CursoASPNetCoreBaltaIO.Repositories.Abstracts
{
    public abstract class AbstractRepositoryNoViewModel<TType, TKey> :
        AbstractRepositoryBase<TType, TKey, TType>
        where TType : class
    {
        private readonly StoreDataContext _context;

        public AbstractRepositoryNoViewModel(StoreDataContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<TType>> Get()
        {
            return await _context.Set<TType>().AsNoTracking().ToListAsync();
        }
    }
}