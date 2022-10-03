using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public IActionResult Registrazione()
        {
            return View();
        }

        

        public IActionResult Salva(Dictionary<string, string> parametri)
        {
            Utente u = new Utente();

            u.FromDictionary(parametri);

            if (DAOUtente.GetInstance().Inserisci(u))
                return RedirectToAction("Successo","Home");
            else
                return Content("Registrazione fallita");
        }

        public IActionResult Valida(Dictionary<string, string> parametri)
        {
            if (DAOUtente.GetInstance().Valida(parametri["username"], parametri["psw"]))
            {
                // se arrivo qui significa che l'utente esiste
                il.LogInformation($"UTENTE LOGGATO: {parametri["username"]}");

                utenteLoggato = DAOUtente.GetInstance().Cerca(parametri["username"]);
                if(utenteLoggato.Ruolo == "admin")
                {
                    return RedirectToAction("ElencoAdmin", "Login");
                }
                else
                {
                    return RedirectToAction("UserAccount", "Login");
                }
                
            }
            else
                return Redirect("Index");
        }

        public IActionResult Admin()
        {
            chiamata++;

            il.LogInformation($"Tentativo Numero: {chiamata}");
            return View(chiamata);
        }

        public IActionResult UserAccount(int id)
        {
            chiamata++;

            return View(DAOInPrestito.GetInstance().ReadId(utenteLoggato.Id));
        }

        public IActionResult Logout()
        {
            chiamata = -1;
            il.LogInformation($"LOGOUT: {utenteLoggato.Username}");
            utenteLoggato = null;

            return Redirect("Index");
        }

        public IActionResult ElencoAdmin()
        {
            return View(DAOLibro.GetInstance().Read());
        }

        public IActionResult ElencoPrestiti()
        {
            return View(DAOInPrestito.GetInstance().Read());
        }

        public IActionResult FormModificaAdmin(int id)
        {
            Libro l = (Libro)DAOLibro.GetInstance().Find(id);

            return View(l);
        }

        public IActionResult ModificaLibro(Dictionary<string, string> parametri)
        {
            Libro l = new Libro();
            l.FromDictionary(parametri);

            if (DAOLibro.GetInstance().Update(l))
                return Redirect("/Login/ElencoAdmin");
            else
                return Content("Modifica Fallita");
        }

        public IActionResult Elimina(int id)
        {
            if (DAOLibro.GetInstance().Delete(id))
                return Redirect("/Login/ElencoAdmin");
            else
                return Content("Eliminazione Fallita");
        }

        public ActionResult AggiornaDisponibilita(int id)
        {
            if (DAOLibro.GetInstance().UpdatePrenota2(id))
            {
                return Redirect("/Login/UserAccount");
            }
            else
                return Content("Aggiornamento Fallito");
        }


        public IActionResult EliminaPrenotazione(int id)
        {
            if (DAOInPrestito.GetInstance().Delete(id))
            {
                return Redirect("/Login/UserAccount");
            }
                
            else
                return Content("Eliminazione Fallita");
        }

        public IActionResult FormInserimentoAdmin()
        {
            return View();
        }

        public IActionResult NuovoLibro(Dictionary<string,string> parametri)
        {
            Libro l = new Libro();
            l.FromDictionary(parametri);

            if (DAOLibro.GetInstance().Insert(l))
                return Redirect("/Login/ElencoAdmin");
            else
                return Content("Inserimento Fallito");
        }
    }
}

