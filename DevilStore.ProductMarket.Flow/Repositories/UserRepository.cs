using DevilStore.ProductMarket.Flow.Data;
using DevilStore.ProductMarket.Flow.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilStore.ProductMarket.Flow.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByUsername(string username);
    }
    public class UserRepository : IUserRepository
    {
        private DevilDBContext _devilDBContext;

        public UserRepository(DevilDBContext devilDBContext)
        {
            _devilDBContext = devilDBContext ?? throw new ArgumentNullException(nameof(devilDBContext));
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var result = await _devilDBContext.User.FirstOrDefaultAsync(x => x.username == username);
            return result;
        }
    }
}
