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
        public ActionResult ItemList()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            ViewBag.ItemList = ORM.Items.ToList();
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


            return RedirectToAction("Summary", newUser);
        }
        public ActionResult Summary(User user)
        {
            return View(user);
        }
        public ActionResult EditUser(int UserID)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            User found = ORM.Users.Find(UserID);

            return View(found);
        }
        public ActionResult SaveUserChanges(User updatedUser)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            User oldUser = ORM.Users.Find(updatedUser.UserID);
            oldUser.FirstName = updatedUser.FirstName;
            oldUser.LastName = updatedUser.LastName;
            oldUser.Birthday = updatedUser.Birthday;
            oldUser.Email = updatedUser.Email;
            oldUser.Address = updatedUser.Address;
            oldUser.PhoneNumber = updatedUser.PhoneNumber;
            oldUser.Address = updatedUser.Address;
            oldUser.City = updatedUser.City;
            oldUser.PostalCode = updatedUser.PostalCode;
            oldUser.State = updatedUser.State;

            ORM.Entry(oldUser).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int UserID)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            User found = ORM.Users.Find(UserID);

            ORM.Users.Remove(found);
            ORM.SaveChanges();

            return RedirectToAction("Index");
        }





        public ActionResult AddItem()
        {
            return View();
        }
        public ActionResult SaveItem(Item newItem)
        {

            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();


            if (newItem != null)
            {

                ORM.Items.Add(newItem);
                ORM.SaveChanges();
            }

            return RedirectToAction("ItemList");
        }


    }
}