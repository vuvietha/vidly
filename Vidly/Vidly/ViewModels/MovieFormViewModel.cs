using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        
        public IEnumerable<Generes> Generes { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        public DateTime? AddedDate { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        [Required]
        public int? Quantity { get; set; }


        [Display(Name = "Genere")]
        [Required]
        public byte? GenereId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movide";
                return "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(MovieModel movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            AddedDate = movie.AddedDate;
            Quantity = movie.Quantity;
            GenereId = movie.GenereId;

        }
    }
}