using DevilStore.ProductMarket.Flow.Constants;
using System.ComponentModel.DataAnnotations;

namespace DevilStore.ProductMarket.Flow.Domain
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string publicLogin { get; set; }
        public string password { get; set; }
        public Roles role { get; set; }
        public string? telegramLogin { get; set; }
        public decimal balance { get; set; } = 0;
        public bool telegramVerified { get; set; }
        public bool telegramLastChange { get; set; }
        public DateTime registrationDate { get; set; }
        public string lastOnline { get; set; }
        public string txtStatus { get; set; }
        public string profileImage { get; set; }
        public string referal { get; set; }

        public User(string username, string publicLogin, string password, Roles role, string? telegramLogin = null)
        {
            this.username = username;
            this.publicLogin = publicLogin;
            this.password = password;
            this.role = role;
            this.telegramLogin = telegramLogin;
        }
    }
}
