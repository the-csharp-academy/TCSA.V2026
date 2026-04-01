namespace TCSA.V2026.Data.Models.Responses;

public record GraphQLResponse<T>(T? Data, List<GraphQLError>? Errors);

public record GraphQLError(string? Message);

public record RecentSubmissionResult(IReadOnlyCollection<RecentSubmission> RecentAcSubmissionList);

public record RecentSubmission(string Title, string TitleSlug, string StatusDisplay);
