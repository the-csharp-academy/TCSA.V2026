using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;
using TCSA.V2026.Helpers.SurveyQuestions;

namespace TCSA.V2026.UnitTests.Helpers;

[TestFixture]
public class SurveyQuestionRegistryTests
{
    private static SurveyQuestionDraftDto ValidDraft(SurveyQuestionType type) => new()
    {
        Text = "A question",
        Type = type,
        Options = ["A", "B"]
    };

    [Test]
    public void EveryQuestionTypeHasExactlyOneDefinition()
    {
        var registered = SurveyQuestionRegistry.All.Select(d => d.Type).ToList();

        Assert.That(registered, Is.EquivalentTo(Enum.GetValues<SurveyQuestionType>()));
    }

    [Test]
    public void EveryConcreteQuestionClassIsCreatedByExactlyOneDefinition()
    {
        var concreteClasses = typeof(SurveyQuestion).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(SurveyQuestion)) && !t.IsAbstract)
            .ToList();

        var createdClasses = SurveyQuestionRegistry.All
            .Select(d => d.Create(ValidDraft(d.Type), 0).GetType())
            .ToList();

        Assert.That(createdClasses, Is.EquivalentTo(concreteClasses));
    }

    [Test]
    public void EachDefinitionCreatesAQuestionOfItsOwnType()
    {
        foreach (var definition in SurveyQuestionRegistry.All)
        {
            var question = definition.Create(ValidDraft(definition.Type), 3);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(question.Type, Is.EqualTo(definition.Type), definition.Label);
                Assert.That(question.Text, Is.EqualTo("A question"), definition.Label);
                Assert.That(question.Order, Is.EqualTo(3), definition.Label);
            }
        }
    }

    [Test]
    public void EveryDefinitionIsPresentableInTheBuilder()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(SurveyQuestionRegistry.All.Select(d => d.Label), Is.Unique.And.All.Not.Empty);
            Assert.That(SurveyQuestionRegistry.All.Select(d => d.Icon), Is.All.Not.Empty);
            Assert.That(SurveyQuestionRegistry.All.Where(d => d.UsesOptions).Select(d => d.OptionIcon), Is.All.Not.Empty);
        }
    }

    [Test]
    public void OnlyChoiceDefinitionsUseOptions()
    {
        var usingOptions = SurveyQuestionRegistry.All.Where(d => d.UsesOptions).Select(d => d.Type);

        Assert.That(usingOptions, Is.EquivalentTo(new[] { SurveyQuestionType.SingleChoice, SurveyQuestionType.MultipleChoice }));
    }

    [Test]
    public void PrepareDraft_GivesChoiceQuestionsTheirMinimumOptionsAndClearsTheRest()
    {
        foreach (var definition in SurveyQuestionRegistry.All)
        {
            var draft = new SurveyQuestionDraftDto { Type = definition.Type, Options = ["stale"] };

            definition.PrepareDraft(draft);

            if (definition.UsesOptions)
            {
                Assert.That(draft.Options, Has.Count.GreaterThanOrEqualTo(SurveyLimits.MinOptions), definition.Label);
                Assert.That(draft.Options[0], Is.EqualTo("stale"), definition.Label);
            }
            else
            {
                Assert.That(draft.Options, Is.Empty, definition.Label);
            }
        }
    }

    [Test]
    public void Get_ThrowsForAnUnregisteredType_WhileTryGetReportsIt()
    {
        var unknown = (SurveyQuestionType)999;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(SurveyQuestionRegistry.TryGet(unknown, out _), Is.False);
            Assert.That(() => SurveyQuestionRegistry.Get(unknown), Throws.InvalidOperationException);
        }
    }

    [Test]
    public void ValidateDraft_RejectsAChoiceDraftWithoutEnoughOptions_ButNotOtherTypes()
    {
        foreach (var definition in SurveyQuestionRegistry.All)
        {
            var draft = new SurveyQuestionDraftDto { Text = "Q", Type = definition.Type, Options = ["only one"] };

            var error = definition.ValidateDraft(draft);

            if (definition.UsesOptions)
            {
                Assert.That(error?.Code, Is.EqualTo(SurveyErrorCodes.TooFewOptions), definition.Label);
            }
            else
            {
                Assert.That(error, Is.Null, definition.Label);
            }
        }
    }
}
