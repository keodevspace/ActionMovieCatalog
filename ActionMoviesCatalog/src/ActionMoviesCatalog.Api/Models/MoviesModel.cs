using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionMoviesCatalog.Api.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
}
