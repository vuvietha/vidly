using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
   
        public DateTime ReleasedDate { get; set; }

        public DateTime AddedDate { get; set; }
  
        [Range(1, 20)]
        public int Quantity { get; set; }
 
        public byte GenereId { get; set; }
    }
}