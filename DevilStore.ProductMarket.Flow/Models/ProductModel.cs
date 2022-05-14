using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Flow.Models
{
    public class ProductModel
    {
        public int MarketId { get; set; }
        public string? MainImage { get; set; }
        public string? ImagesList { get; set; }
        public string? ProductType { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? CurrentVersion { get; set; }
        public int Status { get; set; }
        public string? Details { get; set; }
        public string? SmallDetails { get; set; }
        public int PositionId { get; set; }
        public int CategoryId { get; set; }
        public string? Faq { get; set; }
        public string? BorderColor { get; set; }
        public DateTime BorderEndTime { get; set; }
    }
}
