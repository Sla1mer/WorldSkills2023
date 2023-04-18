using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web.Http;
using WS2023.Controllers;
using WS2023.Models.Entity;
using WS2023.Models.RequestModels;
using WS2023.Models.RequestModels.Users;
using WS2023.Utils;

namespace WS2023.Services
{
    public class UsersService
    {
        private Ws2023Context ws2023Context = new Ws2023Context();

        public async Task<RequestResponse> registrationUser(UserAuth user)
        {

            if (await ws2023Context.Users.Where(u => u.Login == user.login).FirstOrDefaultAsync() != null)
                throw new HttpResponseException(HttpStatusCode.Conflict);

            User userEntity = new User();
            userEntity.Login = user.login;
            userEntity.Password = PasswordUtils.passwordToMd5(user.password);
            await ws2023Context.Users.AddAsync(userEntity);
            await ws2023Context.SaveChangesAsync();
           
            return new RequestResponse(201, "Регистрация успешна.");
        }

        public async Task<RequestResponse> authUser(UserAuth user)
        {
            User userEntity = await ws2023Context.Users.Where(u => u.Login == user.login && 
                u.Password == PasswordUtils.passwordToMd5(user.password)).FirstOrDefaultAsync();

            if (userEntity == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            return new RequestResponse(200, JsonConvert.SerializeObject(userEntity));
        } 
    }
}
