using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleasedDate { get; set; }

        public DateTime AddedDate { get; set; }

        [Display(Name="Number in stock")]
        [Range(1,20)]
        public int Quantity { get; set; }

        public Generes Genere { get; set; }

        [Display(Name = "Genere")]
        public byte GenereId { get; set; }

      
    }
}