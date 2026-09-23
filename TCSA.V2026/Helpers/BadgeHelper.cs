using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Helpers;

public record BadgeTierDefinition(BadgeId Id, string Title, string ImageUrl, string Requirement);

public record BadgeFamilyDefinition(List<BadgeTierDefinition> Tiers);

public static class BadgeHelper
{
    public static readonly List<BadgeFamilyDefinition> Families = new()
    {
        new(new()
        {
            new(BadgeId.PlatformBuilder, "Platform Builder", "img/Badges/contributor_badge_tier1.svg",
                "Get a pull request merged into one of the platform's community projects"),
            new(BadgeId.PlatformContributor, "Platform Contributor", "img/Badges/contributor_badge_tier2.svg",
                "Get 10 pull requests merged into the platform's community projects"),
            new(BadgeId.PlatformArchitect, "Platform Architect", "img/Badges/contributor_badge_tier3.svg",
                "Get 20 pull requests merged into the platform's community projects"),
        }),
        new(new()
        {
            new(BadgeId.CodeReviewer, "Code Reviewer", "img/Badges/code_review_badge_tier1.svg",
                "Complete your first peer review"),
            new(BadgeId.TrustedReviewer, "Trusted Reviewer", "img/Badges/code_review_badge_tier2.svg",
                "Complete 25 peer reviews"),
            new(BadgeId.MasterReviewer, "Master Reviewer", "img/Badges/code_review_badge_tier3.svg",
                "Complete 100 peer reviews"),
        }),
    };
}
