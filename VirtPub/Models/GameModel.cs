using System;

namespace VirtPub.Models
{
    public class GameLinksModel
    {
        public Guid id { get; set; }
        public string link { get; set; }
        public string name { get; set; }
        public int maxPlayers { get; set; }
        public int minPlayers { get; set; }
    }
}