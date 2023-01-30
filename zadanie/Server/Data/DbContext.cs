using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PicturePortal.Models;
using PicturePortal.Settings;

namespace PicturePortal.Data;

public class DatabaseContext
{
    private readonly DatabaseOptions _options;
    private readonly IMongoDatabase _database;

    public DatabaseContext(IMongoClient client, IOptions<DatabaseOptions> options)
    {
        _options = options.Value;
        _database = client.GetDatabase(_options.DatabaseName);
    }

    public IMongoCollection<User> Users =>
        _database.GetCollection<User>(_options.UsersCollectionName);

    public IMongoCollection<Image> Images =>
        _database.GetCollection<Image>(_options.ImagesCollectionName);
}
