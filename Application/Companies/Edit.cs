using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Companies
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Company Company { get; set; }
            public string UserId { get; set; }
            public string TokenUserName { get; set; }
            public string TokenRole { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Company).SetValidator(new CompanyValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.UserId);
                if (request.TokenRole != "Admin")
                {
                    if (user.UserName.ToString() != request.TokenUserName)
                    {
                        return Result<Unit>.Forbid("");
                    }
                }
                var company = await _context.Companies.FindAsync(request.Company.Id);
                if (company == null) return null;

                company.JARCODE = request.Company.JARCODE ?? company.JARCODE;
                company.Name = request.Company.Name ?? company.Name;
                if (request.Company.RegistrationYear != 0)
                {
                    company.RegistrationYear = request.Company.RegistrationYear;
                }

                company.DeregistrationYear = request.Company.DeregistrationYear ?? company.DeregistrationYear;
                if (request.Company.BusinessSector != 0)
                {
                    company.BusinessSector = company.BusinessSector;
                }
                if (request.Company.IsBankrupt != 0)
                {
                    company.IsBankrupt = request.Company.IsBankrupt;
                }
                company.UserId = request.UserId;
                company.BankruptcyCaseStartYear = request.Company.BankruptcyCaseStartYear ?? company.BankruptcyCaseStartYear;

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update user");
                company.CompanyLastUpdateDate = DateTime.Now;
                await _context.SaveChangesAsync();
                // Equivalent to nothing
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
