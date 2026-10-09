using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.IntegrationTests;

[TestFixture]
public class SurveyModelTests : IntegrationTestsBase
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
    public void EveryQuestionTypeMapsToExactlyOneConcreteQuestionClass()
    {
        using var context = DbContextFactory.CreateDbContext();
        var questionEntity = context.Model.FindEntityType(typeof(SurveyQuestion))!;

        var mapped = questionEntity.GetDerivedTypesInclusive()
            .Where(t => !t.IsAbstract())
            .ToDictionary(t => t.GetDiscriminatorValue()!, t => t.ClrType);

        var concreteClasses = typeof(SurveyQuestion).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(SurveyQuestion)) && !t.IsAbstract);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mapped.Keys, Is.EquivalentTo(Enum.GetValues<SurveyQuestionType>().Cast<object>()));
            Assert.That(mapped.Values, Is.EquivalentTo(concreteClasses));
        }
    }

    [Test]
    public void QuestionType_IsTheDiscriminator_StoredAsItsName()
    {
        using var context = DbContextFactory.CreateDbContext();
        var questionEntity = context.Model.FindEntityType(typeof(SurveyQuestion))!;
        var type = questionEntity.FindProperty(nameof(SurveyQuestion.Type))!;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(questionEntity.FindDiscriminatorProperty(), Is.SameAs(type));
            Assert.That(type.GetProviderClrType(), Is.EqualTo(typeof(string)));
        }
    }

    [Test]
    public void Options_ExistOnlyOnChoiceQuestions()
    {
        using var context = DbContextFactory.CreateDbContext();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(context.Model.FindEntityType(typeof(SurveyQuestion))!.FindNavigation("Options"), Is.Null);
            Assert.That(context.Model.FindEntityType(typeof(ChoiceQuestion))!.FindNavigation("Options"), Is.Not.Null);
            Assert.That(context.Model.FindEntityType(typeof(RatingQuestion))!.FindNavigation("Options"), Is.Null);
        }
    }

    [Test]
    public void QuestionAndOptionOrder_AreUniqueWithinTheirParent()
    {
        using var context = DbContextFactory.CreateDbContext();

        var questionOrder = context.Model.FindEntityType(typeof(SurveyQuestion))!.GetIndexes()
            .Single(i => i.Properties.Select(p => p.Name).SequenceEqual([nameof(SurveyQuestion.SurveyId), nameof(SurveyQuestion.Order)]));
        var optionOrder = context.Model.FindEntityType(typeof(SurveyOption))!.GetIndexes()
            .Single(i => i.Properties.Select(p => p.Name).SequenceEqual([nameof(SurveyOption.SurveyQuestionId), nameof(SurveyOption.Order)]));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(questionOrder.IsUnique, Is.True);
            Assert.That(optionOrder.IsUnique, Is.True);
        }
    }
}
