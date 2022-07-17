using System.Collections.Generic;
using System.Threading.Tasks;
using Kinder_Backend.Models;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ChatController : ControllerBase
 {
    private readonly IChatListService _chatListService;
    private readonly IChatService _chatService;

    public ChatController(IChatListService chatListService, IChatService chatService)
    {
        _chatListService = chatListService;
        _chatService = chatService;
    }
    [HttpGet]
    public async Task<ContactInfo> GetContacts(string userId)
    {
        return await _chatService.GetContacts(userId);
    }

    //TODO: should use login success token
    [HttpPost]
    public Task<List<ChatList>> GetChatList(string userId)
    {
        return _chatListService.GetChatList(userId);
    }
}

public class ContactInfo
{
    public List<FriendInfo> Friends { get; set; }
}

public class FriendInfo
{
    public string UserId { get; set; }
    public string DisplayName { get; set; }
}