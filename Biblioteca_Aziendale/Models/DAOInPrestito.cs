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
            List<Entity> ris2 = new List<Entity>();
            List<Dictionary<string, string>> tabella1 = db.Read("SELECT dataInizio, dataFine, idUtente,idLibro, nome, cognome, titolo FROM InPrestito inner join Utenti on inPrestito.idUtente = utenti.id inner join Libri on Libri.id = inPrestito.idLibro");
           /* List<Dictionary<string, string>> tabella2 = db.Read("select  from inPrestito inner join Utenti on inPrestito.idUtente = utenti.id inner join Libri on Libri.id = inPrestito.idLibro");*/

            foreach (Dictionary<string, string> riga in tabella1)
            {
                InPrestito prestito = new InPrestito();
                prestito.FromDictionary(riga);

                ris.Add(prestito);
            }

           /* foreach (Dictionary<string, string> riga in tabella2)
            {
                InPrestito prestito2 = new InPrestito();
                prestito2.FromDictionary(riga);

                ris.Add(prestito2);
            }
           */

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
                           $"idUtente = {prestito.IdUtente}," +
                           $"idLibro = {prestito.IdLibro} " +
                           $"WHERE id = {prestito.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            InPrestito prestito = (InPrestito)e;

            string query = $"INSERT INTO InPrestito " +
                           $"(dataInizio,dataFine,idUtente,idLibro) " +
                           $"VALUES " +
                           $"('{prestito.DataInizio}','{prestito.DataFine}',{prestito.IdUtente},{prestito.IdLibro}')";

            return db.Send(query);
        }

        public bool InsertOrdine(Entity e, int id)
        {
            InPrestito prestito = (InPrestito)e;

            string query= $"INSERT INTO inPrestito " +
                          $"(dataInizio,dataFine,idUtente,idLibro) " +
                          $"VALUES " +
                          $"('{prestito.DataInizio.ToString("yyyy-MM-dd")}','{prestito.DataFine.ToString("yyyy-MM-dd")}',{id},{prestito.IdLibro})";
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

