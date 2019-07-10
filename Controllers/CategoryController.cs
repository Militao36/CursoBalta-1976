using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;


namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreDataContext _context; // qnd e privado e uma boa pratica colocar _context;

        public CategoryController(StoreDataContext contex)
        {
            _context = contex;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            // Find ainda não suporta AsNoTracking
            // return _context.Categories.Find(id);
            return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _context.Procuts.AsNoTracking().Where(x => x.CategoryId == id).ToList();
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
    }
}

//Observações
// AsNoTracking ele traz informações extras eu uso o (AsNoTracking) para não criar essas informações adicionais
