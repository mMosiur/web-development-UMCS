using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PicturePortal.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonRequired]
    public required string Username { get; set; }

    [BsonRequired]
    public required string PasswordHash { get; set; }
}
