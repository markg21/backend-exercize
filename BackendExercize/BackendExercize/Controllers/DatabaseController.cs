using BackendExercize.Database;
using BackendExercize.Models;
using BackendExercize.Queries;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : Controller
    {
        public static DatabaseAccess Database = DatabaseAccess.Instance;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        [ActionName("tweets")]
        public List<Tweet> GetTweets()
        {
            var (res, connection) = Database.ExecuteQuery(SqlQueries.Tweets);

            var tweets = new List<Tweet>();

            while (res.Read())
            {
                tweets.Add(res.ParseTweet());
            }

            connection.Close();

            return tweets;
        }

        [HttpGet("[action]")]
        [ActionName("retweets")]
        public List<Retweet> GetRetweets()
        {
            var (res, connection) = Database.ExecuteQuery(SqlQueries.Retweets);

            var retweets = new List<Retweet>();

            while (res.Read())
            {
                retweets.Add(res.ParseRetweet());
            }

            connection.Close();

            return retweets;
        }

        [HttpGet("[action]/{id}")]
        [ActionName("tweet")]
        public List<Tweet> GetTweetById(long id)
        {
            var (res, connection) = Database.ExecuteQuery(SqlQueries.TweetById(id));

            var tweets = new List<Tweet>();

            while (res.Read())
            {
                tweets.Add(res.ParseTweet());
            }

            connection.Close();

            return tweets;
        }

        [HttpPost("[action]/{id}/like")]
        [ActionName("tweet")]
        public void LikeTweet(long id, [FromBody] string username)
        {
            Database.ExecuteNonQuery(SqlQueries.LikeTweet(username, id));
        }

        [HttpPost("[action]/{id}/retweet")]
        [ActionName("tweet")]
        public void Retweet(long id, [FromBody] string username)
        {
            Database.ExecuteNonQuery(SqlQueries.PostRetweet(username, id));
        }

        [HttpPost("[action]")]
        [ActionName("tweet")]
        public void PostTweet([FromBody] TweetPost tweet)
        {
            Database.ExecuteNonQuery(SqlQueries.InsertTweet(tweet.Content, tweet.Username));
        }
    }
}
