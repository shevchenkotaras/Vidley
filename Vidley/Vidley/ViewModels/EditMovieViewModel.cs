using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class EditMovieViewModel
    {
        public EditMovieViewModel()
        {
            Id = 0;
        }

        public EditMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }
                return "New Mvoie";
            }
        }
    }
}