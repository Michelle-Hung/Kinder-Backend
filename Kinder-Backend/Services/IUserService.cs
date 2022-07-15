using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public interface IUserService
{
    Task<UserInfo> GetUserInfo(LoginRequest request);
}