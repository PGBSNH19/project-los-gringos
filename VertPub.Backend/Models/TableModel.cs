using System;
using System.ComponentModel.DataAnnotations;

namespace VertPub.Backend.Models
{
    public class TableModel
    {
        [Key]
        public Guid id { get; set; }
        public bool isPrivate { get; set; }
        public Guid gameID { get; set; }
    }
}
