using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_Aziendale.Models;
using Microsoft.AspNetCore.Mvc;
using Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca_Aziendale.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Entity> entities = DAOLibro.GetInstance().ReadDistinct();
            return View(entities);
        }

        public IActionResult ElencoLike(string valore)
        {
            return View(DAOLibro.GetInstance().ReadLike(valore));
        }
    }
}

