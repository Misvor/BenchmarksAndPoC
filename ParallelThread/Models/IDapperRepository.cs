using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ParallelThread.Models
{
    public interface IDapperRepository
    {
        int Create(DapperStoreClass data);
        void Delete(int id);
        DapperStoreClass? Get(int id);
        List<DapperStoreClass> GetAll();
        void Update(DapperStoreClass data);
    }
    public class DapperRepository : IDapperRepository
    {
        public DapperRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private string connectionString = null;
        public int Create(DapperStoreClass data)
        {
            using IDbConnection db = new Npgsql.NpgsqlConnection(connectionString);
            var sqlQuery =
                "INSERT INTO DapperStore (\"Name\", \"CreateTime\") VALUES(@Name, @CreateTime) RETURNING id";
            int? dataId = db.Query<int>(sqlQuery, data).FirstOrDefault();
            data.Id = dataId.Value;
            return dataId.Value;
        }

        public void Delete(int id)
        {
            using IDbConnection db = new Npgsql.NpgsqlConnection(connectionString);
            var sqlQuery = "DELETE FROM DapperStore WHERE id = @id";
            db.Execute(sqlQuery,  new {id});
            //db.Execute(sqlQuery, new { id });
        }

        public DapperStoreClass? Get(int id)
        {
            using IDbConnection db = new Npgsql.NpgsqlConnection(connectionString);
            return db.Query<DapperStoreClass>("SELECT * FROM DapperStore WHERE id = @id", id).FirstOrDefault();
        }

        public List<DapperStoreClass> GetAll()
        {
            using IDbConnection db = new Npgsql.NpgsqlConnection(connectionString);
            return db.Query<DapperStoreClass>("SELECT * FROM DapperStore").ToList();
        }

        public void Update(DapperStoreClass data)
        {
            using IDbConnection db = new Npgsql.NpgsqlConnection(connectionString);
            var sqlQuery = "UPDATE DapperStore SET \"Name\" = @Name, \"CreateTime\" = @CreateTime WHERE id = @id";
            db.Execute(sqlQuery, data);
        }
    }
}
