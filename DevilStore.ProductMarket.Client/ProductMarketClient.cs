using DevilStore.Service.ProductMarket.Models;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace DevilStore.ProductMarket.Client
{
    public class ProductMarketClient : IProductMarketClient
    {
        private readonly ProductMarketClientSettings _settings;
        private readonly IFlurlClient _flurlClient;
        public ProductMarketClient(
            ProductMarketClientSettings settings,
            IFlurlClientFactory flurlClientFactory)
        {
            if (flurlClientFactory == null)
            {
                throw new ArgumentNullException(nameof(flurlClientFactory));
            }

            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _flurlClient = flurlClientFactory.Get(new Flurl.Url(_settings.BaseUri));
        }
        public async Task<ProductMarketInboundVerifyJWTResultModel> VerifyJWT(string jwt)
        {
            try
            {
                var response = await _flurlClient
                    .Request(_settings.InboundProductMarketVerifyJWTPath)
                    .WithOAuthBearerToken(jwt)
                    .GetJsonAsync<ProductMarketInboundVerifyJWTResultModel>();

                return response ?? throw new ArgumentNullException(nameof(response));
            }
            catch (FlurlHttpException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
