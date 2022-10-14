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
    public class Details
    {
        public class Query : IRequest<Result<CompanyDto>>
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<CompanyDto>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<CompanyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                //var company = await _context.Companies.FindAsync(request.Id);
                var company = await _context.Companies
                .Where(xx => xx.UserId == request.UserId)
                .Where(xx => xx.Id == request.Id)
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
                        CoefCreateDate = xxx.CoefCreateDate,
                        CoefLastUpdateDate = xxx.CoefLastUpdateDate
                    }).ToList()

                })
                .FirstOrDefaultAsync();
                if (company == null) return Result<CompanyDto>.Failure("Not Found");
                return Result<CompanyDto>.Success(company);
            }
        }
    }
}