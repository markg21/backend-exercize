using BackendExercize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Queries
{
    public static class SqlQueries
    {
        public static string Tweet = "select twitter.tweets.text, (select twitter.usernames.username from twitter.usernames where twitter.usernames.id = twitter.tweets.userid), " +
            "twitter.tweets.timestamp, count(twitter.retweets.*) as retweetcount, count(twitter.likes.*) as likecount " +
            "from twitter.tweets " +
            "left join twitter.retweets on twitter.retweets.postid = twitter.tweets.id " +
            "left join twitter.likes on twitter.likes.postid = twitter.tweets.id " +
            "group by twitter.tweets.id;";

        public static string TweetById(long id)
        {
            return Tweet[0..^1] + " having tweets.id = " + id + ";";
        }

        public static string InsertTweet(string text, string username)
        {
            return "insert into twitter.tweets values(default, '" + text + "', (" + IdOfUsername(username)[0..^1] + "), '" + DateTime.Now + "');";
        }

        public static string UsernameById(long id)
        {
            return "select twitter.usernames.username from twitter.usernames where twitter.usernames.id = " + id + ";";
        }

        public static string IdOfUsername(string username)
        {
            return "select twitter.usernames.id from twitter.usernames where twitter.usernames.username = '" + username + "';";
        }
    }
}
