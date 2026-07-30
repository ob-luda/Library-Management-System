using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

public class HomeController(LibraryContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var totalTitles = await context.Books.CountAsync();
        var availableTitles = await context.Books.CountAsync(b => b.IsAvailable);
        var onLoanTitles = totalTitles - availableTitles;

        var lastFiled = await context.Books.OrderByDescending(b => b.Id).Select(b => b.Title).FirstOrDefaultAsync();
        var mostRecentLoan = await context.BorrowRecords.OrderByDescending(r => r.BorrowedDate).Select(r => r.BookTitle).FirstOrDefaultAsync();

        var model = new HomeIndexViewModel
        {
            TotalTitles = totalTitles,
            AvailableTitles = availableTitles,
            OnLoanTitles = onLoanTitles,
            LastFiled = lastFiled ?? string.Empty,
            MostRecentLoan = mostRecentLoan ?? string.Empty,
            OverdueEntries = 0
        };

        return View(model);
    }

    public IActionResult About() => View();

    public IActionResult Error() => View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
}
