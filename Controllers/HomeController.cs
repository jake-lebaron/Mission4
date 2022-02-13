using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5Real.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5Real.Controllers
{
    public class HomeController : Controller
    {
        private MovieInputContext daContext { get; set; }

        //Constructor
        public HomeController(MovieInputContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieInput ()
        {
            ViewBag.Categories = daContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieInput(MovieResponse asdf)
        {
            if (ModelState.IsValid)
            {
                daContext.Responses.Add(asdf);
                daContext.SaveChanges();

                return View("Index", asdf);
            }

            else //if invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View(asdf);
            }
        }

        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var applications = daContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var input = daContext.Responses.Single(x => x.MovieId == movieid);

            return View("MovieInput", input);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var input = daContext.Responses.Single(x => x.MovieId == movieid);

            return View(input);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse asdf)
        {
            daContext.Responses.Remove(asdf);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
