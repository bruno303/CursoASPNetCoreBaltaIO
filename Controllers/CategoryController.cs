using System.Collections.Generic;
using System.Threading.Tasks;
using CursoASPNetCoreBaltaIO.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace CursoASPNetCoreBaltaIO.Controllers
{
    public class CategoryController
    {
        private readonly CategoryRepository _repositoryCategories;
        private readonly ProductRepository _repositoryProducts;

        public CategoryController(CategoryRepository repository,
            ProductRepository repositoryProducts)
        {
            this._repositoryCategories = repository;
            this._repositoryProducts = repositoryProducts;
        }

        [HttpGet("v1/categories")]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _repositoryCategories.Get();
        }

        [HttpGet("v1/categories/{id}")]
        public async Task<Category> Get(int id)
        {
            return await _repositoryCategories.Get(id);
        }

        [HttpGet("v1/categories/{id}/products")]
        [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Client)]
        public async Task<List<Product>> GetProducts(int id)
        {
            return await _repositoryProducts.GetByCategoryId(id);
        }

        [HttpPost("v1/categories")]
        public async Task<Category> Post([FromBody] Category category)
        {
            await _repositoryCategories.Save(category);

            return category;
        }

        [HttpPut("v1/categories")]
        public async Task<Category> Put([FromBody] Category category)
        {
            await _repositoryCategories.Update(category);

            return category;
        }

        [HttpDelete("v1/categories")]
        public async Task<Category> Delete([FromBody] Category category)
        {
            await _repositoryCategories.Delete(category);

            return category;
        }
    }
}