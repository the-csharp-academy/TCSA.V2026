using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Helpers.SurveyQuestions;

namespace TCSA.V2026.Components.UI;

public enum SurveyStep
{
    Intro,
    Question,
    Review,
    Thanks
}

public class SurveyDialogState
{
    private readonly Dictionary<int, SurveyAnswerDto> _answers = [];
    private int _questionIndex;
    private bool _returnToReview;

    public SurveyDialogState(AvailableSurveyDto survey)
    {
        Survey = survey;
    }

    public AvailableSurveyDto Survey { get; }

    public SurveyStep Step { get; private set; } = SurveyStep.Intro;

    public int QuestionCount => Survey.Questions.Count;

    public SurveyQuestionDto? CurrentQuestion => Step == SurveyStep.Question ? Survey.Questions[_questionIndex] : null;

    public int QuestionNumber => _questionIndex + 1;

    public string ProgressLabel => Step == SurveyStep.Question ? $"{QuestionNumber} of {QuestionCount}" : string.Empty;

    public double ProgressPercent => Step == SurveyStep.Question ? 100.0 * QuestionNumber / QuestionCount : 0;

    public bool NeedsAnswer => CurrentQuestion is { IsRequired: true } question && !IsAnswered(question);

    public bool CanAdvance => Step == SurveyStep.Intro || (Step == SurveyStep.Question && !NeedsAnswer);

    public bool CanSkip => CurrentQuestion is { IsRequired: false } question && !IsAnswered(question);

    public IReadOnlyList<SurveyQuestionDto> MissingRequired =>
        [.. Survey.Questions.Where(q => q.IsRequired && !IsAnswered(q))];

    public bool CanSubmit => Step == SurveyStep.Review && MissingRequired.Count == 0;

    public void Start()
    {
        if (Step != SurveyStep.Intro) return;

        Step = SurveyStep.Question;
        _questionIndex = 0;
    }

    public void Next()
    {
        if (Step == SurveyStep.Intro)
        {
            Start();
            return;
        }

        if (Step != SurveyStep.Question || NeedsAnswer) return;

        if (_returnToReview || _questionIndex == QuestionCount - 1)
        {
            ShowReview();
        }
        else
        {
            _questionIndex++;
        }
    }

    public void Skip()
    {
        if (CanSkip)
        {
            Next();
        }
    }

    public void Back()
    {
        switch (Step)
        {
            case SurveyStep.Question when _questionIndex == 0:
                Step = SurveyStep.Intro;
                _returnToReview = false;
                break;
            case SurveyStep.Question:
                _questionIndex--;
                _returnToReview = false;
                break;
            case SurveyStep.Review:
                Step = SurveyStep.Question;
                _questionIndex = QuestionCount - 1;
                break;
        }
    }

    public void GoTo(int questionIndex)
    {
        if (Step != SurveyStep.Review || questionIndex < 0 || questionIndex >= QuestionCount) return;

        Step = SurveyStep.Question;
        _questionIndex = questionIndex;
        _returnToReview = true;
    }

    public void MarkSubmitted() => Step = SurveyStep.Thanks;

    public SurveyAnswerDto AnswerOrBlank(int questionId) =>
        _answers.GetValueOrDefault(questionId) ?? new SurveyAnswerDto { QuestionId = questionId };

    public bool IsAnswered(SurveyQuestionDto question) =>
        SurveyQuestionRegistry.IsAnswered(question.Type, _answers.GetValueOrDefault(question.Id));

    public void SetNumber(int questionId, int value) => EditableAnswer(questionId).NumericValue = value;

    public void ClearNumber(int questionId) => EditableAnswer(questionId).NumericValue = null;

    public void SetText(int questionId, string? value) => EditableAnswer(questionId).TextValue = value;

    public void SelectOption(int questionId, int optionId) => EditableAnswer(questionId).OptionIds = [optionId];

    public void ToggleOption(int questionId, int optionId, bool selected)
    {
        var options = EditableAnswer(questionId).OptionIds;

        if (selected && !options.Contains(optionId))
        {
            options.Add(optionId);
        }
        else if (!selected)
        {
            options.Remove(optionId);
        }
    }

    public SurveySubmissionDto BuildSubmission() => new()
    {
        SurveyId = Survey.Id,
        Answers = [.. Survey.Questions.Where(IsAnswered).Select(q => AnswerOrBlank(q.Id))]
    };

    public string DescribeAnswer(SurveyQuestionDto question)
    {
        if (!IsAnswered(question)) return "Skipped";

        return SurveyQuestionRegistry.Get(question.Type).DescribeAnswer(question, AnswerOrBlank(question.Id));
    }

    private void ShowReview()
    {
        Step = SurveyStep.Review;
        _returnToReview = false;
    }

    private SurveyAnswerDto EditableAnswer(int questionId)
    {
        if (!_answers.TryGetValue(questionId, out var answer))
        {
            answer = new SurveyAnswerDto { QuestionId = questionId };
            _answers[questionId] = answer;
        }

        return answer;
    }
}
