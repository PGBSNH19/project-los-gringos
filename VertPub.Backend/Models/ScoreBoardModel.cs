using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VertPub.Backend.Models
{
    public class ScoreBoardModel
    {
        [Key]
        public Guid id { get; set; }
        public GameLinksModel game { get; set; }
        public int points { get; set; }
        public string player { get; set; }
    }
}
