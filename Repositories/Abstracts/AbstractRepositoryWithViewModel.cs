using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;

namespace CursoASPNetCoreBaltaIO.Repositories.Abstracts
{
    public abstract class AbstractRepositoryWithViewModel<TType, TKey, TViewModel> :
        AbstractRepositoryBase<TType, TKey, TViewModel>
        where TType : class
        where TViewModel : class
    {
        private readonly StoreDataContext _context;

        public AbstractRepositoryWithViewModel(StoreDataContext context) : base(context)
        {
            this._context = context;
        }

        public abstract TViewModel ConvertTypeToViewModel(TType origin);

        public override async Task<IEnumerable<TViewModel>> Get()
        {
            return await _context.Set<TType>()
                .Select(x => ConvertTypeToViewModel(x))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}