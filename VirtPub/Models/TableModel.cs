using System;

namespace VirtPub.Models
{
    public class TableModel
    {
        public Guid id { get; set; }
        public bool isPrivate { get; set; }
        public GameLinksModel game { get; set;}
    }
}