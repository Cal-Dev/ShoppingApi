using ShoppingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1 , Name = "Mechanical Keyboard", Category="Electronics", Price = 60 },
           new Product  { Id = 2 , Name = "Legendary Book ", Category="Books", Price = 21.99M },
           new Product { Id = 3 , Name = "Blender", Category="Applicance", Price = 60.99M },

        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}", Name ="GetProduct")] 
        public IActionResult GetById(int num)
        {
            var product = products.FirstOrDefault((p) => p.Id == num);
            
            if (product == null)
            {
                return NotFound(); // returns a proper 404 
            }

            return Ok(product);
        }

    }
}