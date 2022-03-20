using API.Data;
using API.Models;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;
using System.Security.Claims;

namespace API.Controllers
{
 
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository UserRepo, IMapper mapper)
        {
            _userRepo = UserRepo;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _userRepo.GetMembersAsync();
                        return Ok(users);
            
        }        
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser( int Id)
        {
            return await _userRepo.GetIdAsync(Id);
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUserNameAsync( string username)
        {
           var user= await _userRepo.GetMemberAsync(username);
            return _mapper.Map<MemberDto>(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMember(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepo.GetUserByUsernameAsync(username);
            _mapper.Map(memberUpdateDto, user);

            if (await _userRepo.SaveAllAsync()) return NoContent();
            return BadRequest("Failed to update user");
        }
    }
}
