using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public MovieModel Movie { get; set; }
        public List<CustomerModel>  Customers { get; set; }
    }
}