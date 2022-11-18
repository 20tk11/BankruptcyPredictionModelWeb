using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Coefs
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Coef Coef { get; set; }
            public Guid CompanyId { get; set; }
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
                var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.CompanyId);
                var user = await _context.Users.FindAsync(company.UserId);
                if (request.TokenRole != "Admin")
                {
                    if (user.UserName.ToString() != request.TokenUserName)
                    {
                        return Result<Unit>.Forbid("");
                    }
                }
                _context.Coefs.Add(request.Coef);
                company.CompanyCoefs.Add(request.Coef);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Coefs");
                // Equivalent to nothing
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}