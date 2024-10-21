using HollywoodStars.Data;
using HollywoodStars.Models;
using HollywoodStars.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodStars.WebUI.Controllers;

[Authorize]
public class ManageCompanyMoviesController : Controller
{
    private readonly HollywoodStarsContext _context;

    public ManageCompanyMoviesController(HollywoodStarsContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? id)
    {
        Company? company = null;
        List<Movie> listOfAssociated = new List<Movie>();
        List<Movie> listOfNonAssociated = new List<Movie>();

        try
        {
            company = await CompaniesData.GetCompany((int)id!, _context);
            listOfAssociated = await CompanyMoviesData.GetAssociatedMovieList((int)id!, _context);
            listOfNonAssociated = await CompanyMoviesData.GetNonAssociatedMovieList((int)id!, _context);
        }
        catch (Exception ex)
        {
            TempData["DangerMessage"] = ex.Message;
        }

        var myViewModel = new CompanyMoviesViewModel();
        myViewModel.Company = company!;
        myViewModel.AssociatedMovies = listOfAssociated;
        myViewModel.NonAssociatedMovies = listOfNonAssociated;

        return View(myViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int companyId, int movieId)
    {
        try
        {
            await CompanyMoviesData.Insert(companyId, movieId, _context);
        }
        catch (Exception ex)
        {
            TempData["DangerMessage"] = ex.Message;
        }
        return RedirectToAction(nameof(Index), new { id = companyId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int companyId, int movieId)
    {
        try
        {
            await CompanyMoviesData.Delete(companyId, movieId, _context);
        }
        catch (Exception ex)
        {
            TempData["DangerMessage"] = ex.Message;
        }
        return RedirectToAction(nameof(Index), new { id = companyId });
    }
}
