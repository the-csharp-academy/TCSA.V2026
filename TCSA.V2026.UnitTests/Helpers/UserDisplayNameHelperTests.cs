using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class UserDisplayNameHelperTests
{
    [TestCase("John Doe", "John Doe", "John Doe")]
    [TestCase(null, "johndoe@example.com", "johndoe")]
    [TestCase(null, null, "Anonymous")]
    [TestCase("John Doe", null, "John Doe")]
    public void GetDisplayName_ShouldReturnDisplayName(string? displayName, string? userName, string expected)
    {
        // Act
        string result = UserDisplayNameHelper.GetDisplayName(displayName, userName);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
