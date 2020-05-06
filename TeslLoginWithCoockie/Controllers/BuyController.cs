using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeslLoginWithCoockie.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace TeslLoginWithCoockie.Controllers
{

    public class BuyController : Controller
    {
        public UserContext context;

        
        public BuyController(UserContext context)
        {
            this.context = context;


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(int id, [Bind("Id,Liters,Name")] Fuel fuel,User user)
        {
            Purchase purchase = new Purchase();
            if (id != fuel.Id)
            {
                return NotFound();
            }
            var current = await context.Fuels.AsNoTracking().FirstAsync(it => it.Id == id);
            var liters = current.Liters;
            user = context.Users.ToList().FirstOrDefault(x => x.Email == User.Identity.Name);
            var usId = user.Id;
            if (ModelState.IsValid)
            {
                try
                {
                    purchase.FuelId = current.Id;
                    purchase.UserId = usId;
                    purchase.PurchaseTime = DateTime.Now;
                    purchase.FuelName = current.Name;
                    user.Bonus += fuel.Liters / 10 ;
                    user.AllLiters += fuel.Liters;
                    purchase.Liters = fuel.Liters;
                    fuel.Liters = liters - fuel.Liters;
                    if (fuel.Liters < 0)
                    {
                        return View("Error");
                    }
                    else
                    {

                        context.Entry(fuel).Property(c => c.Liters).IsModified = true ;
                        context.Update(purchase);
                        context.Entry(user).Property(c => c.Bonus).IsModified = true;
                        context.Entry(user).Property(c => c.AllLiters).IsModified = true;
                        await context.SaveChangesAsync();
                        return View("Thanks");
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelExists(fuel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fuel);
        }

        private bool FuelExists(int id)
        {
            return context.Fuels.Any(e => e.Id == id);
        }
    }
}