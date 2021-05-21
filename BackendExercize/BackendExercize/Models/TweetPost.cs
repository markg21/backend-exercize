using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Models
{
    [BindProperties]
    public class TweetPost
    {
        public string Content { get; set; }
        public string Username { get; set; }
    }
}
