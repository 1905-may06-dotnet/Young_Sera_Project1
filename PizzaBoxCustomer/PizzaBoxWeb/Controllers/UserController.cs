using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBoxDomain;
using PizzaBoxWeb.Models;

namespace PizzaBoxWeb.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository URepo;
        private ILocationRepository LRepo;
        public UserController(IUserRepository URepo, ILocationRepository LRepo)
        {
            this.URepo = URepo;
            this.LRepo = LRepo;
        }
        public IActionResult SignIn()
        {
            var val = HttpContext.Session.GetString("Username");
            if(string.IsNullOrEmpty(val))
                return View();
            return View("WarningMessage", "You are already signed in. Sign out to change accounts.");
        }

        public IActionResult VerifyLogin(UserModel user)
        {
            if(URepo.PassValidation(user.Username,user.Password))
            {
                HttpContext.Session.SetString("Username", user.Username);
                DomUser loggedin = URepo.GetUser(user.Username);
                string address = LRepo.GetLocation(loggedin.LocationId).Address;
                HttpContext.Session.SetString("Location", address);
                return RedirectToAction("Index", "Home");
            }
            return View("WarningMessage", "Incorrect Username or Password.");
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.SetString("Username", "");
            HttpContext.Session.SetString("Location", "");
            return View("WarningMessage", "You have been successfully signed out.");
        }

        public IActionResult SignUp()
        {
            if(!String.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return View("WarningMessage", "You are already signed in, sign out to create a new account.");
            }
            return View();
        }

        public IActionResult SelectLocation(Models.UserModel user)
        {
            if(!URepo.UserNameTaken(user.Username))
            {
                TempData.Add("newUsername", user.Username);
                TempData.Add("newPassword", user.Password);
                List<DomLocation> list = LRepo.GetLocationList();
                List<LocationModel> mlist = new List<LocationModel>();
                foreach (var l in list)
                {
                    LocationModel nl = new LocationModel();
                    nl.Id = l.Id;
                    nl.address = l.Address;
                    mlist.Add(nl);
                }

                return View(mlist);
            }
            return View("WarningMessage", "Username is already in use.");
        }

        public IActionResult CreateUser(int Id)
        {
            string username = (string)TempData["newUsername"];
            string password = (string)TempData["newPassword"];
            DomUser user = new DomUser(username,Id,password);
            URepo.AddUser(user);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Location", LRepo.GetLocation(Id).Address);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ChangeLocation()
        {
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return View("WarningMessage", "You are not logged in. Log in to select a location.");
            }
            List<DomLocation> list = LRepo.GetLocationList();
            List<LocationModel> mlist = new List<LocationModel>();
            foreach (var l in list)
            {
                LocationModel nl = new LocationModel();
                nl.Id = l.Id;
                nl.address = l.Address;
                mlist.Add(nl);
            }
            return View(mlist);
        }

        public IActionResult UpdateUser(int Id)
        {
            int LocationId = Id;
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return View("WarningMessage", "Your session timed out. Please log in again to change your location.");
            }

            DomUser update = URepo.GetUser(HttpContext.Session.GetString("Username"));
            update.LocationId = LocationId;
            URepo.UpdateUser(update);
            HttpContext.Session.SetString("Location", LRepo.GetLocation(LocationId).Address);
            return RedirectToAction("Index", "Home");
        }
    }
}