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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public object Get()
        {
            var con = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=password; Database=twitter;");
            con.Open();

            var cmd = new NpgsqlCommand(SqlQueries.Tweet, con);
            var res = cmd.ExecuteReader();

            res.Read();

            return res.ParseTweet();
        }

        [HttpGet("[action]")]
        [ActionName("tweets")]
        public List<Tweet> GetTweets([FromBody] TweetPost tweet)
        {
            var con = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=password; Database=twitter;");
            con.Open();

            var cmd = new NpgsqlCommand(SqlQueries.Tweet, con);
            var res = cmd.ExecuteReader();

            var tweets = new List<Tweet>();

            while (res.Read())
            {
                tweets.Add(res.ParseTweet());
            }

            return tweets;
        }

        [HttpGet("[action]/{id}")]
        [ActionName("tweet")]
        public List<Tweet> GetTweetById(long id)
        {
            var con = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=password; Database=twitter;");
            con.Open();

            var cmd = new NpgsqlCommand(SqlQueries.TweetById(id), con);
            var res = cmd.ExecuteReader();

            var tweets = new List<Tweet>();

            while (res.Read())
            {
                tweets.Add(res.ParseTweet());
            }

            return tweets;
        }

        [HttpPost("[action]")]
        [ActionName("tweet")]
        public void PostTweet([FromBody] TweetPost tweet)
        {
            var con = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=password; Database=twitter;");
            con.Open();

            var cmd = new NpgsqlCommand(SqlQueries.InsertTweet(tweet.Content, tweet.Username), con);
            cmd.ExecuteNonQuery();
        }
    }
}
