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

namespace Application.Coefs
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Coef Coef { get; set; }
            public Guid Id { get; set; }
            public string TokenUserName { get; set; }
            public string TokenRole { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Coef).SetValidator(new CoefsValidator());
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

                var coef = await _context.Coefs.FindAsync(request.Coef.Id);
                var company = await _context.Companies.FindAsync(coef.CompanyId);
                var user = await _context.Users.FindAsync(company.UserId);

                if (request.TokenRole != "Admin")
                {
                    if (user.UserName.ToString() != request.TokenUserName)
                    {
                        return Result<Unit>.Forbid("");
                    }
                }
                if (coef == null) return Result<Unit>.Failure("Toks koeficientas neegzistuoja");

                if (request.Coef.FinancialYear != 0)
                {
                    coef.FinancialYear = request.Coef.FinancialYear;
                }
                if (request.Coef.Audit != 0)
                {
                    coef.Audit = request.Coef.Audit;
                }
                coef.FinancialYearsTillBankruptcy = request.Coef.FinancialYearsTillBankruptcy ?? coef.FinancialYearsTillBankruptcy;
                if (request.Coef.SingleShareholder != 0)
                {
                    coef.SingleShareholder = request.Coef.SingleShareholder;
                }
                if (request.Coef.NumberOfEntries != 0)
                {
                    coef.NumberOfEntries = request.Coef.NumberOfEntries;
                }
                if (request.Coef.FinancialReportLate != 0)
                {
                    coef.FinancialReportLate = request.Coef.FinancialReportLate;
                }
                if (request.Coef.FinancialReportEstablishmentYear != 0)
                {
                    coef.FinancialReportEstablishmentYear = request.Coef.FinancialReportEstablishmentYear;
                }
                coef.NOR_1B_1 = request.Coef.NOR_1B_1 ?? coef.NOR_1B_1;
                coef.NOR_1B_2 = request.Coef.NOR_1B_2 ?? coef.NOR_1B_2;

                //coef.CompanyId = request.Id;

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Jau atnaujinta pagal tokią specifikaciją");
                await _context.SaveChangesAsync();
                // Equivalent to nothing
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
