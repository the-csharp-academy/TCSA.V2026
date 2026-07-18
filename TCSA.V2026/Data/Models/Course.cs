namespace TCSA.V2026.Data.Models;

public class Course
{
    public int Id { get; set; }
    public CourseLevel Level { get; set; } = CourseLevel.Beginner;
    public string Title { get; set; }
    public string Description { get; set; }
    public string CourseUrl { get; set; }
    public string ImgUrl { get; set; }

    public List<Article> Articles { get; set; }
}

public enum CourseLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Expert
}
