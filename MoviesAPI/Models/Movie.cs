using System;
using System.Collections.Generic;

namespace MoviesAPI.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public string Actor { get; set; } = null!;
        public double Rating { get; set; }
        public double ActorRating { get; set; }
    }
}
