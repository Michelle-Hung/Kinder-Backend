using System.Collections.Generic;
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

    public async Task<ContactInfo> GetContactInfos(string userId)
    {
        var profileDtos = await _fireStoreProxy.GetContactProfiles(userId);
        var friendInfos = profileDtos.Select(x => new UserInfo
        {
            UserId = x.AccountId,
            DisplayName = x.DisplayName
        }).OrderBy(x => x.DisplayName).ToList();
        return new ContactInfo
        {
            Friends = friendInfos,
        };
    }

    public async Task<List<ChatInfo>> GetChatInfos(string userId)
    {
        var messageDtos = await _fireStoreProxy.GetMessagesByUser(userId);
        
        var profileDtos = await _fireStoreProxy.GetProfiles();

        return messageDtos.Select(messageDto => new ChatInfo
        {
            Message = messageDto.Content,
            MessageTime = messageDto.CreatedOn.ToDateTime(),
            SendTo = new UserInfo
            {
                UserId = messageDto.SendTo,
                DisplayName = profileDtos.Single(x => x.AccountId == messageDto.SendTo).DisplayName
            },
            SendBy = new UserInfo
            {
                UserId = messageDto.SendBy,
                DisplayName = profileDtos.Single(x => x.AccountId == messageDto.SendBy).DisplayName 
            }
        }).OrderBy(x => x.MessageTime).ToList();
    }
}