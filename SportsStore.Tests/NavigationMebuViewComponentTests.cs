using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SportsStore.Tests
{
    public class NavigationMebuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup( m => m.Products ).Returns( (new Product[] {
                new Product { ProductID = 1, Name = "Pl", Category = "Apples" },
                new Product { ProductID = 2, Name = "Р2", Category = "Apples" },
                new Product { ProductID = 3, Name = "РЗ", Category = "Plums" },
                new Product { ProductID = 4, Name = "Р4", Category = "Oranges" }
            }).AsQueryable<Product>() );

            NavigationMenuViewComponent target = new NavigationMenuViewComponent( mock.Object );
           
            //
            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            //
            Assert.True( Enumerable.SequenceEqual( new string[] { "Apples", "Oranges", "Plums" }, results ));
        }
    }
}
