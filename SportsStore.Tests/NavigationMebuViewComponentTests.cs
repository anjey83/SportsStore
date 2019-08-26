using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
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

        [Fact]
        public void Indicates_Selected_Category()
        {
            //
            string categoryToSelect = "Apples";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup( m => m.Products ).Returns( (new Product[] {
                new Product {ProductID = 1, Name = "Pl", Category = "Apples" },
                new Product {ProductID = 4, Name = "Р2", Category = "Oranges" },
                }).AsQueryable<Product>() );

            NavigationMenuViewComponent target = new NavigationMenuViewComponent( mock.Object );
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };

            target.RouteData.Values["category"] = categoryToSelect;

            //
            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];
            //
            Assert.Equal( categoryToSelect, result );
        }
    }
}
