using Google.Cloud.Firestore;

namespace Kinder_Backend.Models;

[FirestoreData]
public class RoomDetailDto
{
    [FirestoreProperty]
    public string RoomId { get; set; }
    [FirestoreProperty]
    public string MemberId { get; set; }
    [FirestoreProperty]
    public string MemberName { get; set; }
}