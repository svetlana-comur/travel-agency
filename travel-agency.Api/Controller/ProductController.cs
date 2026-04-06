using eUShop.BusinessLogic.Interface;
using eUShop.Domains.Models.Product;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eUShop.Api.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _product;

        public ProductController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAllProducts()
        {
            var products = _product.GetAllProductsAction();
            return Ok(products);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var product = _product.GetProductByIdAction(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto product)
        {
            var status = _product.ResponceProductCreateAction(product);
            return Ok(status);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductDto product)
        {
            var status = _product.ResponceProductUpdateAction(product);
            return Ok(status);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var status = _product.ResponceProductDeleteAction(id);
            return Ok(status);
        }
    }
}
