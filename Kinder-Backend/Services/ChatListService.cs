using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinder_Backend.Models;
using Kinder_Backend.Repository;

namespace Kinder_Backend.Services;

public class ChatListService : IChatListService
{
    private readonly IChatRoomRepository _chatRoomRepository;


    public ChatListService(IChatRoomRepository chatRoomRepository)
    {
        _chatRoomRepository = chatRoomRepository;
    }

    public async Task<List<ChatList>> GetChatList(string userId)
    {
        var roomIds = await _chatRoomRepository.GetRoomIdsFromChat(userId);
        var roomDtos = await _chatRoomRepository.GetRoomsByIds(roomIds);
        var roomDetailDtos = await _chatRoomRepository.GetRoomDetailsByRoomId(roomIds);

        var chatLists = roomDtos.GroupJoin(roomDetailDtos,
            room => room.Id,
            detail => detail.RoomId, 
            (room, detail) => new
            {
                Room = room,
                Detail = detail.DefaultIfEmpty()
            }).Select(x => new ChatList
        {
            RoomId = x.Room.Id,
                
            RoomName = (EnumRoomType)x.Room.Type == EnumRoomType.Direct? x.Detail.Single(d => d != null && d.MemberId != userId).MemberName : x.Room.Name,
            RoomStatus = (EnumRoomStatus)x.Room.Status,
            RoomType = (EnumRoomType)x.Room.Type,
            Detail = x.Detail.DefaultIfEmpty()
        }).ToList();

        return chatLists;
    }
}

public interface IChatListService
{
    Task<List<ChatList>> GetChatList(string userId);
}