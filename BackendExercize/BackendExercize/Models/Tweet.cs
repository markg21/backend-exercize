using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Models
{
    public class Tweet
    {
        public string Text { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }
        public long LikeCount { get; set; }
        public long RetweetCount { get; set; }

        public Tweet()
        {
            Text = "";
            Username = "";
            Timestamp = DateTime.Now;
            LikeCount = 0;
            RetweetCount = 0;
        }
    }
}
