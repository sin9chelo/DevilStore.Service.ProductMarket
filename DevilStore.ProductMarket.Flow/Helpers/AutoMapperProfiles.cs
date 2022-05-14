using AutoMapper;
using DevilStore.ProductMarket.Flow.Domain;
using DevilStore.ProductMarket.Flow.Models;

namespace DevilStore.ProductMarket.Flow.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductModel, Product>();
        }
    }
}
