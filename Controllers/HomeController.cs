using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using kp2.Mocks;
using kp2.Models;
using kp2.ViewModels;
using kp2.Interfaces;
using kp2.Services;

namespace kp2.Controllers
{
    public class HomeController : Controller
    {

        private AppDBContext db;
        private readonly IAllTVs _AllTVs;
      
        public HomeController(IAllTVs IAllTVs, AppDBContext context)
        {
            _AllTVs = IAllTVs;
            db = context;
        }
        public ViewResult Index()
        {
            ViewData["name"] = User.Identity.Name;
            var TVs = db.TVs.ToList();
            return View(TVs);
        }
        public async Task<IActionResult> Create() 
        {
            Cart ca = new Cart();
            ca.idTV = 2;
            ca.idUser = 1;
            db.Carts.Add(ca);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public ViewResult Info(int I)
        {
            
            ViewData["TID"] = I;
            var CTs = db.Carts.ToList();
            var Tvs = db.TVs.ToList();
            var cm = new CM { Cts = CTs, TVs = Tvs };
            return View(cm);
        }
        public async Task<IActionResult> Buy()
        {
            User u = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            List<Cart> C = db.Carts.Where(c => c.idUser == u.Id).ToList();
            string mes = "";
            List<TV> T = db.TVs.ToList();
            foreach (var V in C)
            {
                foreach (var tv in T)
                    if (V.idTV == tv.id)
                    {
                        mes += $"{tv.ShortDescr} Телевизор  {tv.model.ToString()} стоимостью {tv.price.ToString()}  \n";
                    }
            }
            db.Carts.RemoveRange(C);
            db.SaveChanges();
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync($"{u.Email}", "Заказ принят успешно", $"{mes}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddToCart(int I, string U) // Костыльное добавление
        {
            if (User.Identity.IsAuthenticated)
            {
                Cart c1 = new Cart();
                c1.idTV = I;
                User u1 = db.Users.FirstOrDefault(u => u.Email == U);
                c1.idUser = u1.Id;
                c1.TV = db.TVs.FirstOrDefault(t => t.id == I);
                db.Carts.Add(c1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Privacy()
        {
            if (User.Identity.IsAuthenticated) // Хуйня для проверки авторизироован, или нет
            {

                var CTs = db.Carts.ToList();
                var Tvs = db.TVs.ToList();
                User u = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
                ViewData["UID"] = u.Id;
                var cm = new CM { Cts = CTs, TVs = Tvs };
                return View(cm);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
