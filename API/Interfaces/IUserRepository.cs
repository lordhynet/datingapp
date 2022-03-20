using API.DTOs;
using API.Models;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser appuser);
        Task<bool> SaveAllAsync ();
        Task<IEnumerable<AppUser>> GetUsersAsync ();
        Task<AppUser> GetIdAsync (int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync (string username);

    }
}
