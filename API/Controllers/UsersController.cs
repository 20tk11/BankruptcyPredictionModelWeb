using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Users;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : BaseApiController
    {

        // [Authorize]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            // var name = Auth
            // return Ok(name);
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")] //activities/id
        public async Task<IActionResult> GetUser(string id)
        {

            string token = HttpContext.Request.Headers["Authorization"];
            token = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRvbWthbjMiLCJuYW1laWQiOiIyN2ZlMzllZS03ZGM5LTRjNjAtOGUxYy04YjBjNzJjMjNiMmMiLCJlbWFpbCI6InQua2FuYXJlbGVAZ21haWwuY29tIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjcxNDgyODE3LCJleHAiOjE2NzIwODc2MTcsImlhdCI6MTY3MTQ4MjgxN30.6MEgRNMzmx6AHTqYgExMyXqsMN_UVH28_S4rQlz-_0FKI4Yb3_dXh7OxrVNw2bCjwz18MmfdvJTtez-sJ22Qpw";
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Details.Query { Id = id, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            return HandleResult(await Mediator.Send(new Create.Command { User = user }));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(string id, User user)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRvbWthbjMiLCJuYW1laWQiOiIyN2ZlMzllZS03ZGM5LTRjNjAtOGUxYy04YjBjNzJjMjNiMmMiLCJlbWFpbCI6InQua2FuYXJlbGVAZ21haWwuY29tIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjcxNDgyODE3LCJleHAiOjE2NzIwODc2MTcsImlhdCI6MTY3MTQ4MjgxN30.6MEgRNMzmx6AHTqYgExMyXqsMN_UVH28_S4rQlz-_0FKI4Yb3_dXh7OxrVNw2bCjwz18MmfdvJTtez-sJ22Qpw";
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            user.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { User = user, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(string id)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRvbWthbjMiLCJuYW1laWQiOiIyN2ZlMzllZS03ZGM5LTRjNjAtOGUxYy04YjBjNzJjMjNiMmMiLCJlbWFpbCI6InQua2FuYXJlbGVAZ21haWwuY29tIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjcxNDgyODE3LCJleHAiOjE2NzIwODc2MTcsImlhdCI6MTY3MTQ4MjgxN30.6MEgRNMzmx6AHTqYgExMyXqsMN_UVH28_S4rQlz-_0FKI4Yb3_dXh7OxrVNw2bCjwz18MmfdvJTtez-sJ22Qpw";
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
    }
}