using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Companies
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.JARCODE).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.RegistrationYear).NotEmpty();
            RuleFor(x => x.BusinessSector).NotEmpty();
        }
    }
}