using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Companies;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Users
{
    public class UserDto : IdentityUser
    {
        public string Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<CompanyDto> UserCompanies { get; set; } = new List<CompanyDto>();
        public string Role { get; set; }
        public string Token { get; set; }


    }
}