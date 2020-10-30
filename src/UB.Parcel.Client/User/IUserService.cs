
using System.Threading.Tasks;

namespace UB.Parcel.Client.User
{
    interface IUserService
    {
        Task<UserDomain> GetUserLogin(UserDomain.LoginRequest request, Config config);
    }
}
