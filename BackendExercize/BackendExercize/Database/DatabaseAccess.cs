using BackendExercize.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Database
{
    public class DatabaseAccess
    {
        public static string DefaultConnection = "Server=localhost; Port=5432; User Id=postgres; Password=password; Database=twitter;";

        #region Sigleton

        public static DatabaseAccess Instance { get; }

        private DatabaseAccess()
        {
        }

        static DatabaseAccess()
        {
            Instance = new();
        }

        #endregion

        public void ExecuteNonQuery(string query)
        {
            var con = new NpgsqlConnection(DefaultConnection);
            con.Open();

            var cmd = new NpgsqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        /// <summary>
        /// Executes query and return the result and the connection.
        /// It's important to return the connection because if I close the
        /// connection before the reading is done it will throw an exception.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public (NpgsqlDataReader reader, NpgsqlConnection connection) ExecuteQuery(string query)
        {

            var con = new NpgsqlConnection(DefaultConnection);
            con.Open();

            var cmd = new NpgsqlCommand(query, con);
            var res = cmd.ExecuteReader();

            return (res, con);
        }
    }
}
