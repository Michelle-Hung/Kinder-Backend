using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Kinder_Backend.Controllers;
using Kinder_Backend.Helper;

namespace Kinder_Backend.Services;

public class FireStoreService : IFireStoreService
{
    private readonly FirestoreDb _firestoreDb;

    public FireStoreService(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb;
    }
    
    public async Task InsertUserInfo(UserInfo userInfo)
    {
        var docRef = _firestoreDb.Collection("users").Document();
        await docRef.SetAsync(userInfo.AsDictionary());
    }

    public async Task<List<UserInfo>> GetUserInfos()
    {
        var usersRef = _firestoreDb.Collection("users");
        var snapshot = await usersRef.GetSnapshotAsync();
        var userInfos = snapshot.Documents.Select(x => x.ToDictionary().ToObject<UserInfo>()).ToList();
        
        return userInfos;
    }

    public async Task<List<RoomDto>> GetRoomInfoByUserId(string userId)
    {
        var roomIds = await GetRoomIds(userId);
        var roomsQuery = _firestoreDb.Collection("rooms").WhereIn("Id", roomIds);
        var roomSnapshotAsync = await roomsQuery.GetSnapshotAsync();
        var roomDtos = roomSnapshotAsync.Documents.Select(x => x.ToDictionary().ToObject<RoomDto>()).ToList();
        return roomDtos;
    }

    public async Task ValidateUser(LoginRequest request)
    {
        var userQuery = _firestoreDb.Collection("users").WhereEqualTo("Name",request.Name).WhereEqualTo("Password", request.Password);
        var userSnapshotAsync = await userQuery.GetSnapshotAsync();
        var isValid = userSnapshotAsync.Documents.Select(x => x.ToDictionary().ToObject<UserInfo>()).Any();
        if (!isValid)
        {
            throw new AuthenticationException();
        }
    }

    private async Task<List<string>> GetRoomIds(string userId)
    {
        var chatsQuery = _firestoreDb.Collection("Chats");
        var snapshotAsync = await chatsQuery.GetSnapshotAsync();
        var roomIds = snapshotAsync.Documents.Select(x => x.ToDictionary().ToObject<ChatDto>()).Select(x => x.RoomId.ToString()).Distinct().ToList();

        return roomIds;
    }
}

[FirestoreData]
public class RoomDto
{
    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public string Name { get; set; }
    [JsonIgnore]
    [FirestoreProperty]
    public long Status { get; set; }

    public EnumRoomStatus RoomStatus => (EnumRoomStatus)(int)Status;

    [JsonIgnore]
    [FirestoreProperty]
    public long Type { get; set; }

    public EnumRoomType RoomType => (EnumRoomType) (int) Type;

    [FirestoreProperty]
    public Timestamp CreateTime { get; set; }
}

public enum EnumRoomType
{
    Direct = 1,
    Group = 2
}

public enum EnumRoomStatus
{
    Active = 1,
    Archive = 2,
}

[FirestoreData]
public class ChatDto
{
    [FirestoreProperty]
    public string UserId { get; set; }
    [FirestoreProperty]
    public string RoomId { get; set; }
    [FirestoreProperty]
    public string Message { get; set; }
    [FirestoreProperty]
    public Timestamp CreateTime { get; set; }
}

[FirestoreData]
public class UserInfo
{
    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public string Name { get; set; }
    [FirestoreProperty]
    public string Password { get; set; }
}

public interface IFireStoreService
{
    Task InsertUserInfo(UserInfo userInfo);
    Task<List<UserInfo>> GetUserInfos();
    Task<List<RoomDto>> GetRoomInfoByUserId(string userId);
    Task ValidateUser(LoginRequest request);
}