using BackendExercize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Queries
{
    public static class SqlQueries
    {
        public static string Tweets = "select twitter.tweets.text, (select twitter.usernames.username from twitter.usernames where twitter.usernames.id = twitter.tweets.userid), " +
            "twitter.tweets.timestamp, count(twitter.retweets.*) as retweetcount, count(twitter.likes.*) as likecount " +
            "from twitter.tweets " +
            "left join twitter.retweets on twitter.retweets.postid = twitter.tweets.id " +
            "left join twitter.likes on twitter.likes.postid = twitter.tweets.id " +
            "group by twitter.tweets.id;";

        public static string Retweets = "select twitter.tweets.text, twitter.retweets.postid, " +
            "(select twitter.usernames.username from twitter.usernames where twitter.usernames.id = twitter.retweets.userid) as retweetuser, " +
            "(select twitter.usernames.username from twitter.usernames where twitter.usernames.id = twitter.tweets.userid) as tweetuser, " +
            "twitter.retweets.timestamp from twitter.retweets " +
            "left join twitter.tweets on twitter.tweets.id = twitter.retweets.postid;";

        public static string TweetById(long id)
        {
            return Tweets[0..^1] + " having tweets.id = " + id + ";";
        }

        public static string InsertTweet(string text, string username)
        {
            return "insert into twitter.tweets values(default, '" + text + "', (" + IdOfUsername(username)[0..^1] + "), '" + Utils.DateTimeNowInFormat() + "');";
        }

        public static string UsernameById(long id)
        {
            return "select twitter.usernames.username from twitter.usernames where twitter.usernames.id = " + id + ";";
        }

        public static string UsernameByQuery(string query)
        {
            return "select twitter.usernames.username from twitter.usernames where twitter.usernames.id = " + query + ";";
        }

        public static string IdOfUsername(string username)
        {
            return "select twitter.usernames.id from twitter.usernames where twitter.usernames.username = '" + username + "';";
        }

        public static string LikeTweet(string username, long postid)
        {
            return "insert into twitter.likes values((" + IdOfUsername(username)[0..^1] + "), " + postid + ", '" + Utils.DateTimeNowInFormat() + "'); ";
        }

        public static string PostRetweet(string username, long postid)
        {
            return "insert into twitter.retweets values((" + IdOfUsername(username)[0..^1] + "), " + postid + ", '" + Utils.DateTimeNowInFormat() + "'); ";
        }
    }
}
