using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<User> userManger, SignInManager<User> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManger;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                if (user.Token == null)
                {
                    return new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Token = _tokenService.CreateToken(user),
                        Username = user.UserName,
                        Email = user.Email,
                        Role = user.Role

                    };
                }
                else
                {
                    return new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Token = user.Token,
                        Username = user.UserName,
                        Email = user.Email,
                        Role = user.Role

                    };
                }

            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                return BadRequest("Username taken");
            }
            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Country = registerDto.Country,
                City = registerDto.City,
                Organization = registerDto.Organization,
                Role = "User"
            };
            var useris = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                City = user.City,
                Organization = user.Organization,
                Role = "User",
                Token = _tokenService.CreateToken(user)
            };
            var result = await _userManager.CreateAsync(useris, registerDto.Password);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Country = user.Country,
                    City = user.City,
                    Role = user.Role,
                    Organization = user.Organization,
                    Token = user.Token
                };
            }
            return BadRequest("Problem registering user");
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return new UserDto
            {
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                City = user.City,
                Organization = user.Organization,
                Role = user.Role,
                Token = user.Token
            };

        }
    }
}