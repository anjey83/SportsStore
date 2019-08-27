using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController( IProductRepository repo )
        {
            repository = repo;
        }
        public ViewResult Index() => View( repository.Products );

        public ViewResult Edit( int productId ) => View( repository.Products.FirstOrDefault( p => p.ProductID == productId ) );

        [HttpPost]
        public IActionResult Edit( Product product )
        {
            if ( ModelState.IsValid )
            {
                repository.SaveProduct( product );
                TempData["message"] = $"{product.Name} has been changed";

                return RedirectToAction( nameof( Index ) );
            }
            else
            {
                return View( product );
            }
        }
    }
}