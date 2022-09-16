using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class DAOScrittoDa : IDAO
    {
        private Database db;

        private static DAOScrittoDa instance = null;

        public DAOScrittoDa()
        {
            db = new Database("Biblioteca_Aziendale");
        }

        public static DAOScrittoDa GetInstance()
        {
            return instance == null ? new DAOScrittoDa() : instance;
        }

        // Inizio CRUD
        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM ScrittoDa");

            foreach (Dictionary<string, string> riga in tabella)
            {
                ScrittoDa scrittore = new ScrittoDa();
                scrittore.FromDictionary(riga);

                ris.Add(scrittore);
            }

            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM ScrittoDa WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            ScrittoDa scrittore = (ScrittoDa)e;

            string query = $"UPDATE ScrittoDa SET " +
                           $"idAutore = {scrittore.IdAutore.Id}," +
                           $"idLibro = {scrittore.IdLibro.Id}," +
                           $"WHERE id = {scrittore.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            ScrittoDa scrittore = (ScrittoDa)e;

            string query = $"INSERT INTO ScrittoDa " +
                           $"(idAutore,idLibro) " +
                           $"VALUES " +
                           $"({scrittore.IdAutore.Id},{scrittore.IdLibro.Id})";

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