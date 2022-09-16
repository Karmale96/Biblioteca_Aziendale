using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class DAOUtente : IDAO
    {
        private Database db;

        private static DAOUtente instance = null;

        public DAOUtente()
        {
            db = new Database("Biblioteca_Aziendale");
        }

        public static DAOUtente GetInstance()
        {
            return instance == null ? new DAOUtente() : instance;
        }

        // Inizio CRUD
        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM Utenti");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Utente utente = new Utente();
                utente.FromDictionary(riga);

                ris.Add(utente);
            }

            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM Utenti WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            Utente utente = (Utente)e;

            string query = $"UPDATE Utenti SET " +
                           $"nome = '{utente.Nome}'," +
                           $"cognome = '{utente.Cognome}'," +
                           $"dob = '{utente.Dob}'," +
                           $"indirizzo = {utente.Indirizzo} " +
                           $"userAdmin = '{utente.UserAdmin}' " +
                           $"username = '{utente.Username}' " +
                           $"psw = {utente.Psw} " +
                           $"WHERE id = {utente.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            Utente utente = (Utente)e;

            string query = $"INSERT INTO Utenti " +
                           $"(nome,cognome,dob,indirizzo,userAdmin,username,psw) " +
                           $"VALUES " +
                           $"('{utente.Nome}','{utente.Cognome}','{utente.Dob}','{utente.Indirizzo}','{utente.UserAdmin}','{utente.Username}','{utente.Psw}')";

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
