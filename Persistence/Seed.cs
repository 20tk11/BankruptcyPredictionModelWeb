using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Users.Any()) return;

            var users = new List<User>
            {
                new User
                {
                    Organization = "Bankruptcy Model Development",
                    FirstName = "Tomas",
                    LastName = "Kanapickas",
                    EmailAddress = "t.kanarele@gmail.com",
                    LoginName = "tomkan3",
                    LoginPassword = "password",
                    PhoneNumber = "+37061167985",
                    Country = "Lithuania",
                    City = "Kaunas",
                    UserCreateDate = DateTime.Now,
                    UserLastUpdateDate = DateTime.Now
                },
                new User
                {
                    Organization = "Ikea",
                    FirstName = "Petras",
                    LastName = "Petrauskas",
                    EmailAddress = "p.petras@gmail.com",
                    LoginName = "petras2",
                    LoginPassword = "password",
                    PhoneNumber = "+37064687269",
                    Country = "Lithuania",
                    City = "Kaunas",
                    UserCreateDate = DateTime.Now,
                    UserLastUpdateDate = DateTime.Now
                },
                new User
                {
                    Organization = "Kauno Pienas",
                    FirstName = "Simas",
                    LastName = "Ulanovas",
                    EmailAddress = "s.ula@gmail.com",
                    LoginName = "simula3",
                    LoginPassword = "password",
                    PhoneNumber = "+37069628796",
                    Country = "Lithuania",
                    City = "Kaunas",
                    UserCreateDate = DateTime.Now,
                    UserLastUpdateDate = DateTime.Now
                },
                new User
                {
                    Organization = "Avitela",
                    FirstName = "Rokas",
                    LastName = "Petrauskas",
                    EmailAddress = "r.petra@gmail.com",
                    LoginName = "rokpet23",
                    LoginPassword = "password",
                    PhoneNumber = "+37064697824",
                    Country = "Lithuania",
                    City = "Vilnius",
                    UserCreateDate = DateTime.Now,
                    UserLastUpdateDate = DateTime.Now
                },
                new User
                {
                    Organization = "IKI",
                    FirstName = "Gytis",
                    LastName = "Čiapas",
                    EmailAddress = "GČiapas@gmail.com",
                    LoginName = "Gutčia",
                    LoginPassword = "password",
                    PhoneNumber = "+37065697888",
                    Country = "Lithuania",
                    City = "Klaipėda",
                    UserCreateDate = DateTime.Now,
                    UserLastUpdateDate = DateTime.Now
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
