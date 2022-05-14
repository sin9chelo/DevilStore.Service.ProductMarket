using DevilStore.ProductMarket.Flow.Data;
using DevilStore.ProductMarket.Flow.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevilStore.ProductMarket.Flow.Repositories
{
    public interface IMarketRepository
    {
        public Task<Market> AddMarket(Market market);
        public Task<IEnumerable<Market>> GetAllMarkets();
    }
    public class MarketRepository : IMarketRepository
    {
        private DevilDBContext _devilDBContext;

        public MarketRepository(DevilDBContext devilDBContext)
        {
            _devilDBContext = devilDBContext ?? throw new ArgumentNullException(nameof(devilDBContext));
        }

        public async Task<Market> AddMarket(Market market)
        {
            var result = _devilDBContext.Market.Add(market);
            await _devilDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Market>> GetAllMarkets()
        {
            return await _devilDBContext.Market.ToListAsync();
        }
    }
}
