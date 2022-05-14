using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Flow.Models
{
    public class MarketModel
    {
        public int Id { get; set; }
        public string? UrlPrefix { get; set; }
        public string? Title { get; set; }
        public int ColoredTitle { get; set; }
        public DateTime ColoredTitleEnd { get; set; }
        public int OwnerId { get; set; }
        public string? TxtStatus { get; set; }
        public string? Faq { get; set; }
        public string? rules { get; set; }
        public string? profileImage { get; set; }
        public string? ContactsArray { get; set; }
        public int Status { get; set; }
        public DateTime LastPaymentDate { get; set; }
    }
}
