using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public class UserService : IUserService
{
    private readonly IFireStoreProxy _fireStoreProxy;

    public UserService(IFireStoreProxy fireStoreProxy)
    {
        _fireStoreProxy = fireStoreProxy;
    }

    public async Task<UserInfo> GetUserInfo(LoginRequest request)
    {
        var userInfo = await _fireStoreProxy.GetUserInfo(request);
        return userInfo;
    }
}