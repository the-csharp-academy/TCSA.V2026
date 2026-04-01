namespace TCSA.V2026.Data.DTOs;

public record HomePageStatistics(
    int AllUsers,
    int CurrentYearUsers,
    int AllReviewedProjects,
    int CurrentYearReviewedProjects,
    int CurrentYear,
    TimeSpan AverageReviewTime
);
