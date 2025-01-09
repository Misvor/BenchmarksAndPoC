using Refit;

namespace LightweightApi;

public interface IGitHubApi
{
    [Get("/users/{user}")]
    Task<User> GetUser(string user);
}

public class User
{
    
}