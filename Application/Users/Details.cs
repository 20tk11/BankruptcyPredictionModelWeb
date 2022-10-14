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

namespace Application.Users
{
    public class Details
    {
        public class Query : IRequest<Result<UserDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<UserDto>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // var user = await _context.Users.FindAsync(request.Id);
                var user = await _context.Users
                .Where(a => a.Id == request.Id)
                .Include(a => a.UserCompanies)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Organization = x.Organization,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress,
                    LoginName = x.LoginName,
                    LoginPassword = x.LoginPassword,
                    PhoneNumber = x.PhoneNumber,
                    Country = x.Country,
                    City = x.City,
                    UserCreateDate = x.UserCreateDate,
                    UserLastUpdateDate = x.UserLastUpdateDate,
                    UserCompanies = x.UserCompanies.Select(xx => new CompanyDto
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
                        }).ToList(),
                    }).ToList()
                })
                .FirstOrDefaultAsync();
                if (user == null) return Result<UserDto>.Failure("Tokio Naudotojo nėra");
                return Result<UserDto>.Success(user);
            }
        }
    }
}