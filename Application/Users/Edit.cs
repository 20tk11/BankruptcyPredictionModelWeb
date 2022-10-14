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

namespace Application.Users
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public User User { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.User).SetValidator(new UserValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            // private readonly IMapper _mapper;

            public Handler(DataContext context/*, IMapper mapper*/)
            {
                _context = context;
                // _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.User.Id);

                if (user == null) return null;
                // _mapper.Map(request.User, user);
                user.Organization = request.User.Organization ?? user.Organization;
                user.FirstName = request.User.FirstName ?? user.FirstName;
                user.LastName = request.User.LastName ?? user.LastName;
                user.EmailAddress = request.User.EmailAddress ?? user.EmailAddress;
                user.LoginName = request.User.LoginName ?? user.LoginName;
                user.LoginPassword = request.User.LoginPassword ?? user.LoginPassword;
                user.PhoneNumber = request.User.PhoneNumber ?? user.PhoneNumber;
                user.Country = request.User.Country ?? user.Country;
                user.City = request.User.City ?? user.City;


                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update user");
                user.UserLastUpdateDate = DateTime.Now;
                await _context.SaveChangesAsync();
                // Equivalent to nothing
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
