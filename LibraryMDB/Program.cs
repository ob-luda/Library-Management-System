using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });

builder.Services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibraryDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();

    context.Books.AddRange(
        new Book { CallNumber = "895.6 MUR", Title = "The Wind-Up Bird Chronicle", Author = "Haruki Murakami", Copies = 2, IsAvailable = true },
        new Book { CallNumber = "909 HAR", Title = "Sapiens", Author = "Yuval Noah Harari", Copies = 1, IsAvailable = false },
        new Book { CallNumber = "813.5 LEG", Title = "The Left Hand of Darkness", Author = "Ursula K. Le Guin", Copies = 3, IsAvailable = true },
        new Book { CallNumber = "581.6 KIM", Title = "Braiding Sweetgrass", Author = "Robin Wall Kimmerer", Copies = 2, IsAvailable = true },
        new Book { CallNumber = "813.6 LEE", Title = "Pachinko", Author = "Min Jin Lee", Copies = 1, IsAvailable = true }
    );

    context.BorrowRecords.AddRange(
        new BorrowRecord { BookTitle = "Sapiens", Borrower = "A. Verma", BorrowedDate = new DateTime(2026, 7, 10), DueDate = new DateTime(2026, 7, 24), Status = "RETURNED" },
        new BorrowRecord { BookTitle = "Klara and the Sun", Borrower = "R. Singh", BorrowedDate = new DateTime(2026, 6, 28), DueDate = new DateTime(2026, 7, 12), Status = "RETURNED" },
        new BorrowRecord { BookTitle = "The Left Hand of Darkness", Borrower = "M. Chen", BorrowedDate = new DateTime(2026, 6, 2), DueDate = new DateTime(2026, 6, 16), Status = "RETURNED" }
    );

    context.SaveChanges();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
