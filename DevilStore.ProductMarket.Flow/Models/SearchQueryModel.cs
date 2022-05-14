using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Flow.Models
{
    public class SearchQueryModel
    {
        public string? Type { get; set; } = String.Empty;
        public string? Ids { get; set; } = String.Empty;
        public int Limit { get; set; } = 8;
        public int Offset { get; set; } = 0;
    }
}