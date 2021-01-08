using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
