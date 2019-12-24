using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace CursoASPNetCoreBaltaIO.Controllers
{
    public class CategoryController
    {
        private readonly StoreDataContext _context;

        public CategoryController(StoreDataContext context)
        {
            this._context = context;
        }

        [Route("v1/categories")]
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public async Task<Category> Get(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public async Task<List<Product>> GetProducts(int id)
        {
            return await _context.Prodocuts
                .AsNoTracking()
                .Where(p => p.CategoryId == id)
                .ToListAsync();
        }

        [Route("v1/categories")]
        [HttpPost]
        public async Task<Category> Post([FromBody] Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public async Task<Category> Put([FromBody] Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public async Task<Category> Delete([FromBody] Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}