using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kajak",
                        Description = "Lodka przeznaczona dla jedney osoby",
                        Category = "Sporty wodne",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Kamizelka ratunkowa",
                        Description = "Chroni i dodaje uroku",
                        Category = "Sporty wodne",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Pilka",
                        Description = "Zatwierdzone przez FIFA rozmiar i waga",
                        Category = "Pilka nozna",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Flagi narozne",
                        Description = "Nadadza twojemu boisku profesjonalny wyglad",
                        Category = "Pilka nozna",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadiom",
                        Description = "Skladany stadion na 35 000 osob",
                        Category = "Pilka nozna",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Czapka",
                        Description = "Zwieksza efektywnosc mozgu o 75%",
                        Category = "Szachy",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Niestabilne krzeslo",
                        Description = "Zmiejsza szanse przeciwnika",
                        Category = "Szachy",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Ludzka szachownica",
                        Description = "Przyjemna gra dla calej rodziny!",
                        Category = "Szachy",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Blyszczacy krol",
                        Description = "Figura pokryta zlotem i wysadzana diamentami",
                        Category = "Szachy",
                        Price = 1200
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
