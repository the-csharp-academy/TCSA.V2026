using System.ComponentModel.DataAnnotations;

namespace TCSA.V2026.Data.Models.Options;

public class BrevoOptions
{
    [Required]
    public string ApiKey { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string SenderEmail { get; set; } = string.Empty;

    [Required]
    public string SenderName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string ReplyToEmail { get; set; } = string.Empty;
}
