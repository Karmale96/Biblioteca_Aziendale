using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class DAOAutore
    {
        private Database db;

        private static DAOAutore instance = null;

        public DAOAutore()
        {
            db = new Database("Biblioteca_Aziendale");
        }

        public static DAOAutore GetInstance()
        {
            return instance == null ? new DAOAutore() : instance;
        }

        // Inizio CRUD
        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM Autori");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Autore autore = new Autore();
                autore.FromDictionary(riga);

                ris.Add(autore);
            }

            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM Autori WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            Autore autore = (Autore)e;

            string query = $"UPDATE Autori SET " +
                           $"nome = '{autore.Nome}'," +
                           $"cognome = '{autore.Cognome}'," +
                           $"dob = '{autore.Dob}'," +
                           $"WHERE id = {autore.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            Autore autore = (Autore)e;

            string query = $"INSERT INTO Autori " +
                           $"(nome, cognome, dob) " +
                           $"VALUES " +
                           $"('{autore.Nome}','{autore.Cognome}','{autore.Dob}')";

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

