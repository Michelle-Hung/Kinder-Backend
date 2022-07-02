using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinder_Backend.Models;
using Kinder_Backend.Repository;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ChatController : ControllerBase
{
    private readonly IChatListService _chatListService;
    private readonly IChatRoomRepository _chatRoomRepository;

    public ChatController(IChatListService chatListService, IChatRoomRepository chatRoomRepository)
    {
        _chatListService = chatListService;
        _chatRoomRepository = chatRoomRepository;
    }
    [HttpPost]
    public async Task<List<RoomDto>> GetRooms( string userId )
    {
        return await _chatRoomRepository.GetUserRoomInfo(userId);
    }

    //TODO: should use login success token
    [HttpPost]
    public Task<List<ChatList>> GetChatList(string userId)
    {
        return _chatListService.GetChatList(userId);
    }
}