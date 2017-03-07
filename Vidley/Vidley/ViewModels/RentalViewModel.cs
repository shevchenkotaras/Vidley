using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class RentalViewModel
    {
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}