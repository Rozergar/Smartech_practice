using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using PhoneStore.Data;
using System;
using System.Linq;

namespace PhoneStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PhoneStoreContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<PhoneStoreContext>>()))
            {
                if (context.Phones.Any())
                {
                    return;   // DB has been seeded
                }
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 60000
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 55000
                    },
                    new Phone
                    {
                        Name = "Pixel 5",
                        Company = "Google",
                        Price = 50000
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
