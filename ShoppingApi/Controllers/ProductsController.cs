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
            new Product { Id = 1 , Name = "Mechanical Keyboard", Category="Electronics", Price = 60 , Photo = "https://upload.wikimedia.org/wikipedia/commons/0/02/OLED_keyboard.jpg"},
           new Product  { Id = 2 , Name = "Legendary Book ", Category="Books", Price = 21.99M, Photo = "https://upload.wikimedia.org/wikipedia/commons/6/68/De_Gesammelte_Werke_III_%28Schnitzler%29_001.jpg" },
           new Product { Id = 3 , Name = "Blender", Category="Applicance", Price = 60.99M, Photo ="https://upload.wikimedia.org/wikipedia/commons/5/5f/Braun_KM_32_K%C3%BCchenmaschine_Mixaufsatz_%28KX_32%29_-3425.jpg"},

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