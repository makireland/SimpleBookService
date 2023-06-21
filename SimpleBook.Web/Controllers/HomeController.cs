using Microsoft.AspNetCore.Mvc;
using SimpleBook.Web.Models;
using System.Diagnostics;

namespace SimpleBook.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}