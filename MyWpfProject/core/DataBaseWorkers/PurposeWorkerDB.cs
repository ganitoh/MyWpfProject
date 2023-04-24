using MyWpfProject.core.abstraction;
using MyWpfProject.core.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyWpfProject.core.DataBaseWorkers
{
    internal class PurposeWorkerDB : ISelectSqlRequest<List<Purpose>>,IIinsertSqlRequest<Purpose>,IUpdateSQlRequest<Purpose>,IDeleteSqlRequest<int>
    {
        private IDataBase dataBase;
        private int userId;

        public int Id { get; set ; }

        public PurposeWorkerDB(int userId)
        {
            dataBase = new DB();
            this.userId = userId;
        }
        public PurposeWorkerDB()
        {
            dataBase = new DB();
        }


        public List<Purpose> SelectRequest()
        {
            dataBase.OpenConnection();

            DataTable purposesTable = new DataTable();
            SqlDataAdapter selectAdapter = new SqlDataAdapter($"SELECT * FROM Purposes WHERE userId={userId}",dataBase.Connection);
            selectAdapter.Fill(purposesTable);

            if (purposesTable.Rows.Count > 0)
                return GetAllPurposes();
            else 
                return null;
        }
        private List<Purpose> GetAllPurposes()
        {
            List<Purpose> purposes = new List<Purpose>();
            SqlDataReader reader = null;

            try
            {
                ReaderWorker(purposes,reader);
                return purposes;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        private void ReaderWorker(List<Purpose> purposes,SqlDataReader reader)
        {
            SqlCommand selectCommand = new SqlCommand($"SELECT * FROM Purposes WHERE userId={userId}", dataBase.Connection);
            reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Purpose purpose = new Purpose();

                purpose.ID = reader.GetInt32(0);
                purpose.UserId = reader.GetInt32(1);
                purpose.Title = reader.GetString(2);
                purpose.Discription = reader.GetString(3);
                purpose.IsMainPurposes = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                    purpose.FinalAmountMoney = reader.GetInt32(5);
                if (!reader.IsDBNull(6))
                    purpose.CollectedAmountMoney = reader.GetInt32(6);
                

                purposes.Add(purpose);
            }

        }
        public bool InsertRequest(Purpose purpose)
        {
            dataBase.OpenConnection();

            SqlCommand insertCommand = new SqlCommand(
                $"INSERT INTO Purposes (userId,title,_description,finalAmountMoney,collectedAmountMoney,isMainPurposes)" +
                $" VALUES (N'{purpose.UserId}',N'{purpose.Title}',N'{purpose.Discription}',N'{purpose.FinalAmountMoney}',N'{purpose.CollectedAmountMoney}' ,N'{purpose.IsMainPurposes}')", dataBase.Connection);

            if (insertCommand.ExecuteNonQuery() > 0)
            {
                dataBase.CloseConnection();
                return true;
            }
            else
            {
                dataBase.CloseConnection();
                return false;
            }
            
        }
        public bool UpdateRequest(Purpose purpose)
        {
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand($"update  Purposes set " +
                $"title=N'{purpose.Title}',_description=N'{purpose.Discription}',finalAmountMoney={purpose.FinalAmountMoney},collectedAmountMoney={purpose.CollectedAmountMoney},isMainPurposes=N'{purpose.IsMainPurposes}' where id={purpose.ID}",dataBase.Connection);

            if (updateCommand.ExecuteNonQuery() > 0)
            {
                dataBase.CloseConnection();
                return true;
            }
            else
            {
                dataBase.CloseConnection();
                return false;
            }
        }

        public bool DeleteRequest(int id)
        {
            dataBase.OpenConnection();

            SqlCommand deleteCommand = new SqlCommand($"delete from Purposes where id={id}", dataBase.Connection);
            if (deleteCommand.ExecuteNonQuery() > 0)
            {
                dataBase.CloseConnection();
                return true;
            }
            else
            {
                dataBase.CloseConnection();
                return false;
            }
        }
    }
}
