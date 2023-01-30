using MongoDB.Bson.Serialization.Attributes;

namespace PicturePortal.Models;

[BsonNoId]
public class Comment
{
    public required string Content { get; set; }

    public required string AuthorName { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public required DateTime DateAdded { get; set; }
}
