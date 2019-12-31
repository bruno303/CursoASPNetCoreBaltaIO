using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoASPNetCoreBaltaIO.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace CursoASPNetCoreBaltaIO.Repositories
{
    public class ProductRepository : Abstracts.AbstractRepositoryBase<Product, int>
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

        public async Task<IEnumerable<ListProductViewModel>> GetAllAsListProductViewModel()
        {
            return await _context.Products
                .Select(x => new ListProductViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Category = x.Category.Title,
                    CategoryId = x.CategoryId
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}