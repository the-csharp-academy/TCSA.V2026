namespace TCSA.V2026.Helpers.Constants;

public static class FeedbackLimits
{
    public const int DescriptionMinLength = 5;
    public const int DescriptionMaxLength = 2000;
    public const int PageMaxLength = 200;
    public const int OriginUrlMaxLength = 500;
    public const int RateLimitMaxSubmissions = 5;
    public static readonly TimeSpan RateLimitWindow = TimeSpan.FromMinutes(10);
}
