namespace TCSA.V2026.Data.Models.Responses;

public record LeetCodeDailyResult(LeetCodeDailyQuestion? ActiveDailyCodingChallengeQuestion);

public record LeetCodeDailyQuestion(string Date, LeetCodeDailyProblem Question);

public record LeetCodeTopicTag(string Name, string Slug);

public record LeetCodeDailyProblem(
    string Title,
    string TitleSlug,
    string Difficulty,
    bool IsPaidOnly,
    string Content,
    IReadOnlyCollection<LeetCodeTopicTag> TopicTags);
