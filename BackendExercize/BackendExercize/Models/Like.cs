using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendExercize.Models
{
    public class Like
    {
        public uint PostId { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }

        public Like()
        {
            PostId = 0;
            Username = "";
            Timestamp = new DateTime();
        }
    }
}
