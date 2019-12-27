using ProductCatalog.Data;
using ProductCatalog.Models;

namespace CursoASPNetCoreBaltaIO.Repositories
{
    public class CategoryRepository : Abstracts.AbstractRepositoryNoViewModel<Category, int>
    {
        private readonly StoreDataContext _context;

        public CategoryRepository(StoreDataContext context) : base(context)
        {
            this._context = context;
        }
    }
}