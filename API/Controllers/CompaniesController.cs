using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Companies;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users/{userid}/companies")]
    public class CompaniesController : BaseApiController
    {


        [HttpGet]
        public async Task<IActionResult> GetCompanies(Guid userid)
        {
            return HandleResult(await Mediator.Send(new List.Query { Userid = userid }));
        }

        [HttpGet("{id}")] //activities/id
        public async Task<IActionResult> GetCompany(Guid id, Guid userid)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id, UserId = userid }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company company, Guid userid)
        {
            return HandleResult(await Mediator.Send(new Create.Command { UserId = userid, Company = company }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCompany(Guid userid, Guid id, Company company)
        {
            company.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { UserId = userid, Company = company }));
        }

    }
    [ApiController]
    [Route("api/companies")]
    public class CompaniesEditingController : BaseApiController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}