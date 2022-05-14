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
    public interface IMarketManager
    {
        public Task<Market> AddMarket(MarketModel model, int userId);
        public Task<IEnumerable<Market>> GetAllMarkets();
    }
    public class MarketManager : IMarketManager
    {
        private IMarketRepository _marketRepository;

        public MarketManager(IMarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
        }

        public async Task<Market> AddMarket(MarketModel market, int userId)
        {
            Market result;

            result = await _marketRepository.AddMarket(new Market() 
                ?? throw new Exception("Cannot add market"));

            return result;
        }

        public async Task<IEnumerable<Market>> GetAllMarkets()
        {
            return await _marketRepository.GetAllMarkets();
        }
    }
}
