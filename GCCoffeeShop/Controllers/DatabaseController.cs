using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCCoffeeShop.Controllers;
using GCCoffeeShop.Models;

namespace GCCoffeeShop.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            ViewBag.UserList = ORM.Users.ToList();
            return View();
            
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult SaveUser(User newUser)
        {

            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();


            if (newUser != null)
            {

                ORM.Users.Add(newUser);
                ORM.SaveChanges();
            }

            return RedirectToAction("Summary");
        }
        public ActionResult Summary(User user)
        {


            return View(user);
        }

    }
}