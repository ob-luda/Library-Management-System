using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

public class BooksController(LibraryContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var books = await context.Books.OrderBy(b => b.CallNumber).ToListAsync();
        return View(books);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid)
        {
            return View(book);
        }

        book.IsAvailable = true;
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
