using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers.Constants;

public static class ChallengePlatformConstants
{
    public static class CodeWars
    {
        public const string BaseUrl = "https://www.codewars.com/";
        public const string KataUrl = $"{BaseUrl}kata/";
        public const string DailyCSharpChallengeUrl = $"{KataUrl}csharp";
        public const string DailySQLChallengeUrl = $"{KataUrl}sql";
        public const string ChallengeApiUrl = $"{BaseUrl}api/v1/code-challenges/";

        public static readonly ChallengeCategory[] SupportedCategories =
        [
            ChallengeCategory.CSharp,
            ChallengeCategory.SQL
        ];
    }

    public static class LeetCode
    {
        public const string BaseUrl = "https://leetcode.com/";
        public const string ProblemsUrl = $"{BaseUrl}problems/";
        public const string GraphQLEndpoint = $"{BaseUrl}graphql";

        public static class Queries
        {
            public const string GetRecentSubmissions = """
                query($username: String!) {
                    recentAcSubmissionList(username: $username) {
                        title
                        titleSlug
                        statusDisplay
                    }
                }
                """;

            public const string GetDailyChallenge = """
                query getDailyProblem {
                    activeDailyCodingChallengeQuestion {
                        date
                        question {
                            title
                            titleSlug
                            difficulty
                            isPaidOnly
                            content
                            topicTags { name slug }
                        }
                    }
                }
                """;
        }
    }
}
