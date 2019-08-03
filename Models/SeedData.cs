using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EticaretShoes.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            Context context = app.ApplicationServices.GetService<Context>();

            context.Database.Migrate();

            if (!context.Shoes.Any())
            {
                context.Shoes.AddRange(new Shoes() { ShoesName = "Cocuk Ayakkabı", Gender = "Erkek", imageUrl = "product-1.png", CategoryNo = 1, Price = 50 },
                    new Shoes() { ShoesName = "Erkek Ayakkabı", Gender = "Kadın", imageUrl = "product-2.png", CategoryNo = 1, Price = 50 },
                    new Shoes() { ShoesName = "Cocuk Ayakkabı", Gender = "Erkek", imageUrl = "product-3.png", CategoryNo = 2, Price = 250 },
                    new Shoes() { ShoesName = "Spor Ayakkabı", Gender = "Kadın", imageUrl = "product-4.png", CategoryNo = 2, Price = 150 },
                    new Shoes() { ShoesName = "Kadın Ayakkabı", Gender = "Erkek", imageUrl = "product-5.png", CategoryNo = 1, Price = 250 },
                    new Shoes() { ShoesName = "Yazlık Ayakkabı", Gender = "Kadın", imageUrl = "product-6.png", CategoryNo = 3, Price = 350 },
                    new Shoes() { ShoesName = "Kadın Ayakkabı", Gender = "Kadın", imageUrl = "product-7.png", CategoryNo = 3, Price = 550 },
                    new Shoes() { ShoesName = "Kadın Ayakkabı", Gender = "Kadın", imageUrl = "product-8.png", CategoryNo = 1, Price = 450 },
                    new Shoes() { ShoesName = "Erkek Ayakkabı", Gender = "Erkek", imageUrl = "prod-1.png", CategoryNo = 1, Price = 350 },
                    new Shoes() { ShoesName = "Erkek Ayakkabı", Gender = "Erkek", imageUrl = "prod-2.png", CategoryNo = 1, Price = 750 }
                    );
                context.SaveChanges();


            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "Cocuk" }, new Category { CategoryName = "Kadın" }, new Category { CategoryName = "Erkek" });
                context.SaveChanges();
            }
        }
    }
}
