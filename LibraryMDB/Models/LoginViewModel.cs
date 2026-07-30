using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class LoginViewModel
{
    [Required]
    [Display(Name = "CREDENTIAL ID / EMAIL")]
    public string CredentialId { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "PASSPHRASE")]
    public string Passphrase { get; set; } = string.Empty;
}
