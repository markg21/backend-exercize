using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Models
{
    public class Retweet
    {
        public string Content { get; set; }
        public string TweetUser { get; set; }
        public string RetweetUser { get; set; }
        public DateTime Timestamp { get; set; }

        public Retweet()
        {
            Content = "";
            TweetUser = "";
            RetweetUser = "";
            Timestamp = new DateTime();
        }
    }
}
