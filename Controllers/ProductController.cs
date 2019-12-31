using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CursoASPNetCoreBaltaIO.Repositories;
using CursoASPNetCoreBaltaIO.ViewModels;
using CursoASPNetCoreBaltaIO.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace CursoASPNetCoreBaltaIO.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("v1/products")]
        public async Task<IEnumerable<ListProductViewModel>> Get()
        {
            return await _repository.GetAllAsListProductViewModel();
        }

        [HttpGet("v1/products/{id}")]
        public async Task<Product> Get(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPost("v1/products")]
        public async Task<ResultViewModel> Post([FromBody]EditorProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };
            }

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now; // Nunca recebe esta informação
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; // Nunca recebe esta informação
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            await _repository.Save(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };
        }

        [HttpPost("v2/products")]
        public async Task<ResultViewModel> Post([FromBody]Product product)
        {
            await _repository.Save(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };
        }

        [HttpPut("v1/products")]
        public async Task<ResultViewModel> Put([FromBody]EditorProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o produto",
                    Data = model.Notifications
                };

            var product = await _repository.Get(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            // product.CreateDate = DateTime.Now; // Nunca altera a data de criação
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; // Nunca recebe esta informação
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            await _repository.Update(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto alterado com sucesso!",
                Data = product
            };
        }
    }
}