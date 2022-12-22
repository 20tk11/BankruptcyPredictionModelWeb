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
            public string TokenUserName { get; set; }
            public string TokenRole { get; set; }
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
                
                if (request.TokenRole != "Admin")
                {
                    if (user.UserName.ToString() != request.TokenUserName)
                    {
                        return Result<Unit>.Forbid("");
                    }
                }
                if (user == null) return null;
                // _mapper.Map(request.User, user);
                user.Organization = request.User.Organization ?? user.Organization;
                user.FirstName = request.User.FirstName ?? user.FirstName;
                user.LastName = request.User.LastName ?? user.LastName;
                user.Email = request.User.Email ?? user.Email;
                user.UserName = request.User.UserName ?? user.UserName;
                user.PasswordHash = request.User.PasswordHash ?? user.PasswordHash;
                user.PhoneNumber = request.User.PhoneNumber ?? user.PhoneNumber;
                user.Country = request.User.Country ?? user.Country;
                user.City = request.User.City ?? user.City;
                user.Role = request.User.Role ?? user.Role;


                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update user");
                await _context.SaveChangesAsync();
                // Equivalent to nothing
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
