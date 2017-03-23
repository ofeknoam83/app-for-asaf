using Rest.Enity;
using Rest.Filters;
using Rest.Interfaces;
using Rest.Models;
using Rest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace Rest.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IDbService _dbService;
        public AccountController()
        {
            _dbService = new DbService();
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<BaseResponse> SingUp(UserModel userModel)
        {
            userModel.phoneNumber = NormalizePhone(userModel.phoneNumber);

            if (ModelState.IsValid == false)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return new BaseResponse (400, message);
            }

            var user = await _dbService.GetUserByPhoneAsync(userModel.phoneNumber).ConfigureAwait(false);
            if (user != null)
                return new BaseResponse(403, "User already registered!");

            user = new User
            {
                PhoneNumber = userModel.phoneNumber,
                Password = Crypto.HashPassword(userModel.password),
                CreatedDate = DateTime.UtcNow
            };

            await _dbService.CreateUserAsync(user).ConfigureAwait(false);
            return new BaseResponse { code = 200};
        }

        [BasicHttpAuthorize]
        [HttpPost]
        [Route("getUsers")]
        public async Task<BaseResponse> GetUsers(GetUsersRequest data)
        {
            return new GetUsersReponse { code = 200, UserIds = await _dbService.GetUserIdsAsync(data.phoneNumbers.Select(t => NormalizePhone(t))).ConfigureAwait(false) };
        }

        private string NormalizePhone(string phone)
        {
            return new String(phone.Where(Char.IsDigit).ToArray());
        }

        private User GetCurrentUser()
        {
            return (RequestContext.Principal.Identity as AppGenericIdentity)?.User;
        }
    }
}
