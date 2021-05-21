using BackendExercize.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Queries
{
    public static class QueryParsers
    {
        public static Tweet ParseTweet(this NpgsqlDataReader tweet)
        {
            return new Tweet
            {
                Text = tweet[0].ToString().Trim(),
                Username = tweet[1].ToString().Trim(),
                Timestamp = DateTime.ParseExact(tweet[2].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                RetweetCount = (long)tweet[3],
                LikeCount = (long)tweet[4]
            };
        }
    }
}
