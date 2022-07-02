using System.Linq;
using System.Threading.Tasks;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IFireStoreProxy _fireStoreProxy;

    public UserController( IFireStoreProxy fireStoreProxy)
    {
        _fireStoreProxy = fireStoreProxy;
    }

    [HttpPost]
    public async Task<LoginResponse> Login( LoginRequest request)
    {
        await _fireStoreProxy.ValidateUser(request);
        
        var userInfos = await _fireStoreProxy.GetUserInfos();
        var user = userInfos.Single(userInfo => userInfo.Name == request.Name && userInfo.Password == request.Password);

        //TODO: should have login success token
        return new LoginResponse()
        {
            Success = true,
            UserId = user.Id
        };
    }
}

public class LoginResponse
{
    public bool Success { get; set; }
    public string UserId { get; set; }
}

public class LoginRequest
{
    public string Name { get; set; }
    public string Password { get; set; }
}