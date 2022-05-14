using DevilStore.ProductMarket.Flow.Managers;
using DevilStore.ProductMarket.Flow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevilStore.ProductMarket.Flow.Domain;

namespace DevilStore.Service.ProductMarket.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/market")]
    public class MarketController : ControllerBase
    {
        private readonly IMarketManager _marketManager;

        public MarketController(IMarketManager marketManager)
        {
            _marketManager = marketManager ?? throw new ArgumentNullException(nameof(marketManager));
        }
        [HttpPost("add")]
        public async Task<MarketModel> AddUserMarket([FromBody] MarketModel market)
        {
            //Получение JWT
            var jwt = GetAuthHeader(HttpContext);

            //Получение данных о юзере через сторонний API
            //var userInfo = await _productMarketClient.VerifyJWT(jwt);

            //Бизнес-логика добавления маркета
            //var owner = await _userManager.GetUserByUsername(jwtUsername);
            Int32.TryParse("12", out int ownerId);
            var result = await _marketManager.AddMarket(market, ownerId);

            return new MarketModel { OwnerId = result.OwnerId };
        }

        [HttpGet("")]
        public async Task<IEnumerable<Market>> GetAllMarkets()
        {
            return await _marketManager.GetAllMarkets();
        }

        private static string GetAuthHeader(HttpContext httpContext)
        {
            var authHeader = httpContext?.Request?.Headers?.SingleOrDefault(x => x.Key == "Authorization").Value[0];
            var jwt = authHeader.Substring(authHeader.IndexOf(' ') + 1);
            return jwt;
        }
    }
}
