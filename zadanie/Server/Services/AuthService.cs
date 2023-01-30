using System.Security.Cryptography;
using System.Text;
using FluentResults;
using MongoDB.Driver;
using PicturePortal.Data;
using PicturePortal.Models;

namespace PicturePortal.Services;

public class AuthService
{
    private readonly IMongoCollection<User> _usersCollection;

    public AuthService(DatabaseContext dbContext)
    {
        _usersCollection = dbContext.Users;
    }

    private static string Hash(string s)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(s);
        byte[] hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    public async Task<Result<User>> VerifyLoginInfo(string username, string password)
        => await VerifyLoginInfo(username, password, CancellationToken.None);

    private async Task<Result<User>> VerifyLoginInfo(string username, string password, CancellationToken cancellationToken)
    {
        User? user = await _usersCollection
            .Find(u => u.Username == username)
            .FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            return Result.Fail("Given username and password did not match");
        }
        string passwordHash = Hash(password);
        if (passwordHash != user.PasswordHash)
        {
            return Result.Fail("Given username and password did not match");
        }
        return Result.Ok(user);
    }

    public async Task<Result<User>> CreateUser(string username, string password)
        => await CreateUser(username, password, CancellationToken.None);

    public async Task<Result<User>> CreateUser(string username, string password, CancellationToken cancellationToken)
    {
        bool exists = await _usersCollection
            .Find(u => u.Username == username)
            .AnyAsync(cancellationToken);
        if (exists)
        {
            return Result.Fail("User with given username already exits");
        }
        User user = new()
        {
            Username = username,
            PasswordHash = Hash(password)
        };
        InsertOneOptions options = new();
        await _usersCollection.InsertOneAsync(user, options, cancellationToken);
        return Result.Ok(user);
    }
}
