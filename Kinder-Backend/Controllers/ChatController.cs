using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ChatController : ControllerBase
{
    private readonly IFireStoreService _fireStoreService;

    public ChatController( IFireStoreService fireStoreService)
    {
        _fireStoreService = fireStoreService;
    }
    [HttpPost]
    public async Task<List<RoomDto>> GetRooms( string userId )
    {
        return await _fireStoreService.GetRoomInfoByUserId(userId);
    }

    //TODO: should use login success token
    [HttpPost]
    public void GetChatList(string userId)
    {
    }
}