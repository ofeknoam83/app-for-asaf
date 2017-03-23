using Rest.Enity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rest.Interfaces
{
    public interface IDbService
    {
        Task<User> GetUserByPhoneAsync(string phoneNumber);
        Task CreateUserAsync(User user);
        Task<List<int>> GetUserIdsAsync(IEnumerable<string> phoneNumbers);
    }
}
