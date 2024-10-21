using HollywoodStars.Models.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HollywoodStars.Models;

public class Movie
{
    [Key]
    [DisplayName("Movie Id")]
    public int MovieId { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [CurrentYear]
    [DisplayName("Release Year")]
    public int ReleaseYear { get; set; }

    public List<Company> Companies { get; set; } = new List<Company>();
}
