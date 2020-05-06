using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeslLoginWithCoockie.Models;

namespace TeslLoginWithCoockie.Controllers
{
    public class AdminController : Controller
    {

        private UserContext db;

        private readonly IHttpContextAccessor _httpControllerAccessor;

        public AdminController(UserContext context, IHttpContextAccessor httpControllerAccessor)
        {
            db = context;
            _httpControllerAccessor = httpControllerAccessor;
        }



        public async Task<IActionResult> ProfileAdmin()
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Email == _httpControllerAccessor.HttpContext.User.Identity.Name);
            return View(user);

        }


        public async Task<IActionResult> UserList()
        {
            List<User> UserList = new List<User>();
            foreach(User u in db.Users)
            {
                if(u.Email == "admin@mail.ru")
                {
                    continue;
                }
                else
                {
                    UserList.Add(u);
                }
            }
            ViewBag.Users = UserList;
            return View();
        }



        public async Task<IActionResult> PurchaseList()
        {
            List<Purchase> PurchaseList = new List<Purchase>();
            foreach(Purchase p in db.Purchases)
            {
                PurchaseList.Add(p);
            }
            ViewBag.AdminPurchase = PurchaseList;
            return View();

        }

        public async Task<IActionResult> FuelList()
        {
            List<Fuel> fuel = new List<Fuel>();
            foreach(Fuel f in db.Fuels)
            {
                fuel.Add(f);
            }
            ViewBag.Fuels = fuel;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BuyFuel(int id)
        {
            if(id == 1)
            {
                List<Suppliers> supl = new List<Suppliers>();
                foreach (Suppliers s in db.Suppliers)
                {
                    if (id == s.FuelId)
                    {
                        supl.Add(s);
                    }
                }
                ViewBag.Suppliers = supl;
                return View("Buy95Admin");
            }
            else if (id == 2)
            {
                return View("Buy92Admin");
            }
            else if(id == 3)
            {
                return View("BuyDpAdmin");
            }
            else if(id == 4)
            {
                return View("BuyGusAdmin");
            }
            return View();

        }


        
        public async Task<IActionResult> ConfrimBuy(int id,string fuelName,int price)
        {
            Zakaz zakaz = new Zakaz();
            zakaz.SuppliersId = id;
            zakaz.FuelName = fuelName;
            db.Update(zakaz);
            await db.SaveChangesAsync();
            return View("Thanks");
        }
    }
}