using System.Collections.Generic;
using Kinder_Backend.Services;

namespace Kinder_Backend.Models;

public class ChatList
{
    public string RoomId { get; set; }
    public string RoomName { get; set; }
    public EnumRoomStatus RoomStatus { get; set; }
    public EnumRoomType RoomType { get; set; }
    public IEnumerable<RoomDetailDto?> Detail { get; set; }
}