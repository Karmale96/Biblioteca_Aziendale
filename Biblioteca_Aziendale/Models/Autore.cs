using System;
using Utility;
namespace Biblioteca_Aziendale.Models
{
    public class Autore : Entity
    {
        public Autore() { }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateOnly Dob { get; set; }
    }
}

