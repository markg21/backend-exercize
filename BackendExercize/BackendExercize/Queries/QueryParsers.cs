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
                Timestamp = DateTime.ParseExact(tweet[2].ToString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                RetweetCount = (long)tweet[3],
                LikeCount = (long)tweet[4]
            };
        }

        public static Retweet ParseRetweet(this NpgsqlDataReader retweet)
        {
            return new Retweet
            {
                Content = retweet[0].ToString().Trim(),
                TweetId = (int)retweet[1],
                RetweetUser = retweet[2].ToString().Trim(),
                TweetUser = retweet[3].ToString().Trim(),
                Timestamp = DateTime.ParseExact(retweet[4].ToString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            };
        }
    }
}
