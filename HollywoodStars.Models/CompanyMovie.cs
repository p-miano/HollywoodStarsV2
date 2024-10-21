using Microsoft.EntityFrameworkCore;

namespace HollywoodStars.Models;

[PrimaryKey(nameof(CompanyId), nameof(MovieId))]
public class CompanyMovie
{
    public int CompanyId { get; set; }
    public int MovieId { get; set; }
}
