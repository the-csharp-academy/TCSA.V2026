namespace TCSA.V2026.Helpers.Constants;

public static class ContentAnchors
{
    #region Article Anchors
    public const string ArticleTitleId = "article-title";
    public const string ProjectRequirementsIntroId = "project-requirements-intro";
    public const string ProjectRequirementsConclusionId = "project-requirements-conclusion";
    public const string ProjectLearningIntroId = "project-learning-intro";
    public const string ProjectResourcesIntroId = "project-resources-intro";
    public const string ProjectResourcesConclusionId = "project-resources-conclusion";
    #endregion

    #region Dynamic Article Anchors
    public static string ArticleBlockTitleId(int blockIndex) => $"article-block-title-{blockIndex}";
    public static string ArticleBlockParagraphId(int blockIndex, int paragraphIndex) => $"article-block-{blockIndex}-paragraph-{paragraphIndex}";
    public static string ProjectRequirementId(int requirementIndex) => $"project-requirement-{requirementIndex}";
    public static string ProjectResourceId(int resourceIndex) => $"project-resource-{resourceIndex}";
    public static string ProjectTipId(int tipIndex) => $"project-tip-{tipIndex}";
    public static string ProjectChallengeId(int challengeIndex) => $"project-challenge-{challengeIndex}";
    public static string ProjectLearningItemId(int learningItemIndex) => $"project-learning-item-{learningItemIndex}";
    public static string ProjectIntroductionParagraphId(int paragraphIndex) => $"project-introduction-paragraph-{paragraphIndex}";
    #endregion
}
