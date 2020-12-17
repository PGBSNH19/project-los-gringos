using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VertPub.Backend.Models
{
    public class ScoreBoard
    {
        public GameLinksModel game { get; set; }
        public Guid id { get; set; }
        public int points { get; set; }
        public string player { get; set; }
    }
}
