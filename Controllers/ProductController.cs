using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.ProductViewModels;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreDataContext _context; // qnd e privado e uma boa pratica colocar _context;

        public ProductController(StoreDataContext context)
        {
            _context = context;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Procuts.Include(x => x.Category)
            .Select(x => new ListProductViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                Category = x.Category.Title,
                CategoryId = x.Category.Id
            })
            .AsNoTracking()
            .ToList();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _context.Procuts.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post([FromBody] EditorProductViewModel model)
        {
            // model.Validate();
            // if (model.Invalid)
            //     return new ResultViewModel
            //     {
            //         Success = false,
            //         Message = "Não foi possível cadastrar o porduto",
            //         Data = model.Notifications
            //     };

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now; // nunca recebe essa informação
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; // nunca recebe essa informação
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _context.Procuts.Add(product);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso",
                Data = product
            };
        }


        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Put([FromBody] EditorProductViewModel model)
        {
            // model.Validate();
            // if (model.Invalid)
            //     return new ResultViewModel
            //     {
            //         Success = false,
            //         Message = "Não foi possível cadastrar o porduto",
            //         Data = model.Notifications
            //     };

            var product = _context.Procuts.Find(model.Id);
            product.CategoryId = model.CategoryId;
            //product.CreateDate = DateTime.Now; ==== Nunca altera essa informação
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; // nunca recebe essa informação, más altera pois e data de
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto alterado com sucesso",
                Data = product
            };

        }
    }
}