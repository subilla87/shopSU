
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopSU.Web.Data
{
    using shopSU.Web.Data.Entities;
    public class SeedDB
    {
        private readonly DataContext context;
        private Random random;

        public SeedDB(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("Huawei P20 Lite");
                this.AddProduct("Huawei P20");
                this.AddProduct("Huawei P20 Pro");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }

    }
}
