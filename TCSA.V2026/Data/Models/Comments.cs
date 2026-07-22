using System.ComponentModel.DataAnnotations;

namespace TCSA.V2026.Data.Models;

public class Comments
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public string AppUserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(2000)]
    public string Comment { get; set; } = string.Empty;

    public DateTimeOffset Date { get; set; }
    public bool IsReviewed { get; set; }
    public ApplicationUser AppUser { get; set; } = null!;
}
