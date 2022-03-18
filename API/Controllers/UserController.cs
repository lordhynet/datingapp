﻿using API.Data;
using API.Models;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
   
    public class UserController : BaseApiController
    {
        private readonly Datacontext _context;

        public UserController(Datacontext context)
        {
            _context= context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return  await _context.Users.ToListAsync();
            
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser( int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
    }
}
