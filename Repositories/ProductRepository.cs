using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoASPNetCoreBaltaIO.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace CursoASPNetCoreBaltaIO.Repositories
{
    public class ProductRepository : Abstracts.AbstractRepositoryWithViewModel<Product, int, ListProductViewModel>
    {
        private readonly StoreDataContext _context;

        public ProductRepository(StoreDataContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Product>> GetByCategoryId(int categoryId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public override ListProductViewModel ConvertTypeToViewModel(Product origin)
        {
            if (origin == null) {
                return new ListProductViewModel();
            }

            return new ListProductViewModel()
            {
                Id = origin.Id,
                Title = origin.Title,
                Price = origin.Price,
                Category = origin.Category.Title,
                CategoryId = origin.CategoryId
            };
        }
    }
}