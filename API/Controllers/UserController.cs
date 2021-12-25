using API.Data;
using API.Models;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Datacontext _context;

        public UserController(Datacontext context)
        {
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return  await _context.Users.ToListAsync();
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser( int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
    }
}
