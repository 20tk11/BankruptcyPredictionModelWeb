using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Coefs;
using Domain;

namespace Application.Companies
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string JARCODE { get; set; }
        public string Name { get; set; }
        public int RegistrationYear { get; set; }
        public int? DeregistrationYear { get; set; }
        public int BusinessSector { get; set; }
        public int IsBankrupt { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public ICollection<CoefDto> CompanyCoefs { get; set; } = new List<CoefDto>();
        public int? BankruptcyCaseStartYear { get; set; }
    }
}