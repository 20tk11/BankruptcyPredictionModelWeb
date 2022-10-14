using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Coefs
{
    public class CoefsValidator : AbstractValidator<Coef>
    {
        public CoefsValidator()
        {
            RuleFor(x => x.FinancialYear).NotEmpty();
            RuleFor(x => x.Audit).NotEmpty();
            RuleFor(x => x.SingleShareholder).NotEmpty();
            RuleFor(x => x.NumberOfEntries).NotEmpty();
            RuleFor(x => x.FinancialReportLate).NotEmpty();
            RuleFor(x => x.FinancialReportEstablishmentYear).NotEmpty();
            RuleFor(x => x.NOR_1B_1).NotEmpty();
            RuleFor(x => x.NOR_1B_2).NotEmpty();
        }
    }
}