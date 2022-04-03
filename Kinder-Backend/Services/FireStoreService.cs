using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Kinder_Backend.Helper;

namespace Kinder_Backend.Services;

public class FireStoreService : IFireStoreService
{
    private readonly FirestoreDb _firestoreDb;

    public FireStoreService(FirestoreDb firestoreDb )
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
}

public class UserInfo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}

public interface IFireStoreService
{
    Task InsertUserInfo(UserInfo userInfo);
    Task<List<UserInfo>> GetUserInfos();
}