using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class DAOUtente
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
        public Utente Cerca(int id)  // Cerca per id
        {
            string query = $"SELECT * FROM Utenti WHERE username = {id}";
            //Inutile fare una lista di dictionary quando cerchiamo l'id perché è univoco
            Dictionary<string, string> riga = db.ReadOne(query);

            Utente user = new Utente();
            user.FromDictionary(riga);

            return user;
        }

        public Utente Cerca(string username)  // cerca per username
        {
            string query = $"SELECT * FROM Utenti WHERE username = '{username}'";
            //Inutile fare una lista di dictionary quando cerchiamo l'id perché è univoco
            Dictionary<string, string> riga = db.ReadOne(query);

            Utente user = new Utente();
            user.FromDictionary(riga);

            return user;
        }

        public bool Valida(string username, string psw)
        {
            string query = $"SELECT * FROM Utenti WHERE username = '{username}' AND psw = '{psw}';";

            Dictionary<string, string> riga = db.ReadOne(query);

            if (riga != null)
                return true;
            else
                return false;
        }

        public bool Inserisci(Utente u)
        {
            return db.Send($"INSERT INTO Utenti (nome,cognome,dob,indirizzo,ruolo,username, psw) VALUES ('{u.Nome}','{u.Cognome}','{u.Dob.ToString("yyyy-MM-dd")}','{u.Indirizzo}','{u.Ruolo}','{u.Username}','{u.Psw}')");
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM Utenti WHERE id = {id}");
        }

        public bool Modifica(Utente u)
        {
            //Prendo da Database l'utente che voglio modificare
            Utente un = Cerca(u.Id);

            //Controllo che la password vecchia sia diversa da quella nuova
            if (un.Psw != u.Psw || un.Username != u.Username)
            {
                //Controllo se il nuovo USERNAME già esiste, se non esiste permetto la modifica
                if (un.Username != u.Username)
                {
                    if (Cerca(u.Username) == null)
                    {
                        return db.Send(
                                            $"UPDATE Utenti SET " +
                                            $"username = '{u.Username}', " +
                                            $"WHERE id = {u.Id}"
                                        );
                    }
                }

                if (un.Psw != u.Psw)
                {
                    //Se lo USERNAME nuovo combacia con quello vecchio, cambio solo la password
                    return db.Send(
                                        $"UPDATE Utenti SET " +
                                        $"psw = '{u.Psw}' " +
                                        $"WHERE id = {u.Id}"
                                    );
                }
                return false;
            }
            else
                return false;
        }
    }
}
