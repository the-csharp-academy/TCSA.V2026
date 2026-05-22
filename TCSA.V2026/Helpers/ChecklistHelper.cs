using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class ChecklistHelper
{
    public static List<ChecklistTaskDto> BuildProfileTasks(ApplicationUser user)
    {
        return
        [
            new() {
                Label = "Add a Display Name",
                IsCompleted = !string.IsNullOrWhiteSpace(user.DisplayName),
                NavigationUrl = "/dashboard/profile",
                NavigationUrlLabel = "Go to Profile"
            },
            new() {
                Label = "Add Discord Alias",
                IsCompleted = !string.IsNullOrWhiteSpace(user.DiscordAlias),
                NavigationUrl = "/dashboard/profile",
            },
            new() {
                Label = "Add LinkedIn URL",
                IsCompleted = !string.IsNullOrWhiteSpace(user.LinkedInUrl),
                NavigationUrl = "/dashboard/profile",
                NavigationUrlLabel = "Go to Profile"
            },
            new() {
                Label = "Add GitHub Username",
                IsCompleted = !string.IsNullOrWhiteSpace(user.GithubUsername),
                NavigationUrl = "/dashboard/profile",
                NavigationUrlLabel = "Go to Profile"
            },
            new() {
                Label = "Add CodeWars Username",
                IsCompleted = !string.IsNullOrWhiteSpace(user.CodeWarsUsername),
                NavigationUrl = "/dashboard/profile",
                NavigationUrlLabel = "Go to Profile"
            },
            new() {
                Label = "Add LeetCode Username",
                IsCompleted = !string.IsNullOrWhiteSpace(user.LeetCodeUsername),
                NavigationUrl = "/dashboard/profile",
                NavigationUrlLabel = "Go to Profile"
            },
        ];
    }
}
