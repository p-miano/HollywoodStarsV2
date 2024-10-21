using HollywoodStars.Models;
using Microsoft.EntityFrameworkCore;

namespace HollywoodStars.Data;

public static class CompaniesData
{
    public static async Task Insert(Company company, HollywoodStarsContext context)
    {
        context.Companies.Add(company);
        await context.SaveChangesAsync();
    }

    public static async Task Update(Company company, HollywoodStarsContext context)
    {
        context.Companies.Update(company);
        await context.SaveChangesAsync();
    }

    public static async Task<Company?> GetCompany(int companyId, HollywoodStarsContext context)
    {
        return await context.Companies.FindAsync(companyId);
    }

    public static async Task<List<Company>> GetList(HollywoodStarsContext context)
    {
        return await context.Companies.ToListAsync();
    }

    public static async Task Delete(Company company, HollywoodStarsContext context)
    {
        context.Companies.Remove(company);
        await context.SaveChangesAsync();
    }

    public static async Task<bool> HasMovies(Company company, HollywoodStarsContext context)
    {
        return await context.CompanyMovies.AnyAsync(cm => cm.CompanyId == company.CompanyId);
    }
}
