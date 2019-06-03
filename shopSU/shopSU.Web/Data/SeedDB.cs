
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopSU.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using shopSU.Web.Data.Entities;
    using shopSU.Web.Helpers;

    public class SeedDB
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("subilla@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Santiago",
                    LastName = "Ubilla",
                    Email = "subilla@gmail.com",
                    UserName = "subilla87",
                    PhoneNumber = "0994350349"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

                if (!this.context.Products.Any())
            {
                this.AddProduct("Huawei P20 Lite", user);
                this.AddProduct("Huawei P20", user);
                this.AddProduct("Huawei P20 Pro", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }

    }
}
