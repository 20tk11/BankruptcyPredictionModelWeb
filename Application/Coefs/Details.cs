using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Coefs;
using Application.Companies;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Coefs
{
    public class Details
    {
        public class Query : IRequest<Result<CoefDto>>
        {
            public Guid Id { get; set; }
            public string UserId { get; set; }
            public Guid CompanyId { get; set; }
            public string TokenUserName { get; set; }
            public string TokenRole { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<CoefDto>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<CoefDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                var user = await _context.Users.FirstOrDefaultAsync(x =>
                x.Id == request.UserId);

                if (request.TokenRole != "Admin")
                {
                    if (user.UserName.ToString() != request.TokenUserName)
                    {
                        return Result<CoefDto>.Forbid("");
                    }
                }
                if (user == null) return Result<CoefDto>.Failure("Tokio naudotojo nėra");

                var companies = await _context.Companies
                .Where(xx => xx.Id == request.Id)
                .Where(xx => xx.Id == request.CompanyId)
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
                })
                .ToListAsync();
                if (companies.Capacity == 0) return Result<CoefDto>.Failure("Naudotojas tokios Įmones neturi");

                var coefs = await _context.Coefs
                .Where(xx => xx.CompanyId == request.CompanyId)
                .Where(xx => xx.Id == request.Id)
                .Select(xx => new CoefDto
                {

                    Id = xx.Id,
                    FinancialYear = xx.FinancialYear,
                    Audit = xx.Audit,
                    FinancialYearsTillBankruptcy = xx.FinancialYearsTillBankruptcy,
                    SingleShareholder = xx.SingleShareholder,
                    NumberOfEntries = xx.NumberOfEntries,
                    FinancialReportLate = xx.FinancialReportLate,
                    FinancialReportEstablishmentYear = xx.FinancialReportEstablishmentYear,
                    NOR_1B_1 = xx.NOR_1B_1,
                    NOR_1B_2 = xx.NOR_1B_2,
                    CompanyId = xx.CompanyId,

                })
                .FirstOrDefaultAsync();
                if (coefs == null) return Result<CoefDto>.Failure("Ši naudotojo įmonė neturi neturi tokio koeficiento");
                return Result<CoefDto>.Success(coefs);
            }
        }
    }
}