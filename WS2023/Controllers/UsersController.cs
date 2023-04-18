using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS2023.Models.RequestModels;
using WS2023.Models.RequestModels.Users;
using WS2023.Services;

namespace WS2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService usersService = new UsersService();

        [HttpPost("/api/[controller]/registrationUser")]
        public async Task<RequestResponse> registrationUser([FromBody] UserAuth user) {
            try
            {
                return await usersService.registrationUser(user);
            } catch
            {
                return new RequestResponse(409, "Пользователь с таким логином уже существует.");
            }
        }

        [HttpPost("/api/[controller]/authUser")]
        public async Task<RequestResponse> authUser([FromBody] UserAuth user)
        {
            try
            {
                return await usersService.authUser(user);
            }
            catch
            {
                return new RequestResponse(401, "Не правильный логин или пароль.");
            }
        }
    }
}
