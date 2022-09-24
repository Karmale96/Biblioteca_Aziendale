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
    public class LoginController : Controller
    {
        private ILogger<LoginController> il;

        public static Utente utenteLoggato = null;

        private static int chiamata = -1; // da vedere se lasciarla. Altrimenti se non serve a nulla la togliamo

        public LoginController(ILogger<LoginController> l)
        {
            il = l;
        }

        public IActionResult Index()
        {
            chiamata++;

            il.LogInformation($"Tentativo Numero: {chiamata}");
            return View(chiamata);
        }

        public IActionResult Valida(Dictionary<string, string> parametri)
        {
            if (DAOUtente.GetInstance().Valida(parametri["username"], parametri["psw"]))
            {
                // se arrivo qui significa che l'utente esiste
                il.LogInformation($"UTENTE LOGGATO: {parametri["username"]}");

                utenteLoggato = DAOUtente.GetInstance().Cerca(parametri["username"]);

                return RedirectToAction("Index", "Home");
            }
            else
                return Redirect("Index");
        }
    }
}

