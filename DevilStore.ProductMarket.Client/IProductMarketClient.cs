using DevilStore.Service.ProductMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Client
{
    public interface IProductMarketClient
    {
        Task<ProductMarketInboundVerifyJWTResultModel> VerifyJWT(string jwt);
    }
}
