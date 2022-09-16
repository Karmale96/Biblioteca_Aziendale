using System;
using Utility;
namespace Biblioteca_Aziendale.Models
{
    public class Utente : Entity
    {
        public Utente() { }

        public Utente(int id, string nome, string cognome, DateOnly dob, string indirizzo, string userAdmin, string username, string psw): base(id)
        {
            Nome = nome;
            Cognome = cognome;
            Dob = dob;
            Indirizzo = indirizzo;
            UserAdmin = userAdmin;
            Username = username;
            Psw = psw;
        }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateOnly Dob { get; set; }
        public string Indirizzo { get; set; }
        public string UserAdmin { get; set; }
        public string Username { get; set; }
        public string Psw { get; set; }
    }
}

