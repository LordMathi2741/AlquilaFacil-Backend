using System.Text.Json.Serialization;
using AlquilaFacilPlatform.IAM.Domain.Model.Entities;
using AlquilaFacilPlatform.IAM.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Profiles.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash, string email)
{
    public User(): this(string.Empty, string.Empty, string.Empty)
    {
    }

    public int Id { get; }
    public string Username { get; private set; } = username;

    public string Email { get; set; } = email;

    public int RoleId { get; set; } = 2;
    

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
    
}