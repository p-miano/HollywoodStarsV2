using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HollywoodStars.Models;

public class Company
{
    [Key]
    [DisplayName("Company Id")]
    public int CompanyId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Type { get; set; } = string.Empty;

    public List<Movie> Movies { get; set; } = new List<Movie>();
}
