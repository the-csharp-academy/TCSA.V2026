using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class CourseHelper
{
    public static List<Course> GetCourses()
    {
        return new List<Course>
        {
            OopCourse.GetOopCourse(),
            WebApiCourse.GetWebApiCourse(),
            SqlCourse.GetSqlCourse(),
            WpfCourse.GetWpfCourse(),
            DiCourse.GetDiCourse(),
            //ReactCourse.GetReactCourse(),
            LinqCourse.GetLinqCourse()
        };
    }
}
