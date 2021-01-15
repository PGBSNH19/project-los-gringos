using System;
using System.ComponentModel.DataAnnotations;

namespace VertPub.Backend.Models
{
    public class GameLinksModel
    {
        [Key]
        public Guid id { get; set; }
        public string link { get; set; }
        public string name { get; set; }
        public int maxPlayers { get; set; }
        public int minPlayers { get; set; }
    }
}
