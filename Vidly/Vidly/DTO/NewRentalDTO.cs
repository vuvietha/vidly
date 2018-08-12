using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTO
{
    public class NewRentalDTO
    {
        [Display(Name ="Customer")]
        public int CustomerId { get; set; }

        public IEnumerable<MovieModel> Movies { get; set; }

        public IEnumerable<CustomerModel> Customers { get; set; }

        [Display(Name = "Movie")]
        public List<int> MovieIds { get; set; }
    }
}