using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UB.Parcel.Client.User;

namespace UB.Parcel.Client.User
{
    public class UserService : IUserService
    {
        public async Task<UserDomain> GetUserLogin(UserDomain.LoginRequest request, Config config)
        {
            if (String.IsNullOrWhiteSpace(request.username) || String.IsNullOrWhiteSpace(request.password))
                return new UserDomain { status = false, message = "Username or Password is empty!" };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, config.LoginUrl)
            {
                Content = content
            };

            var result = client.SendAsync(requestMessage).Result;
            var responseBody = await result.Content.ReadAsStringAsync();

            var user = UserDomain.MapUserDomanin(responseBody);

            return user;
        }
    }
}
