using Microsoft.EntityFrameworkCore;
using PromomashTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task EnsureSeedData(ApplicationDbContext context)
        {
            if (context.Countries.Any())
                return;

            var country1 = new Country("USA");
            country1.AddProvince("Texas");
            country1.AddProvince("Florida");

            var country2 = new Country("Germany");
            country2.AddProvince("Berlin");
            country2.AddProvince("Bavaria");
            country2.AddProvince("Hesse");

            context.Countries.AddRange(country1, country2);

            await context.SaveChangesAsync();         
        }
    }
}
