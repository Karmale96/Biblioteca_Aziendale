using System;
using Utility;
namespace Biblioteca_Aziendale.Models
{
    public class Autore : Entity
    {
        public Autore() { }

        public Autore(int id, string nome, string cognome, DateOnly dob) : base(id)
        {
            Nome = nome;
            Cognome = cognome;
            Dob = dob;
        }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateOnly Dob { get; set; }
    }
}

