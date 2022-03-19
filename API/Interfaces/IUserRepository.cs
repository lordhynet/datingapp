using API.Models;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser appuser);
        Task<bool> SaveAllAsync ();
        Task<IEnumerable<AppUser>> GetUsersAsync ();
        Task<AppUser> GetIdAsync (int id);
        Task<AppUser> GetUserByUserNameAsync(string username); 
    }
}
