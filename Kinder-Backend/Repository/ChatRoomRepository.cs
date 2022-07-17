using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinder_Backend.Models;
using Kinder_Backend.Services;

namespace Kinder_Backend.Repository;

public class ChatRoomRepository : IChatRoomRepository
{
    private readonly IFireStoreProxy _fireStoreProxy;

    public ChatRoomRepository(IFireStoreProxy fireStoreProxy)
    {
        _fireStoreProxy = fireStoreProxy;
    }

    public async Task<IEnumerable<RoomDetailDto>> GetRoomDetailsByRoomId(List<string> roomIds)
    {
        return (await _fireStoreProxy.Get<RoomDetailDto>("RoomDetail")).Where(x => roomIds.Contains(x.RoomId));
    }

    public async Task<IEnumerable<RoomDto>> GetRoomsByIds(List<string> roomIds)
    {
        return (await _fireStoreProxy.Get<RoomDto>("rooms")).Where(x => roomIds.Contains(x.Id));
    }

    public async Task<List<string>> GetRoomIdsFromChat(string userId)
    {
        var chatDtos = await _fireStoreProxy.Get<ChatDto>("Chats");
        return chatDtos.Where(x => x.UserId == userId).Select(x => x.RoomId).ToList();
    }

    public async Task<IEnumerable<RoomDto>> GetRoomInfosByUser(string userId)
    {
        var roomIds = (await _fireStoreProxy.Get<ChatDto>("Chats")).Where(x => x.UserId == userId).Select(x => x.RoomId).ToList();
        return (await _fireStoreProxy.Get<RoomDto>("rooms")).Where(x => roomIds.Contains(x.Id));
    }
}