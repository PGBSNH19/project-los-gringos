using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
