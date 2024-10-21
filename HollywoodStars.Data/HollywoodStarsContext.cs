using HollywoodStars.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HollywoodStars.Data;

public class HollywoodStarsContext : IdentityDbContext
{
    public HollywoodStarsContext(DbContextOptions options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyMovie> CompanyMovies { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>()
            .HasMany(aCompany => aCompany.Movies) // Each company may be assigned to many movies
            .WithMany(aMovie => aMovie.Companies) // Each movie may be assigned to many companies
            .UsingEntity<CompanyMovie>(); // Implicit joint table
    }
}
