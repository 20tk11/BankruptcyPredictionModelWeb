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
    public class List
    {
        public class Query : IRequest<Result<List<CoefDto>>>
        {
            public Guid Userid { get; set; }
            public Guid CompanyId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<CoefDto>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<CoefDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x =>
                x.Id == request.Userid);
                if (user == null) return Result<List<CoefDto>>.Failure("Tokio naudotojo nėra");

                var companies = await _context.Companies
                .Where(xx => xx.UserId == request.Userid)
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
                    CompanyCreateDate = xx.CompanyCreateDate,
                    CompanyLastUpdateDate = xx.CompanyLastUpdateDate,
                })
                .ToListAsync();
                if (companies.Capacity == 0) return Result<List<CoefDto>>.Failure("Naudotojas tokios Įmones neturi");

                var coefs = await _context.Coefs
                .Where(xx => xx.CompanyId == request.CompanyId)
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
                    CoefCreateDate = xx.CoefCreateDate,
                    CoefLastUpdateDate = xx.CoefLastUpdateDate

                })
                .ToListAsync();
                if (coefs.Count == 0) return Result<List<CoefDto>>.Failure("Ši naudotojo įmonė neturi koeficientų");
                return Result<List<CoefDto>>.Success(coefs);
            }
        }
    }
}