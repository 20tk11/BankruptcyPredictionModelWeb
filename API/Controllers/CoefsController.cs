using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Application.Coefs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users/{userid}/companies/{companyid}/coefs")]
    public class CoefsController : BaseApiController
    {
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetCoefs(string userid, Guid companyid)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new List.Query { CompanyId = companyid, Userid = userid, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")] //activities/id
        public async Task<IActionResult> GetCoef(Guid id, string userid, Guid companyid)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Details.Query { CompanyId = companyid, Id = id, UserId = userid, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }




    }
    [ApiController]
    [Route("api/companies/{companyid}/coefs")]
    public class CoefsCreateController : BaseApiController
    {
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> CreateCoef(Coef coef, Guid companyid)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Create.Command { CompanyId = companyid, Coef = coef, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCompany(Guid id)
        // {
        //     return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        // }
    }
    [ApiController]
    [Route("api/coefs")]
    public class CoefsEditController : BaseApiController
    {
        [Authorize(Roles = "Admin,User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoef(Guid id)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCompany(Guid id, Coef coef)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var TokenUserName = jwtSecurityToken.Payload["unique_name"].ToString();
            var TokenRole = jwtSecurityToken.Payload["role"].ToString();
            coef.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Coef = coef, Id = id, TokenUserName = TokenUserName, TokenRole = TokenRole }));
        }
    }
}
