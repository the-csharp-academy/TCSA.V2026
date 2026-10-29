using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class CommunityProjectHelperTests
{
    [TestCase(CommunityProject.TCSA, "Academy 2026")]
    [TestCase(CommunityProject.KnowTheCity, "Know The City")]
    [TestCase(CommunityProject.PointOfSale, "Point of Sale")]
    [TestCase(CommunityProject.AcademyV2, "Academy V2")]
    public void GetDisplayName_ShouldReturnExpectedName(CommunityProject project, string expected)
    {
        var result = CommunityProjectHelper.GetDisplayName((int)project);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetDisplayName_ShouldNotThrow_ForEveryCommunityProject()
    {
        foreach (var project in Enum.GetValues<CommunityProject>())
        {
            Assert.DoesNotThrow(() => CommunityProjectHelper.GetDisplayName((int)project), project.ToString());
        }
    }

    [Test]
    public void GetDisplayName_ShouldThrow_WhenProjectIsUnknown()
    {
        Assert.Throws<ArgumentException>(() => CommunityProjectHelper.GetDisplayName(9999));
    }
}
