using System.Threading.Tasks;

namespace Ved_Organic.Data
{
    public interface IUserService
    {
        Task<bool> Register(UserInfo user);
    }
}