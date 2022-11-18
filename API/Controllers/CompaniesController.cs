using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Application.Companies;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users/{userid}/companies")]
    public class CompaniesController : BaseApiController
    {

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetCompanies(string userid)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new List.Query { Userid = userid, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")] //activities/id
        public async Task<IActionResult> GetCompany(Guid id, string userid)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Details.Query { Id = id, UserId = userid, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company company, string userid)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Create.Command { UserId = userid, Company = company, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCompany(string userid, Guid id, Company company)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            company.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { UserId = userid, Company = company, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }

    }
    [ApiController]
    [Route("api/companies")]
    public class CompaniesEditingController : BaseApiController
    {
        [Authorize(Roles = "Admin,User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
    }
}