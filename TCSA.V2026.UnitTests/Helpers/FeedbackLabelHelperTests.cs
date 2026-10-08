using MudBlazor;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Helpers;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class FeedbackLabelHelperTests
{
    [TestCase(FeedbackCategory.Bug, "Bug", Color.Error)]
    [TestCase(FeedbackCategory.Idea, "Idea", Color.Warning)]
    [TestCase(FeedbackCategory.Help, "Help / Confusion", Color.Info)]
    [TestCase(FeedbackCategory.Compliment, "Compliment", Color.Success)]
    public void Category_MapsToItsLabelAndColor(FeedbackCategory category, string label, Color color)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(FeedbackLabelHelper.CategoryLabel(category), Is.EqualTo(label));
            Assert.That(FeedbackLabelHelper.CategoryColor(category), Is.EqualTo(color));
        }
    }

    [Test]
    public void CategoryIcon_IsDistinctForEveryCategory()
    {
        var icons = Enum.GetValues<FeedbackCategory>().Select(FeedbackLabelHelper.CategoryIcon).ToList();

        Assert.That(icons, Is.Unique);
        Assert.That(icons, Has.All.Not.Empty);
    }

    [Test]
    public void UnknownCategory_FallsBackToDefaults()
    {
        var unknown = (FeedbackCategory)999;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(FeedbackLabelHelper.CategoryLabel(unknown), Is.EqualTo("999"));
            Assert.That(FeedbackLabelHelper.CategoryIcon(unknown), Is.EqualTo(Icons.Material.Filled.Feedback));
            Assert.That(FeedbackLabelHelper.CategoryColor(unknown), Is.EqualTo(Color.Default));
        }
    }

    [Test]
    public void Excerpt_ShortBody_IsReturnedUnchanged()
    {
        Assert.That(FeedbackLabelHelper.Excerpt("Save button broken"), Is.EqualTo("Save button broken"));
    }

    [Test]
    public void Excerpt_LongBody_IsTruncatedWithAnEllipsis()
    {
        var excerpt = FeedbackLabelHelper.Excerpt(new string('a', 200));

        Assert.That(excerpt, Is.EqualTo(new string('a', 90) + "…"));
    }

    [Test]
    public void Excerpt_FlattensLineBreaks()
    {
        Assert.That(FeedbackLabelHelper.Excerpt("first\r\nsecond\nthird"), Is.EqualTo("first second third"));
    }

    [Test]
    public void Excerpt_DoesNotInterpretMarkup()
    {
        const string body = "<script>alert('x')</script>";

        Assert.That(FeedbackLabelHelper.Excerpt(body), Is.EqualTo(body));
    }
}
