using System.Collections.Generic;
using System.Threading.Tasks;
using Kinder_Backend.Models;
using Kinder_Backend.Services;

namespace Kinder_Backend.Repository;

public interface IChatRoomRepository
{
    Task<IEnumerable<RoomDetailDto>> GetRoomDetailsByRoomId(List<string> roomIds);
    Task<IEnumerable<RoomDto>> GetRoomsByIds(List<string> roomIds);
    Task<List<string>> GetRoomIdsFromChat(string userId);
    Task<List<RoomDto>> GetUserRoomInfo(string userId);
}