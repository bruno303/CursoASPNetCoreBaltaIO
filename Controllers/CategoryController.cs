using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoASPNetCoreBaltaIO.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Route("v1/categories")]
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _repositoryCategories.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public async Task<Category> Get(int id)
        {
            return await _repositoryCategories.Get(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public async Task<List<Product>> GetProducts(int id)
        {
            return await _repositoryProducts.GetByCategoryId(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public async Task<Category> Post([FromBody] Category category)
        {
            await _repositoryCategories.Save(category);

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public async Task<Category> Put([FromBody] Category category)
        {
            await _repositoryCategories.Update(category);

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public async Task<Category> Delete([FromBody] Category category)
        {
            await _repositoryCategories.Delete(category);

            return category;
        }
    }
}