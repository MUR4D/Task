using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        List<Product> _products = new List<Product>()
        {
            new Product(){ productId = 1, productName = "First",
            },
            new Product(){ productId = 2, productName = "Second",
            },
            new Product(){ productId = 3, productName = "third",
            },
        };
        [HttpGet]

        public IActionResult Gets()
        {
            if (_products.Count == 0)
            {
                return NotFound("No product found!");
            }
            return Ok(_products);
        }

        [HttpGet("GetProduct")]

        public IActionResult Get(int id)
        {
            var _Product = _products.SingleOrDefault(x => x.productId == id);

            if (_Product == null)
            {
                return NotFound("No product found!!!!");
            }
            return Ok(_products);

        }
        [HttpPost]
        public IActionResult Save(Product _product)
        {
            _products.Add(_product);

            if (_products.Count==0)
            {
                return NotFound("Not found");
            }
            return Ok(_products);

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var _Product = _products.SingleOrDefault(x => x.productId == id);

            if (_Product == null)
            {
                return NotFound("No product found!!!!");
            }

            _products.Remove(_Product);

            if (_products.Count == 0)
            {
                return NotFound("No product found!!!!");
            }

            return Ok(_products);

        }


    }
}
