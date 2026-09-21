using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class CourseContentHelperTests
{
    [TestCase("List<Flight>", "List<Flight>")]
    [TestCase("List&lt;Flight&gt;", "List<Flight>")]
    [TestCase("List&lt;Flight&gt", "List<Flight>")]
    public void DecodeCode_DisplaysGenericTypeBrackets(string code, string expected)
    {
        var result = CourseContentHelper.DecodeCode(code);

        Assert.That(result, Is.EqualTo(expected));
    }
}
