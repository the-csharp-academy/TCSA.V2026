using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using TCSA.V2026.Components.Layout;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Layout;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class FeedbackDetailDrawerTests : BunitContext
{
    private const string ScriptBody = "<script>alert('xss')</script><b>bold</b> & <img src=x onerror=alert(1)>";

    private readonly FeedbackDetailState _state = new();

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
        Services.AddSingleton(Mock.Of<IFeedbackAdminService>());
        Services.AddSingleton(_state);
        Render<MudPopoverProvider>();
    }

    [Test]
    public void Detail_RendersUserTextContainingMarkupAsLiteralText()
    {
        var cut = Render<FeedbackDetailDrawer>();

        _state.Open(new FeedbackAdminItemDto
        {
            Id = 7,
            Category = FeedbackCategory.Bug,
            Body = ScriptBody,
            ReportedPage = "<i>/dashboard</i>",
            OriginUrl = "<u>/dashboard</u>",
            UserName = "ada@example.com",
            UserDisplayName = "<em>Ada</em>",
            CreatedAt = new DateTimeOffset(2026, 10, 8, 12, 0, 0, TimeSpan.Zero)
        });

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".feedback-detail-body"), Has.Count.EqualTo(1)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Find(".feedback-detail-body").TextContent.Trim(), Is.EqualTo(ScriptBody));
            Assert.That(cut.Find(".feedback-detail-body").Children, Is.Empty);
            Assert.That(cut.FindAll("script"), Is.Empty);
            Assert.That(cut.FindAll("img[onerror]"), Is.Empty);
            Assert.That(cut.FindAll(".feedback-detail-facts i, .feedback-detail-facts u, .feedback-detail-facts em"), Is.Empty);
            Assert.That(cut.Find(".feedback-detail-facts").TextContent, Does.Contain("<i>/dashboard</i>"));
            Assert.That(cut.Find(".feedback-detail-facts").TextContent, Does.Contain("<u>/dashboard</u>"));
            Assert.That(cut.Find(".feedback-detail-facts").TextContent, Does.Contain("<em>Ada</em>"));
        }
    }
}
