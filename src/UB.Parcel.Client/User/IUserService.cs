
namespace UB.Parcel.Client.User
{
    interface IUserService
    {
        Task<User> GetUser(string username, string password);
    }
}
