using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class Libro : Entity
    {
        public Libro() { }

        public Libro(int id, string titolo, string isbn, string descrizione,
            string copertina, int nPagine, string genere, string scaffale, int annoPubblicazione) : base(id)
        {
            Titolo = titolo;
            Isbn = isbn;
            Descrizione = descrizione;
            Copertina = copertina;
            NPagine = nPagine;
            Genere = genere;
            Scaffale = scaffale;
            AnnoPubblicazione = annoPubblicazione;
        }

        public string Titolo { get; set; }
        public string Isbn { get; set; }
        public string Descrizione { get; set; }
        public string Copertina { get; set; }
        public int NPagine { get; set; }
        public string Genere { get; set; }
        public string Scaffale { get; set; }
        public int AnnoPubblicazione { get; set; }
    }
}

