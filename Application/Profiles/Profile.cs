using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Profiles
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Company> UserCompanies { get; set; } = new List<Company>();
        public DateTime UserCreateDate { get; set; }
        public DateTime UserLastUpdateDate { get; set; }
    }
}