using DevilStore.ProductMarket.Flow.Domain;
using DevilStore.ProductMarket.Flow.Managers;
using DevilStore.ProductMarket.Flow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DevilStore.Service.ProductMarket.Model;

namespace DevilStore.Service.ProductMarket.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager ?? throw new ArgumentNullException(nameof(productManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("market/{marketId}")]
        public async Task<ActionResult<ActionResult<IEnumerable<Product>>>> GetProductsByMarketId(int marketId)
        {
            var result = await _productManager.GetProductsByMarketId(marketId);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProductById(int id)
        {
            var result = await _productManager.GetProductById(id);

            return Ok(result);
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var result = await _productManager.GetAllProducts();

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Product?>> AddProduct(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);

            var result = await _productManager.AddProduct(product);

            return Ok(result);
        }

        [HttpPut] 
        public async Task<ActionResult<Product?>> UpdateProduct(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);

            var result = await _productManager.UpdateProduct(product);

            return Ok(result);
        }

        [HttpDelete("del/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var deleteProduct = await _productManager.GetProductById(id);

            _productManager.DeleteProduct(deleteProduct);

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetQueryProducts([FromQuery] SearchModelRequest modelRequest)
        {
            SearchQueryModel model = modelRequest;
            var products = await _productManager.GetQueryProducts(model);
            return Ok(products);
        }
    }
}
