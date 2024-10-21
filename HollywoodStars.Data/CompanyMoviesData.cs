using HollywoodStars.Models;
using Microsoft.EntityFrameworkCore;

namespace HollywoodStars.Data;

public static class CompanyMoviesData
{
    public static async Task<List<Movie>> GetAssociatedMovieList(int companyId, HollywoodStarsContext context)
    {
        var result = await (from movie in context.Movies
                            where (from companyMovie in context.CompanyMovies
                                   where companyMovie.CompanyId == companyId
                                   select companyMovie.MovieId).Distinct()
                                   .Contains(movie.MovieId)
                            select movie).ToListAsync();
        return result;
    }

    public static async Task<List<Movie>> GetNonAssociatedMovieList(int companyId, HollywoodStarsContext context)
    {
        var result = await (from movie in context.Movies
                            where !(from companyMovie in context.CompanyMovies
                                   where companyMovie.CompanyId == companyId
                                   select companyMovie.MovieId).Distinct()
                                   .Contains(movie.MovieId)
                            select movie).ToListAsync();
        return result;
    }

    public static async Task Insert(int companyId, int movieId, HollywoodStarsContext context)
    {
        var companyMovie = new CompanyMovie { CompanyId = companyId, MovieId = movieId };
        await context.CompanyMovies.AddAsync(companyMovie);
        await context.SaveChangesAsync();
    }

    public static async Task Delete(int companyId, int movieId, HollywoodStarsContext context)
    {
        var companyMovie = new CompanyMovie { CompanyId = companyId, MovieId = movieId };
        context.CompanyMovies.Remove(companyMovie);
        await context.SaveChangesAsync();
    }
}
