using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PicturePortal.Models.Base;

namespace PicturePortal.Models;

public class Image : Entity
{
    public required byte[] Bytes { get; set; }

    public required string Title { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string AuthorId { get; set; }

    public string? Description { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public required DateTime DatePublished { get; set; }

    public required string Extension { get; set; }

    public ICollection<string> Tags { get; set; } = new List<string>();

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [BsonIgnore]
    public int Size => Bytes.Length;
}
