using Rest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rest.Enity;
using System.Threading.Tasks;
using Rest.DataContext;
using System.Data.Entity;

namespace Rest.Services
{
    public class DbService : IDbService
    {
        public async Task CreateUserAsync(User user)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<User> GetUserByPhoneAsync(string phoneNumber)
        {
            using (var context = new AppDbContext())
            {
                return await context.Users.Where(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync().ConfigureAwait(false);
            }
        }

        public async Task<List<int>> GetUserIdsAsync(IEnumerable<string> phoneNumbers)
        {
            using (var context = new AppDbContext())
            {
                return await context.Users.Where(t => phoneNumbers.Contains(t.PhoneNumber)).Select(t => t.Id).ToListAsync().ConfigureAwait(false);
            }
        }
    }
}