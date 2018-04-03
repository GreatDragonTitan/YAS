using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAS.Models.Records;
using YAS.Models.Repositories;

namespace YAS.Models.Seeders
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new PostRecord
                    {
                        Title = "Painting",
                        Description = "I need someone to paint my car",
                        DateAdded = new DateTime(2018, 2, 12)
                    },
                    new PostRecord
                    {
                        Title = "Fixing",
                        Description = "I need someone to fix my car",
                        DateAdded = new DateTime(2018, 2, 15)
                    },
                    new PostRecord
                    {
                        Title = "New car",
                        Description = "I am in need of new car",
                        DateAdded = new DateTime(2018, 2, 24)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
