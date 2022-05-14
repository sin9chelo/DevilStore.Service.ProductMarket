using DevilStore.ProductMarket.Flow.Data;
using DevilStore.ProductMarket.Flow.Domain;
using DevilStore.ProductMarket.Flow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Flow.Repositories
{
    public interface IProductRepository
    {
        public Task<Product?> GetProductById(int id);
        public Task<IEnumerable<Product>> GetProductsByMarketId(int marketId);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product?> AddProduct(Product product);
        public Task<Product?> UpdateProduct(Product product);
        public Task DeleteProduct(Product product);
        public Task<IEnumerable<Product>> GetQueryProducts(SearchQueryModel model);
    }
    public class ProductRepository : IProductRepository
    {
        private DevilDBContext _devilDBContext;
        public ProductRepository(DevilDBContext devilDBContext)
        {
            _devilDBContext = devilDBContext ?? throw new ArgumentNullException(nameof(devilDBContext));
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _devilDBContext.Product.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByMarketId(int marketId)
        {
            return await _devilDBContext.Product
                .Where(x => x.MarketId == marketId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _devilDBContext.Product.ToListAsync();
        }

        public async Task<Product?> AddProduct(Product product)
        {
            var result = _devilDBContext.Product.Add(product);
            await _devilDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            //var result = _devilDBContext.Product.First(x => x.Id == product.Id);
            //result = product;
            _devilDBContext.Entry(product).State = EntityState.Modified;
            await _devilDBContext.SaveChangesAsync();
            return product;
            
        }

        public async Task DeleteProduct(Product product)
        {
            _devilDBContext.Product.Remove(product);
            await _devilDBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetQueryProducts(SearchQueryModel model)
        {
            var idList = (model.Ids == "") ? 
                await _devilDBContext.Product.Select(x=>x.Id.ToString()).ToArrayAsync() 
                : model.Ids.Split(',');

            Dictionary<string, object> test = new Dictionary<string, object>();
            test.Add("product", _devilDBContext.Product);

            var result = await _devilDBContext.Product
                .Where(x => idList.Contains(x.Id.ToString()))
                .Skip(model.Offset)
                .Take(model.Limit)
                .ToListAsync();

            return result;
        }
    }
}
