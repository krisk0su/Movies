using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services.DataServices.Contracts;
using MoviesApp.Web.Models;

namespace MoviesApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMoviesService _movieService;

        public HomeController(IMoviesService service)
        {
            this._movieService = service;
        }
        public IActionResult Index()
        {
            var vm = this._movieService.IndexMovies();
            return View(vm);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
