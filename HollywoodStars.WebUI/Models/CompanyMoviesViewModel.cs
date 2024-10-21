using HollywoodStars.Models;

namespace HollywoodStars.WebUI.Models;

public class CompanyMoviesViewModel
{
    public Company Company { get; set; } = new Company();
    public List<Movie> AssociatedMovies { get; set; } = new List<Movie>();
    public List<Movie> NonAssociatedMovies { get; set; } = new List<Movie>();
}
