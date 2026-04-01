namespace TCSA.V2026.Helpers.Constants;

public static class ChallengePlatformConstants
{
    public static class CodeWars
    {
        public const string BaseUrl = "https://www.codewars.com/";
        public const string KataUrl = $"{BaseUrl}kata/";
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
        }
    }
}
