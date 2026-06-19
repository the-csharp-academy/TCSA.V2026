using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Services
{
    public interface IReportService
    {
        Task<CourseData> GetCourseData();

    }
    public class ReportService : IReportService
    {
        public Task<CourseData> GetCourseData()
        {
            throw new NotImplementedException();
        }
    }
}

public class CourseData
{
    public int CourseName { get; set; }

    public int ArticlesRead { get; set; }
}