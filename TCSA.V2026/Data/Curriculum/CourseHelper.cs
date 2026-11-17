using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public class CourseHelper
{
    private static readonly List<Course> _allCourses = BuildCourses();

    private static List<Course> BuildCourses()
    {
        return
        [
            OopCourse.Instance,
            WebApiCourse.Instance,
            SqlCourse.Instance,
            WpfCourse.Instance,
            DiCourse.Instance,
            //ReactCourse.GetReactCourse(),
            LinqCourse.Instance,
            DataStructuresCourse.Instance,
            UnityMovingObjectCourse.Instance,
            //UnityCSharpCourse.GetUnityCSharpCourse()
        ];
    }

    public static List<Course> GetCourses() => _allCourses;
}
