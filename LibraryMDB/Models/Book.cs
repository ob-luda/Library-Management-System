namespace LibraryManagement.Models;

public class Book
{
    public int Id { get; set; }
    public string CallNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Copies { get; set; } = 1;
    public bool IsAvailable { get; set; } = true;
}
