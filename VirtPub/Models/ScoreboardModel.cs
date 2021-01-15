using System;

namespace VirtPub.Models
{
    public class ScoreboardModel
    {
        
        public Guid gameid { get; set; }
        public int points { get; set; }
        public string player { get; set; }
    }
}
