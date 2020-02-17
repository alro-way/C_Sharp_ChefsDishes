using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Sharp_ChefsDishes.Models;
// for Include:
using Microsoft.EntityFrameworkCore;

namespace C_Sharp_ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
                .Include(c=>c.DishesCreated)
                .ToList();

            // int numDishes = dbContext.Chefs
            //     .Include(c=>c.DishesCreated);
            // ViewBag.NumDishes = numDishes.Count;
            return View("Chefs", AllChefs);
        }





        [HttpGet("new")]
        public IActionResult AddChef_Page()
        {
            return View("AddNewChef");
        }

        [HttpPost("addchef")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                DateTime chefBirth = newChef.BirthdayDate;
                int age = now.Year - chefBirth.Year;
                if (chefBirth > now.AddYears(-age))
                    age--;
                newChef.Age = age;
                dbContext.Chefs.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddNewChef");
        }


        [HttpGet("dishes")]
        public IActionResult DishesPage()
        {
            List<Dish> AllDishes = dbContext.Dishes
                .Include(d=>d.Creator)
                .ToList();
            return View("Dishes", AllDishes);
        }


        [HttpGet("dishes/new")]
        public IActionResult AddDish_Page()
        {
            List<Chef> AllChefs = dbContext.Chefs
                // .Include(c=>c.DishesCreated)
                // .OrderBy(c=>c.FirstName)
                .ToList();

            ViewBag.AllChefs =AllChefs;
            return View("AddDishPage");
        }

        [HttpPost("add/dish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("DishesPage");
            }
            List<Chef> AllChefs = dbContext.Chefs
                .ToList();

            ViewBag.AllChefs =AllChefs;
            return View("AddDishPage");
        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
