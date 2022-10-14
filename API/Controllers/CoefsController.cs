using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Coefs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users/{userid}/companies/{companyid}/coefs")]
    public class CoefsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCoefs(Guid userid, Guid companyid)
        {
            return HandleResult(await Mediator.Send(new List.Query { CompanyId = companyid, Userid = userid }));
        }

        [HttpGet("{id}")] //activities/id
        public async Task<IActionResult> GetCoef(Guid id, Guid userid, Guid companyid)
        {
            return HandleResult(await Mediator.Send(new Details.Query { CompanyId = companyid, Id = id, UserId = userid }));
        }




    }
    [ApiController]
    [Route("api/companies/{companyid}/coefs")]
    public class CoefsCreateController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCoef(Coef coef, Guid companyid)
        {
            return HandleResult(await Mediator.Send(new Create.Command { CompanyId = companyid, Coef = coef }));
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoef(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCompany(Guid id, Coef coef)
        {
            coef.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Coef = coef, Id = id, }));
        }
    }
}
