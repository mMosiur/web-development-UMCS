using MongoDB.Bson.Serialization.Attributes;
using PicturePortal.Models.Base;

namespace PicturePortal.Models;

public class User : Entity
{
    [BsonRequired]
    public required string Username { get; set; }

    public string? DisplayName { get; set; }

    [BsonIgnore]
    public string Name => DisplayName ?? Username;

    [BsonRequired]
    public required string PasswordHash { get; set; }
}
