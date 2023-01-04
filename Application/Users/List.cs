using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Coefs;
using Application.Companies;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class List
    {
        public class Query : IRequest<Result<List<UserDto>>>
        {

        }
        public class Handler : IRequestHandler<Query, Result<List<UserDto>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<UserDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users
                .Include(a => a.UserCompanies)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Organization = x.Organization,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    UserName = x.UserName,
                    PasswordHash = x.PasswordHash,
                    PhoneNumber = x.PhoneNumber,
                    Country = x.Country,
                    City = x.City,
                    Role = x.Role,
                    Token = x.Token,
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
                    }).ToList()
                })
                .ToListAsync();

                return Result<List<UserDto>>.Success(users);
            }
        }
    }
}