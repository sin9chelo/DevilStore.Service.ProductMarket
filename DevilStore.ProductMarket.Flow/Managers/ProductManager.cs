using DevilStore.ProductMarket.Flow.Domain;
using DevilStore.ProductMarket.Flow.Models;
using DevilStore.ProductMarket.Flow.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Flow.Managers
{
    public interface IProductManager
    {
        public Task<Product?> GetProductById(int id);
        public Task<IEnumerable<Product>> GetProductsByMarketId(int marketId);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product?> AddProduct(Product product);
        public Task<Product?> UpdateProduct(Product product);
        public Task DeleteProduct(Product product);
        public Task<IEnumerable<Product>> GetQueryProducts(SearchQueryModel model);
    }
    public class ProductManager : IProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product?> AddProduct(Product product)
        {
            var result = await _productRepository.AddProduct(product) 
                ?? throw new InvalidDataException("Cannot add product");
            return result;
        }

        public async Task DeleteProduct(Product product)
        {
            await _productRepository.DeleteProduct(product);
        }

        public async Task<Product?> GetProductById(int id)
        {
            Product result;

            result = await _productRepository.GetProductById(id) 
                ?? throw new InvalidDataException("Cannot get product");

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var result = await _productRepository.GetAllProducts() 
                ?? throw new InvalidDataException("Cannot get all products");
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsByMarketId(int marketId)
        {
            var result = await _productRepository.GetProductsByMarketId(marketId) 
                ?? throw new InvalidDataException("Cannot get products for this shop");
            return result;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var result = await _productRepository.UpdateProduct(new Product() 
                ?? throw new InvalidDataException());
            return result;
        }

        public async Task<IEnumerable<Product>> GetQueryProducts(SearchQueryModel model)
        {
            var result = await _productRepository.GetQueryProducts(model)
                ?? throw new InvalidDataException();
            return result;
        }
    }
}
