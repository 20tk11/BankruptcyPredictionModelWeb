using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {

                var users = new List<User>
            {
                new User
                {
                    Organization = "Bankruptcy Model Development",
                    FirstName = "Tomas",
                    LastName = "Kanapickas",
                    Email = "t.kanarele@gmail.com",
                    UserName = "tomkan3",
                    PhoneNumber = "+37061167985",
                    Country = "Lithuania",
                    City = "Kaunas",
                    Role = "Admin"
                },
                new User
                {
                    Organization = "Ikea",
                    FirstName = "Petras",
                    LastName = "Petrauskas",
                    Email = "p.petras@gmail.com",
                    UserName = "petras2",
                    PhoneNumber = "+37064687269",
                    Country = "Lithuania",
                    City = "Kaunas",
                    Role = "User"
                },
                new User
                {
                    Organization = "Kauno Pienas",
                    FirstName = "Simas",
                    LastName = "Ulanovas",
                    Email = "s.ula@gmail.com",
                    UserName = "simula3",
                    PhoneNumber = "+37069628796",
                    Country = "Lithuania",
                    City = "Kaunas",
                    Role = "User"
                },
                new User
                {
                    Organization = "Avitela",
                    FirstName = "Rokas",
                    LastName = "Petrauskas",
                    Email = "r.petra@gmail.com",
                    UserName = "rokpet23",
                    PhoneNumber = "+37064697824",
                    Country = "Lithuania",
                    City = "Vilnius",
                    Role = "User"
                },
                new User
                {
                    Organization = "IKI",
                    FirstName = "Gytis",
                    LastName = "Čiapas",
                    Email = "GČiapas@gmail.com",
                    UserName = "Gutia",
                    PhoneNumber = "+37065697888",
                    Country = "Lithuania",
                    City = "Klaipėda",
                    Role = "User"
                }
            };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa55word");
                }
            }



            // await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
