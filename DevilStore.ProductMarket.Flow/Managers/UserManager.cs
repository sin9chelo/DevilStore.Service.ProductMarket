using DevilStore.ProductMarket.Flow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Flow.Managers
{
    public interface IUserManager
    {
        public Task<User> GetUserByUsername(string username);
    }
    public class UserManager : IUserManager
    {
        private IUserManager _userManager;
        public UserManager(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public async Task<User> GetUserByUsername(string username)
        {
            User result;

            result = await _userManager.GetUserByUsername(username) 
                ?? throw new Exception("Cannot add market");

            return result;
        }
    }
}
