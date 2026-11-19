using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.UnitTests.Models;

[TestFixture]
public class SurveyQuestionTests
{
    private static readonly string[] TwoOptions = ["A", "B"];

    private static IEnumerable<TestCaseData> OptionlessQuestions()
    {
        yield return new TestCaseData((Func<string, SurveyQuestion>)(text => RatingQuestion.Create(text, true, 0)), SurveyQuestionType.Rating).SetName("Rating");
        yield return new TestCaseData((Func<string, SurveyQuestion>)(text => YesNoQuestion.Create(text, true, 0)), SurveyQuestionType.YesNo).SetName("YesNo");
        yield return new TestCaseData((Func<string, SurveyQuestion>)(text => FreeTextQuestion.Create(text, true, 0)), SurveyQuestionType.FreeText).SetName("FreeText");
    }

    private static IEnumerable<TestCaseData> ChoiceQuestions()
    {
        yield return new TestCaseData((Func<IEnumerable<string>, ChoiceQuestion>)(options => SingleChoiceQuestion.Create("Pick", true, 0, options)), SurveyQuestionType.SingleChoice).SetName("SingleChoice");
        yield return new TestCaseData((Func<IEnumerable<string>, ChoiceQuestion>)(options => MultipleChoiceQuestion.Create("Pick", true, 0, options)), SurveyQuestionType.MultipleChoice).SetName("MultipleChoice");
    }

    [TestCaseSource(nameof(OptionlessQuestions))]
    public void Create_SetsTheTypeAndFields(Func<string, SurveyQuestion> create, SurveyQuestionType expected)
    {
        var question = create("How was it?");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(question.Type, Is.EqualTo(expected));
            Assert.That(question.Text, Is.EqualTo("How was it?"));
            Assert.That(question.IsRequired, Is.True);
            Assert.That(question.Order, Is.Zero);
        }
    }

    [TestCaseSource(nameof(OptionlessQuestions))]
    public void Create_RejectsBlankOrTooLongText(Func<string, SurveyQuestion> create, SurveyQuestionType _)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(() => create(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create("   "), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create(new string('q', SurveyLimits.QuestionMaxLength + 1)), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create(new string('q', SurveyLimits.QuestionMaxLength)), Throws.Nothing);
        }
    }

    [Test]
    public void Create_RejectsANegativeOrder()
    {
        Assert.That(() => RatingQuestion.Create("Q", true, -1), Throws.InstanceOf<ArgumentException>());
    }

    [TestCaseSource(nameof(ChoiceQuestions))]
    public void ChoiceQuestion_KeepsItsOptionsInOrder(Func<IEnumerable<string>, ChoiceQuestion> create, SurveyQuestionType expected)
    {
        var question = create(["X", "Y", "Z"]);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(question.Type, Is.EqualTo(expected));
            Assert.That(question.Options.Select(o => o.Text), Is.EqualTo(new[] { "X", "Y", "Z" }));
            Assert.That(question.Options.Select(o => o.Order), Is.EqualTo(new[] { 0, 1, 2 }));
        }
    }

    [TestCaseSource(nameof(ChoiceQuestions))]
    public void ChoiceQuestion_EnforcesTheOptionCountBounds(Func<IEnumerable<string>, ChoiceQuestion> create, SurveyQuestionType _)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(() => create([]), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create(["Only one"]), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create(TwoOptions), Throws.Nothing);
            Assert.That(() => create(Enumerable.Range(0, SurveyLimits.MaxOptions).Select(i => $"O{i}")), Throws.Nothing);
            Assert.That(() => create(Enumerable.Range(0, SurveyLimits.MaxOptions + 1).Select(i => $"O{i}")), Throws.InstanceOf<ArgumentException>());
        }
    }

    [TestCaseSource(nameof(ChoiceQuestions))]
    public void ChoiceQuestion_RejectsBlankOrTooLongOptions(Func<IEnumerable<string>, ChoiceQuestion> create, SurveyQuestionType _)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(() => create(["A", ""]), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create(["A", "  "]), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create(["A", new string('o', SurveyLimits.OptionMaxLength + 1)]), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => create(["A", new string('o', SurveyLimits.OptionMaxLength)]), Throws.Nothing);
        }
    }
}
