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
        #region Sigleton

        public static DatabaseAccess Instance { get; }

        private DatabaseAccess()
        {
            database = new();
        }

        static DatabaseAccess()
        {
            Instance = new();
        }

        #endregion

        private NpgsqlConnection database;

        public List<Tweet> ReadTweets()
        {
            var tweets = new List<Tweet>();

            return tweets;
        }
    }
}
