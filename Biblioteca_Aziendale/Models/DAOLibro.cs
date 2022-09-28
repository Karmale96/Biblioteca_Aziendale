using System;
using Utility;
namespace Biblioteca_Aziendale.Models
{
    public class DAOLibro : IDAO
    {
        private Database db;

        private static DAOLibro instance = null;

        public DAOLibro()
        {
            db = new Database("Biblioteca_Aziendale");
        }

        public static DAOLibro GetInstance()
        {
            return instance == null ? new DAOLibro() : instance;
        }

        // Inizio CRUD
        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM Libri");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Libro libro = new Libro();
                libro.FromDictionary(riga);

                ris.Add(libro);
            }

            return ris;
        }

        public List<Entity> ReadDistinct()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT titolo, descrizione, copertina, genere FROM Libri GROUP BY titolo, descrizione, copertina, genere;\n");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Libro libro = new Libro();
                libro.FromDictionary(riga);

                ris.Add(libro);
            }

            return ris;
        }

        public List<Entity> ReadLike(string valore)
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read($"SELECT * FROM Libri WHERE titolo LIKE '%{valore}%' ");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Libro l = new Libro();
                l.FromDictionary(riga);


                ris.Add(l);
            }
            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM Libri WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            Libro libro = (Libro)e;

            string query = $"UPDATE Libri SET " +
                           $"titolo = '{libro.Titolo}'," +
                           $"descrizione = '{libro.Descrizione}'," +
                           $"copertina = '{libro.Copertina}'," +
                           $"npagine = {libro.NPagine}," +
                           $"genere = '{libro.Genere}'," +
                           $"scaffale = '{libro.Scaffale}'," +
                           $"annoPubblicazione = {libro.AnnoPubblicazione}," +
                           $"casaEditrice = '{libro.CasaEditrice}' " +
                           $"WHERE id = {libro.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            Libro libro = (Libro)e;

            string query = $"INSERT INTO Libri " +
                           $"(titolo, descrizione, copertina, nPagine, genere, scaffale, annoPubblicazione, casaEditrice) " +
                           $"VALUES " +
                           $"('{libro.Titolo}','{libro.Descrizione}','{libro.Copertina}',{libro.NPagine},'{libro.Genere}','{libro.Scaffale}',{libro.AnnoPubblicazione},'{libro.CasaEditrice}')";

            return db.Send(query);
        }

        public Entity Find(int id)
        {
            foreach (Entity e in Read())
                if (e.Id == id)
                    return e;

            return null;

        }
    }
}

