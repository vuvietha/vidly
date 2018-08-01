using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int Quantity { get; set; }
        public Generes Genere { get; set; }
        public byte GenereId { get; set; }
    }
}