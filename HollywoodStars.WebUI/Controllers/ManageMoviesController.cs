using HollywoodStars.Data;
using HollywoodStars.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodStars.WebUI.Controllers;

[Authorize]
public class ManageMoviesController : Controller
{
    private readonly HollywoodStarsContext _context;

    public ManageMoviesController(HollywoodStarsContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var list = new List<Movie>();
        try
        {
            list = await MoviesData.GetList(_context);
        }
        catch (Exception ex)
        {
            TempData["DangerMessage"] = ex.Message;
        }
        return View(list);
    }

    public async Task<IActionResult> AddOrUpdate(int? id)
    {
        if (id == null) return View();

        Movie? movie = null;
        try
        {
            movie = await MoviesData.GetMovie((int)id, _context);
        }
        catch (Exception ex)
        {
            TempData["DangerMessage"] = ex.Message;
        }
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOrUpdate(Movie movie)
    {
        if (!ModelState.IsValid)
            return (movie.MovieId == 0) ? View() : View(movie);

        try
        {
            if (movie.MovieId == 0)
                await MoviesData.Insert(movie, _context);
            else
                await MoviesData.Update(movie, _context);
        }
        catch (Exception ex)
        {
            TempData["DangerMessage"] = ex.Message;
            return (movie.MovieId == 0) ? View() : View(movie);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(Movie movie)
    {
        try
        {
            if (await MoviesData.HasCompanies(movie, _context))
                throw new Exception("This movie cannot be removed because it has been associated with one or more companies. Remove all associations first.");
            else
                await MoviesData.Delete(movie, _context);
        }
        catch (Exception ex)
        {
            TempData["DangerMessage"] = ex.Message;
        }
        return RedirectToAction(nameof(Index));
    }
}
