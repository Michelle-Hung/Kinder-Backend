using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Kinder_Backend.Controllers;
using Kinder_Backend.Helper;

namespace Kinder_Backend.Services;

public class FireStoreProxy : IFireStoreProxy
{
    private readonly FirestoreDb _firestoreDb;

    public FireStoreProxy(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb;
    }

    public async Task Insert<T>(T data, string tableName)
    {
        var docRef = _firestoreDb.Collection(tableName).Document();
        await docRef.SetAsync(data);
    }

    public async Task<List<T>> Get<T>(string tableName) where T : class, new()
    {
        var collectionReference = _firestoreDb.Collection(tableName);
        var snapshotAsync = await collectionReference.GetSnapshotAsync();
        return snapshotAsync.Documents.Select(x => x.ToDictionary().ToObject<T>()).ToList();
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

    public async Task<UserInfo> GetUserInfo(LoginRequest request)
    {
        var userQuery = _firestoreDb.Collection("users").WhereEqualTo("Name",request.Name).WhereEqualTo("Password", request.Password);
        var userSnapshotAsync = await userQuery.GetSnapshotAsync();
        var userInfo = userSnapshotAsync.Documents.Select(x => x.ToDictionary().ToObject<UserInfo>()).FirstOrDefault();
        if (userInfo == null)
        {
            throw new AuthenticationException();
        }

        return userInfo;
    }
}

[FirestoreData]
public class ChatListDto
{
    [FirestoreProperty]
    public string UserId { get; set; }
    [FirestoreProperty]
    public string RoomId { get; set; }
    [FirestoreProperty]
    public string Message { get; set; }
    [FirestoreProperty]
    public Timestamp CreatedOn { get; set; }
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

public interface IFireStoreProxy
{
    Task InsertUserInfo(UserInfo userInfo);
    Task<List<UserInfo>> GetUserInfos();
    Task<UserInfo> GetUserInfo(LoginRequest request);
    Task Insert<T>(T data, string tableName);
    Task<List<T>> Get<T>(string tableName) where T : class, new();
}