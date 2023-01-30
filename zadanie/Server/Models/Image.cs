using MongoDB.Bson.Serialization.Attributes;

namespace PicturePortal.Models;

public class Image : Entity
{
    [BsonRequired]
    public required byte[] Bytes { get; set; }

    [BsonRequired]
    public required string Extension { get; set; }
}
