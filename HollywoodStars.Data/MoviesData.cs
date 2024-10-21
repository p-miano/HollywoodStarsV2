using HollywoodStars.Models;
using Microsoft.EntityFrameworkCore;

namespace HollywoodStars.Data;

public static class MoviesData
{
    public static async Task Insert(Movie movie, HollywoodStarsContext context)
    {
        if (movie.ReleaseYear < DateTime.Now.Year) throw new Exception("The value in the Release Year field cannot be earlier than the current year.");
        context.Movies.Add(movie);
        await context.SaveChangesAsync();
    }

    public static async Task Update(Movie movie, HollywoodStarsContext context)
    {
        if (movie.ReleaseYear < DateTime.Now.Year) throw new Exception("The value in the Release Year field cannot be earlier than the current year.");
        context.Movies.Update(movie);
        await context.SaveChangesAsync();
    }

    public static async Task<Movie?> GetMovie(int movieId, HollywoodStarsContext context)
    {
        return await context.Movies.FindAsync(movieId);
    }

    public static async Task<List<Movie>> GetList(HollywoodStarsContext context)
    {
        return await context.Movies.ToListAsync();
    }

    public static async Task Delete(Movie movie, HollywoodStarsContext context)
    {
        context.Movies.Remove(movie);
        await context.SaveChangesAsync();
    }

    public static async Task<bool> HasCompanies(Movie movie, HollywoodStarsContext context)
    {
        return await context.CompanyMovies.AnyAsync(cm => cm.MovieId == movie.MovieId);
    }
}
