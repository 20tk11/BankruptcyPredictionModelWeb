using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Company
    {
        public Guid Id { get; set; }
        public string JARCODE { get; set; }
        public string Name { get; set; }
        public int RegistrationYear { get; set; }
        public int? DeregistrationYear { get; set; }
        public int BusinessSector { get; set; }
        public int IsBankrupt { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Coef> CompanyCoefs { get; set; } = new List<Coef>();
        public int? BankruptcyCaseStartYear { get; set; }
        public DateTime CompanyCreateDate { get; set; }
        public DateTime CompanyLastUpdateDate { get; set; }
    }
}