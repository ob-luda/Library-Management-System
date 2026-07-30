namespace LibraryManagement.Models;

public class BorrowRecord
{
    public int Id { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string Borrower { get; set; } = string.Empty;
    public DateTime BorrowedDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "BORROWED";
}
