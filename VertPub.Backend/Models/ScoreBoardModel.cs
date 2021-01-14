using System;
using System.ComponentModel.DataAnnotations;

namespace VertPub.Backend.Models
{
    public class ScoreBoardModel
    {
        [Key]
        public Guid id { get; set; }
        public Guid gameID { get; set; }
        public int points { get; set; }
        public string player { get; set; }
    }
}
