using System.Text.Json.Serialization;

namespace TCSA.V2026.Data.Models;

public class SurveyResponse
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public string AppUserId { get; set; } = string.Empty;
    public DateTimeOffset SubmittedAt { get; set; }

    [JsonIgnore]
    public Survey Survey { get; set; } = null!;

    [JsonIgnore]
    public ApplicationUser AppUser { get; set; } = null!;

    public List<SurveyAnswer> Answers { get; set; } = [];
}

public class SurveyRefusal
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public string AppUserId { get; set; } = string.Empty;
    public DateTimeOffset RefusedAt { get; set; }
    public Survey Survey { get; set; } = null!;
    public ApplicationUser AppUser { get; set; } = null!;
}
