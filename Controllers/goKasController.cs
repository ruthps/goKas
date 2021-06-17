using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goKas.Infrastructure;
using goKas.Models;
using Microsoft.EntityFrameworkCore;

namespace goKas.Controllers
{
    public class goKasController : Controller
    {
        private readonly KasContext context;
        public goKasController(KasContext context)
        {
            this.context = context;
        }
        
        public async Task<ActionResult> Index()
        {
            IQueryable<finance> items = (IQueryable<finance>) (from i in context.goKas orderby i.Id select i);
            List<finance> gokas = await items.ToListAsync();
            return View(gokas);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<AcceptedResult> Create(finance item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Finance List has been added";
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
