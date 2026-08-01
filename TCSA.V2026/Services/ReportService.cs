using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Curriculum;
using TCSA.V2026.Data.Models.Responses;

namespace TCSA.V2026.Services;

public interface IReportService
{
    Task<ServiceResponse> GetCourseCount();
}

public class ReportService(IDbContextFactory<ApplicationDbContext> factory) : IReportService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory = factory;

    public async Task<ServiceResponse> GetCourseCount()
    {
        var courses = CourseHelper.GetCourses();
        var courseArticles = courses.ToDictionary(
            course => course.Title,
            course => course.Articles.Select(article => article.Id).ToHashSet());

        try
        {
            using var context = _factory.CreateDbContext();

            var completedArticleCounts = await context.DashboardProjects
                .AsNoTracking()
                .Where(project => project.IsCompleted)
                .GroupBy(project => project.ProjectId)
                .Select(group => new { ArticleId = group.Key, Count = group.Count() })
                .ToDictionaryAsync(item => item.ArticleId, item => item.Count);

            var count = courseArticles.ToDictionary(
                course => course.Key,
                course => course.Value.Sum(articleId =>
                    completedArticleCounts.GetValueOrDefault(articleId)));

            return new ServiceResponse
            {
                IsSuccessful = true,
                Message = JsonSerializer.Serialize(count)
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                IsSuccessful = false,
                Message = ex.Message
            };
        }
    }
}
