using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using StructureMap;

namespace Sample.DN46.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContainer _container;
        public IServiceProvider ServiceProvider { get; set; }

        public HomeController(IServiceProvider serviceProvider,IContainer container)
        {
            _container = container;
            ServiceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
