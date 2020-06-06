using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VectoTask.Models;

namespace VectoTask.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider
                                        .GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.Tours.Any())
                {
                    context.Tours.AddRange(
                        new Tour
                        {
                            Title = "Hiking Tour",
                            StartDate =new  DateTime(2020, 6, 10),
                            EndDate= new DateTime(2020, 6, 17),
                        },

                        new Tour
                        {
                            Title = "Museum Tour",
                            StartDate = new DateTime(2020, 6, 12),
                            EndDate = new DateTime(2020, 6, 20),
                        },
                        new Tour
                        {
                            Title = "Hiking Tour2",
                            StartDate = new DateTime(2020, 6, 9),
                            EndDate = new DateTime(2020, 6, 25),
                        },
                        new Tour
                        {
                            Title = "Off Road Tour",
                            StartDate = new DateTime(2020, 6, 11),
                            EndDate = new DateTime(2020, 6, 28),
                        });
                    context.SaveChanges();
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category
                        {
                            Title = "Hiking"
                        },
                        new Category
                        {
                            Title = "Museum"
                        },
                        new Category
                        {
                            Title = "Diving"
                        },
                        new Category
                        {
                            Title = "Off Road"
                        }
                        ) ;
                    context.SaveChanges();
                };

                if (context.Categories.Any() && context.Tours.Any())
                {
                    var tId = context.Tours.Select(x=>x.Id).FirstOrDefault();
                    var cId = context.Categories.Select(x => x.Id).FirstOrDefault();
                    context.TourCategories.AddRange(
                        new TourCategory
                        {
                            TourId=tId,
                            CategoryId=cId
                        }
                        );
                    context.SaveChanges();
                };
            }
        }
    }
}

