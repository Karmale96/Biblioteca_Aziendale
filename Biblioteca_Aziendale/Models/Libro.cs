using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class Libro : Entity
    {
        public Libro() { }

        public string Titolo { get; set; }
        public string Isbn { get; set; }
        public string Descrizione { get; set; }
        public string Copertina { get; set; }
        public int NPagine { get; set; }
        public string Genere { get; set; }
        public string Scaffale { get; set; }
        public int AnnoPubblicazione { get; set; }
        public string CasaEditrice { get; set; }
    }
}

