using Microsoft.EntityFrameworkCore;
using server.DbContexts;
using server.Entites;
using server.Models;

namespace server.Services
{
    public class InstagramRepository : IInstagramRepository
    {
        private readonly InstagramDbContext _context;

        public InstagramRepository(InstagramDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreatePostAsync(string username, Post post)
        {

            var user = await GetUserAsync(username);
              if(user != null)
            {
               user.Posts.Add(post);
            }
            
        }

        public void CreateUser(User user)
        {
            
                _context.Users.Add(user);
            
            
        }

        public async Task DeleteUserAsync(User user)
        {
      
                _context.Users.Remove(user);

        }

        public async Task<Post?> GetPostByIdAync(string id)
        {
           return await _context.Posts.Where(p=>p.Id.ToString() ==id).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserAsync(string username)
        {
            return await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

      
    }
}
