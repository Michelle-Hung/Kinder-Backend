using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
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

    public async Task<List<RoomInfo>> GetUserRoomInfo(string userId)
    {
        var roomInfoDtos = await _chatRoomRepository.GetRoomInfosByUser(userId);
        var roomInfos = roomInfoDtos.Select(x => new RoomInfo
        {
            Id = x.Id,
            Name = x.Name,
            Type = x.RoomType,
            CreatedOn = x.CreateTime.ToDateTime(),
        });
        return roomInfos.ToList();
    }
}

public class RoomInfo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public EnumRoomType Type { get; set; }
    public DateTime CreatedOn { get; set; }
}

public interface IChatListService
{
    Task<List<ChatList>> GetChatList(string userId);
    Task<List<RoomInfo>> GetUserRoomInfo(string userId);
}