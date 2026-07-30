namespace LibraryManagement.Models;

public class HomeIndexViewModel
{
    public int TotalTitles { get; set; }
    public int AvailableTitles { get; set; }
    public int OnLoanTitles { get; set; }
    public string LastFiled { get; set; } = string.Empty;
    public string MostRecentLoan { get; set; } = string.Empty;
    public int OverdueEntries { get; set; }
}
