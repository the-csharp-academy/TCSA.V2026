using TCSA.V2026.Components.UI;
using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Enums;
using static TCSA.V2026.UnitTests.Components.UI.SurveyFixtures;

namespace TCSA.V2026.UnitTests.Components.UI;

[TestFixture]
public class SurveyDialogStateTests
{
    private static SurveyDialogState StartedState()
    {
        var state = new SurveyDialogState(MixedSurvey());
        state.Start();
        return state;
    }

    private static SurveyDialogState AtReview()
    {
        var state = StartedState();
        state.SetNumber(1, 4);
        state.Next();
        state.SelectOption(2, 200);
        state.Next();
        state.Skip();
        state.Skip();
        state.Skip();
        return state;
    }

    #region Navigation

    [Test]
    public void StartsOnTheIntroStep_WithNoProgressShown()
    {
        var state = new SurveyDialogState(MixedSurvey());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.Step, Is.EqualTo(SurveyStep.Intro));
            Assert.That(state.ProgressLabel, Is.Empty);
            Assert.That(state.CurrentQuestion, Is.Null);
        }
    }

    [Test]
    public void Start_MovesToTheFirstQuestion_AndShowsProgress()
    {
        var state = StartedState();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.Step, Is.EqualTo(SurveyStep.Question));
            Assert.That(state.CurrentQuestion!.Id, Is.EqualTo(1));
            Assert.That(state.ProgressLabel, Is.EqualTo("1 of 5"));
            Assert.That(state.ProgressPercent, Is.EqualTo(20).Within(0.001));
        }
    }

    [Test]
    public void Next_MovesThroughTheQuestionsInOrder_ThenToTheReviewStep()
    {
        var state = StartedState();
        state.SetNumber(1, 3);
        state.Next();
        state.SelectOption(2, 201);
        state.Next();

        Assert.That(state.ProgressLabel, Is.EqualTo("3 of 5"));

        state.Skip();
        state.Skip();
        state.Skip();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.Step, Is.EqualTo(SurveyStep.Review));
            Assert.That(state.ProgressLabel, Is.Empty);
        }
    }

    [Test]
    public void Back_MovesToThePreviousQuestion_AndFromTheFirstQuestionToTheIntro()
    {
        var state = StartedState();
        state.SetNumber(1, 3);
        state.Next();

        state.Back();
        Assert.That(state.CurrentQuestion!.Id, Is.EqualTo(1));

        state.Back();
        Assert.That(state.Step, Is.EqualTo(SurveyStep.Intro));
    }

    [Test]
    public void Back_FromTheReviewStep_ReturnsToTheLastQuestion()
    {
        var state = AtReview();

        state.Back();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.Step, Is.EqualTo(SurveyStep.Question));
            Assert.That(state.CurrentQuestion!.Id, Is.EqualTo(5));
        }
    }

    [Test]
    public void Back_KeepsTheAnswersAlreadyGiven()
    {
        var state = StartedState();
        state.SetNumber(1, 4);
        state.Next();

        state.Back();

        Assert.That(state.AnswerOrBlank(1).NumericValue, Is.EqualTo(4));
    }

    [Test]
    public void GoTo_FromTheReviewStep_OpensThatQuestion_AndNextReturnsToTheReview()
    {
        var state = AtReview();

        state.GoTo(0);
        state.SetNumber(1, 2);
        state.Next();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.Step, Is.EqualTo(SurveyStep.Review));
            Assert.That(state.AnswerOrBlank(1).NumericValue, Is.EqualTo(2));
        }
    }

    [Test]
    public void GoTo_ThenBackToTheIntroAndStartAgain_WalksTheQuestionsOneByOne()
    {
        var state = AtReview();
        state.GoTo(0);
        state.Back();
        state.Start();
        state.Next();

        Assert.That(state.CurrentQuestion!.Id, Is.EqualTo(2));
    }

    [Test]
    public void ClearNumber_MakesARatingUnansweredAgain()
    {
        var state = StartedState();
        state.SetNumber(1, 3);

        state.ClearNumber(1);

        Assert.That(state.CanAdvance, Is.False);
    }

    [Test]
    public void GoTo_IsIgnoredOutsideTheReviewStep()
    {
        var state = StartedState();

        state.GoTo(3);

        Assert.That(state.CurrentQuestion!.Id, Is.EqualTo(1));
    }

    #endregion

    #region Required and optional questions

    [Test]
    public void ARequiredUnansweredQuestion_BlocksNext_AndCannotBeSkipped()
    {
        var state = StartedState();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.CanAdvance, Is.False);
            Assert.That(state.CanSkip, Is.False);
            Assert.That(state.NeedsAnswer, Is.True);
        }

        state.Next();

        Assert.That(state.CurrentQuestion!.Id, Is.EqualTo(1));
    }

    [Test]
    public void AnsweringARequiredQuestion_UnblocksNext()
    {
        var state = StartedState();

        state.SetNumber(1, 5);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.CanAdvance, Is.True);
            Assert.That(state.NeedsAnswer, Is.False);
        }
    }

    [Test]
    public void SkipOnARequiredQuestion_DoesNothing()
    {
        var state = StartedState();

        state.Skip();

        Assert.That(state.CurrentQuestion!.Id, Is.EqualTo(1));
    }

    [Test]
    public void AnOptionalUnansweredQuestion_OffersSkip_AndNextIsAlsoAllowed()
    {
        var state = StartedState();
        state.SetNumber(1, 3);
        state.Next();
        state.SelectOption(2, 200);
        state.Next();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.CurrentQuestion!.IsRequired, Is.False);
            Assert.That(state.CanSkip, Is.True);
            Assert.That(state.CanAdvance, Is.True);
            Assert.That(state.NeedsAnswer, Is.False);
        }
    }

    [Test]
    public void AnAnsweredOptionalQuestion_NoLongerOffersSkip()
    {
        var state = StartedState();
        state.SetNumber(1, 3);
        state.Next();
        state.SelectOption(2, 200);
        state.Next();

        state.ToggleOption(3, 300, true);

        Assert.That(state.CanSkip, Is.False);
    }

    [Test]
    public void ClearingARequiredFreeTextAnswerToWhitespace_BlocksNextAgain()
    {
        var state = new SurveyDialogState(new AvailableSurveyDto
        {
            Questions = [Question(1, SurveyQuestionType.FreeText, true)]
        });
        state.Start();
        state.SetText(1, "hello");
        Assert.That(state.CanAdvance, Is.True);

        state.SetText(1, "   ");

        Assert.That(state.CanAdvance, Is.False);
    }

    [Test]
    public void Submit_IsOnlyAllowedOnTheReviewStep_WhenEveryRequiredQuestionIsAnswered()
    {
        var untouched = new SurveyDialogState(MixedSurvey());
        var review = AtReview();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(untouched.CanSubmit, Is.False);
            Assert.That(untouched.MissingRequired.Select(q => q.Id), Is.EqualTo(new[] { 1, 2 }));
            Assert.That(review.CanSubmit, Is.True);
            Assert.That(review.MissingRequired, Is.Empty);
        }
    }

    [Test]
    public void Submit_IsBlocked_WhenARequiredAnswerIsClearedAfterReachingTheReview()
    {
        var state = AtReview();
        state.ClearNumber(1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.CanSubmit, Is.False);
            Assert.That(state.MissingRequired.Select(q => q.Id), Is.EqualTo(new[] { 1 }));
        }
    }

    #endregion

    #region Answers

    [Test]
    public void SelectOption_ReplacesTheChoiceOnASingleChoiceQuestion()
    {
        var state = new SurveyDialogState(MixedSurvey());

        state.SelectOption(2, 200);
        state.SelectOption(2, 201);

        Assert.That(state.AnswerOrBlank(2).OptionIds, Is.EqualTo(new[] { 201 }));
    }

    [Test]
    public void ToggleOption_AddsAndRemovesOptionsOnAMultipleChoiceQuestion()
    {
        var state = new SurveyDialogState(MixedSurvey());

        state.ToggleOption(3, 300, true);
        state.ToggleOption(3, 302, true);
        state.ToggleOption(3, 300, false);

        Assert.That(state.AnswerOrBlank(3).OptionIds, Is.EqualTo(new[] { 302 }));
    }

    [Test]
    public void ToggleOption_NeverRecordsTheSameOptionTwice()
    {
        var state = new SurveyDialogState(MixedSurvey());

        state.ToggleOption(3, 300, true);
        state.ToggleOption(3, 300, true);

        Assert.That(state.AnswerOrBlank(3).OptionIds, Is.EqualTo(new[] { 300 }));
    }

    [Test]
    public void AnswersRemainDistinctPerQuestion()
    {
        var state = new SurveyDialogState(MixedSurvey());

        state.SetNumber(1, 2);
        state.SetNumber(5, 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.AnswerOrBlank(1).NumericValue, Is.EqualTo(2));
            Assert.That(state.AnswerOrBlank(5).NumericValue, Is.EqualTo(1));
        }
    }

    [Test]
    public void BuildSubmission_ContainsOnlyAnsweredQuestions()
    {
        var state = AtReview();
        state.GoTo(3);
        state.SetText(4, "Great");
        state.Next();

        var submission = state.BuildSubmission();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(submission.SurveyId, Is.EqualTo(7));
            Assert.That(submission.Answers.Select(a => a.QuestionId), Is.EquivalentTo(new[] { 1, 2, 4 }));
            Assert.That(submission.Answers.Single(a => a.QuestionId == 1).NumericValue, Is.EqualTo(4));
            Assert.That(submission.Answers.Single(a => a.QuestionId == 2).OptionIds, Is.EqualTo(new[] { 200 }));
            Assert.That(submission.Answers.Single(a => a.QuestionId == 4).TextValue, Is.EqualTo("Great"));
        }
    }

    [Test]
    public void BuildSubmission_OmitsSkippedQuestions()
    {
        var state = AtReview();

        Assert.That(state.BuildSubmission().Answers.Select(a => a.QuestionId), Is.EquivalentTo(new[] { 1, 2 }));
    }

    [Test]
    public void DescribeAnswer_ReadsBackEachAnswerTypeForTheReviewStep()
    {
        var state = new SurveyDialogState(MixedSurvey());
        state.SetNumber(1, 4);
        state.SelectOption(2, 201);
        state.ToggleOption(3, 300, true);
        state.ToggleOption(3, 302, true);
        state.SetText(4, "Nice");
        state.SetNumber(5, 0);

        var questions = state.Survey.Questions;
        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.DescribeAnswer(questions[0]), Is.EqualTo("4 of 5"));
            Assert.That(state.DescribeAnswer(questions[1]), Is.EqualTo("Projects"));
            Assert.That(state.DescribeAnswer(questions[2]), Is.EqualTo("Community, Articles"));
            Assert.That(state.DescribeAnswer(questions[3]), Is.EqualTo("Nice"));
            Assert.That(state.DescribeAnswer(questions[4]), Is.EqualTo("No"));
        }
    }

    [Test]
    public void DescribeAnswer_SaysSkippedForABlankAnswer()
    {
        var state = new SurveyDialogState(MixedSurvey());

        Assert.That(state.DescribeAnswer(state.Survey.Questions[3]), Is.EqualTo("Skipped"));
    }

    #endregion

    #region Submission

    [Test]
    public void MarkSubmitted_MovesToTheThankYouStep()
    {
        var state = AtReview();

        state.MarkSubmitted();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(state.Step, Is.EqualTo(SurveyStep.Thanks));
            Assert.That(state.ProgressLabel, Is.Empty);
        }
    }

    [Test]
    public void NavigationIsIgnored_OnTheThankYouStep()
    {
        var state = AtReview();
        state.MarkSubmitted();

        state.Back();
        state.Next();

        Assert.That(state.Step, Is.EqualTo(SurveyStep.Thanks));
    }

    #endregion
}
