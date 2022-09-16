using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class DAOInPrestito : IDAO
    {
        private Database db;

        private static DAOInPrestito instance = null;

        public DAOInPrestito()
        {
            db = new Database("Biblioteca_Aziendale");
        }

        public static DAOInPrestito GetInstance()
        {
            return instance == null ? new DAOInPrestito() : instance;
        }

        // Inizio CRUD
        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM InPrestito");

            foreach (Dictionary<string, string> riga in tabella)
            {
                InPrestito prestito = new InPrestito();
                prestito.FromDictionary(riga);

                ris.Add(prestito);
            }

            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM InPrestito WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            InPrestito prestito = (InPrestito)e;

            string query = $"UPDATE InPrestito SET " +
                           $"dataInizio = '{prestito.DataInizio}'," +
                           $"dataFine = '{prestito.DataFine}'," +
                           $"idUtente = {prestito.IdUtente.Id}," +
                           $"idLibro = {prestito.IdLibro.Id} " +
                           $"WHERE id = {prestito.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            InPrestito prestito = (InPrestito)e;

            string query = $"INSERT INTO InPrestito " +
                           $"(dataInizio,dataFine,idUtente,idLibro) " +
                           $"VALUES " +
                           $"('{prestito.DataInizio}','{prestito.DataFine}',{prestito.IdUtente.Id},{prestito.IdLibro.Id}')";

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

