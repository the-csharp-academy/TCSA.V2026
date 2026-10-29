using Microsoft.EntityFrameworkCore;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.IntegrationTests;

// EF InMemory does not enforce cascades, so the delete behavior is asserted on the model.
// UserService.DeleteAccount relies on the database cascading these rows.
[TestFixture]
public class FeedbackModelTests : IntegrationTestsBase
{
    [SetUp]
    public void Setup()
    {
        BaseSetup();
    }

    [TearDown]
    public void TearDown()
    {
        BaseTearDown();
    }

    [Test]
    public void FeedbackItem_IsDeletedWhenItsUserIsDeleted()
    {
        using var context = DbContextFactory.CreateDbContext();

        var userForeignKey = context.Model.FindEntityType(typeof(FeedbackItem))!
            .GetForeignKeys()
            .Single(fk => fk.PrincipalEntityType.ClrType == typeof(ApplicationUser));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(userForeignKey.DeleteBehavior, Is.EqualTo(DeleteBehavior.Cascade));
            Assert.That(userForeignKey.IsRequired, Is.True);
        }
    }
}
