using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public CustomerModel customer { get; set; }

        [Required]
        public MovieModel movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}