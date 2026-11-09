namespace TCSA.V2026.Data.DTOs;

public class FeedbackOverviewDto
{
    public int ResponsesLastSevenDays { get; set; }
    public int ActiveSurveys { get; set; }
    public int ReviewQueueSize { get; set; }
    public List<FeedbackAdminItemDto> RecentItems { get; set; } = [];
    public List<FeedbackClusterDto> TopClusters { get; set; } = [];
}
