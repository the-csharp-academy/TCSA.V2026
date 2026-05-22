using System.Text.Json.Serialization;

namespace TCSA.V2026.Data.DTOs;

public class PullRequestDto
{
    public string Action { get; set; }

    public Repository Repository { get; set; }

    [JsonPropertyName("pull_request")]
    public PullRequest PullRequest { get; set; }
}

public class PullRequestReviewDto
{
    public string Action { get; set; }

    public Repository Repository { get; set; }

    public Review Review { get; set; }


    [JsonPropertyName("pull_request")]
    public PullRequest PullRequest { get; set; }

}

public class PullRequest
{
    public int Number { get; set; }

    public User User { get; set; }


    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; set; }
}

public class Repository
{
    public long Id { get; set; }

}

public class User
{
    public string Login { get; set; }
}

public class Review
{
    public string State { get; set; }
}
