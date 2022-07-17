using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public interface IChatService
{
    Task<ContactInfo> GetContacts(string userId);
}