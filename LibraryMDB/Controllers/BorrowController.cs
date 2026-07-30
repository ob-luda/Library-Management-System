using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers;

public class BorrowController(LibraryContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var records = await context.BorrowRecords.OrderByDescending(r => r.BorrowedDate).ToListAsync();
        return View(records);
    }
}
