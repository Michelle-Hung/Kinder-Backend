using System;
using System.Linq;
using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public class ChatService : IChatService
{
    private readonly IFireStoreProxy _fireStoreProxy;

    public ChatService(IFireStoreProxy fireStoreProxy)
    {
        _fireStoreProxy = fireStoreProxy;
    }

    public async Task<ContactInfo> GetContacts(string userId)
    {
        var profileDtos = await _fireStoreProxy.GetFriendsByUser(userId);
        var friendInfos = profileDtos.Select(x => new FriendInfo
        {
            UserId = x.AccountId,
            DisplayName = x.DisplayName
        }).OrderBy(x => x.DisplayName).ToList();
        return new ContactInfo
        {
            Friends = friendInfos,
        };
    }
}