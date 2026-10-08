using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor.Services;
using TCSA.V2026.Components.Pages.Admin;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models.Responses;
using TCSA.V2026.Services;

namespace TCSA.V2026.UnitTests.Components.Pages.Admin;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class AdminFeedbackTests : BunitContext
{
    private const string ScriptBody = "<script>alert('xss')</script><b>bold</b> & <img src=x onerror=alert(1)>";

    private readonly Mock<IFeedbackAdminService> _serviceMock = new();

    [SetUp]
    public void SetUp()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.AddMudServices();
        Services.AddSingleton(_serviceMock.Object);
        Services.AddSingleton(new FeedbackDetailState());
        Render<MudBlazor.MudPopoverProvider>();
    }

    private void ReturnItems(params FeedbackAdminItemDto[] items)
    {
        _serviceMock
            .Setup(s => s.GetItems(It.IsAny<FeedbackAdminFilter>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new PaginatedList<FeedbackAdminItemDto>(items.ToList(), items.Length, 1, 10));
    }

    private static FeedbackAdminItemDto Item(string body) => new()
    {
        Id = 1,
        Category = FeedbackCategory.Bug,
        Body = body,
        OriginUrl = "/dashboard",
        UserName = "ada@example.com",
        CreatedAt = new DateTimeOffset(2026, 10, 8, 12, 0, 0, TimeSpan.Zero)
    };

    [Test]
    public void ListRow_RendersABodyContainingMarkupAsLiteralText()
    {
        ReturnItems(Item(ScriptBody));

        var cut = Render<AdminFeedback>();

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".feedback-open"), Has.Count.EqualTo(1)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Find(".feedback-open").TextContent.Trim(), Is.EqualTo(ScriptBody));
            Assert.That(cut.Find(".feedback-open").Children, Is.Empty);
            Assert.That(cut.FindAll("script"), Is.Empty);
            Assert.That(cut.FindAll("img[onerror]"), Is.Empty);
            Assert.That(cut.FindAll(".feedback-open b"), Is.Empty);
        }
    }

    [Test]
    public void ListRow_RendersAReportedPageContainingMarkupAsLiteralText()
    {
        var item = Item("body");
        item.ReportedPage = "<i>/dashboard</i>";
        ReturnItems(item);

        var cut = Render<AdminFeedback>();

        cut.WaitForAssertion(() => Assert.That(cut.FindAll(".feedback-open"), Has.Count.EqualTo(1)));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cut.Markup, Does.Contain("&lt;i&gt;/dashboard&lt;/i&gt;"));
            Assert.That(cut.FindAll("td i"), Is.Empty);
        }
    }
}
