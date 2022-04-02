using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class UserController
{
    private readonly IFireStoreService _fireStoreService;

    public UserController( IFireStoreService fireStoreService)
    {
        _fireStoreService = fireStoreService;
    }

    [HttpPost]
    public async Task<HttpStatusCode> Login( LoginRequest request)
    {
        var userInfos = await _fireStoreService.GetUserInfos();
        var isValid = userInfos.Any(userInfo => userInfo.Name == request.Name && userInfo.Password == request.Password);
        if (isValid)
        {
            return HttpStatusCode.OK;
        }

        return HttpStatusCode.Unauthorized;
    }
}

public class LoginRequest
{
    public string Name { get; set; }
    public string Password { get; set; }
}