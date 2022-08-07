using server.Entites;
using server.Models;

namespace server.Services
{
    public interface IInstagramRepository
    {
        // User Services 
        void CreateUser(User user);
        Task<User?> GetUserAsync(string username);
        Task DeleteUserAsync(User user);


        // Post Services 
        Task<Post?> GetPostByIdAync(string id);
        Task CreatePostAsync(string username, Post post);

        Task<bool> SaveChangesAsync();

    }
}
