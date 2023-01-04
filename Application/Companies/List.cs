using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Coefs;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Companies
{
    public class List
    {
        public class Query : IRequest<Result<List<CompanyDto>>>
        {
            public string Userid { get; set; }
            public string TokenUserName { get; set; }
            public string TokenRole { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<CompanyDto>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<CompanyDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Userid);
                if (request.TokenRole != "Admin")
                {
                    if (user.UserName.ToString() != request.TokenUserName)
                    {
                        return Result<List<CompanyDto>>.Forbid("");
                    }
                }
                var companies = await _context.Companies
                .Where(xx => xx.UserId == request.Userid)
                .Select(xx => new CompanyDto
                {
                    Id = xx.Id,
                    JARCODE = xx.JARCODE,
                    Name = xx.Name,
                    RegistrationYear = xx.RegistrationYear,
                    DeregistrationYear = xx.DeregistrationYear,
                    BusinessSector = xx.BusinessSector,
                    IsBankrupt = xx.IsBankrupt,
                    UserId = xx.UserId,
                    BankruptcyCaseStartYear = xx.BankruptcyCaseStartYear,
                    CompanyCoefs = xx.CompanyCoefs.Select(xxx => new CoefDto
                    {
                        Id = xxx.Id,
                        FinancialYear = xxx.FinancialYear,
                        Audit = xxx.Audit,
                        FinancialYearsTillBankruptcy = xxx.FinancialYearsTillBankruptcy,
                        SingleShareholder = xxx.SingleShareholder,
                        NumberOfEntries = xxx.NumberOfEntries,
                        FinancialReportLate = xxx.FinancialReportLate,
                        FinancialReportEstablishmentYear = xxx.FinancialReportEstablishmentYear,
                        NOR_1B_1 = xxx.NOR_1B_1,
                        NOR_1B_2 = xxx.NOR_1B_2,
                        CompanyId = xxx.CompanyId,
                    }).ToList()

                })
                .ToListAsync();
                if (companies.Count == 0) return Result<List<CompanyDto>>.Failure("Not Found");
                return Result<List<CompanyDto>>.Success(companies);
            }
        }
    }
}