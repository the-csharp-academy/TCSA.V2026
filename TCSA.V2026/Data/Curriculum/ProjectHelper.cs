using TCSA.V2026.Data.DTOs;
using TCSA.V2026.Data.Helpers.ProjectsSubHelpers;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Data.Curriculum;

public static class ProjectHelper
{
    private static readonly List<Project> _allProjects = [
        .. StandAloneProjectsHelper.GetProjects(),
        .. ConsoleProjectsHelper.GetProjects(),
        .. StartApplyingProjectsHelper.GetProjects(),
        .. MVCProjectsHelper.GetProjects(),
        .. AngularProjectsHelper.GetProjects(),
        .. BlazorProjectsHelper.GetProjects(),
        .. ReactProjectsHelper.GetProjects(),
        .. SqlProjectsHelper.GetProjects(),
        .. AuthProjectsHelper.GetProjects(),
        .. AzureProjectsHelper.GetProjects(),
        .. MauiProjectsHelper.GetProjects(),
        .. ChallengeProjectsHelper.GetProjects(),
        .. OpenSourceProjectsHelper.GetProjects(),
        .. DockerProjectsHelper.GetProjects(),
    ];

    private static readonly List<ShowcaseProjectInfo> _allProjectInfos = [.. _allProjects.Select(project => new ShowcaseProjectInfo
    {
        Id = project.Id,
        Title = project.Title,
        Area = project.Area,
    })];

    private static readonly List<Project> _allProjectsInPortuguese = [
        .. StandAloneProjectsHelper.GetProjectsInPortuguese(),
        .. ConsoleProjectsHelper.GetProjectsInPortuguese(),
    ];

    private static readonly List<Project> _allProjectsInDutch = [
        .. StandAloneProjectsHelper.GetProjectsInDutch(),
        .. ConsoleProjectsHelper.GetProjectsInDutch(),
    ];

    private static readonly List<Project> _allProjectsInTurkish = [
        .. StandAloneProjectsHelper.GetProjectsInTurkish(),
        .. ConsoleProjectsHelper.GetProjectsInTurkish(),
    ];

    private static readonly List<Project> _allProjectsInTraditionalChinese = [
        .. StandAloneProjectsHelper.GetProjectsInTraditionalChinese(),
    ];

    private static readonly List<Project> _allProjectsInKorean = [
        .. StandAloneProjectsHelper.GetProjectsInKorean(),
        .. ConsoleProjectsHelper.GetProjectsInKorean(),
    ];

    private static readonly List<Project> _allProjectsInCroatian = [
        .. StandAloneProjectsHelper.GetProjectsInCroatian(),
    ];

    private static readonly List<Project> _allProjectsInRussian = [
        .. StandAloneProjectsHelper.GetProjectsInRussian(),
        .. ConsoleProjectsHelper.GetProjectsInRussian(),
    ];

    private static readonly List<Project> _allProjectsInPolish = [
        .. StandAloneProjectsHelper.GetProjectsInPolish(),
    ];

    public static List<Project> GetProjects() => _allProjects;

    public static string GetProjectIconUrl(int? projectId)
    {
        var project = _allProjects.FirstOrDefault(p => p.Id == projectId);
        return project != null ? project.IconUrl : string.Empty;
    }

    public static string GetProjectName(int? projectId)
    {
        var project = _allProjects.FirstOrDefault(p => p.Id == projectId);
        return project != null ? project.Title : string.Empty;
    }

    public static List<ShowcaseProjectInfo> GetProjectInfos() => _allProjectInfos;

    public static List<Project> GetProjectsInPortuguese() => _allProjectsInPortuguese;

    public static List<Project> GetProjectsInDutch() => _allProjectsInDutch;

    public static List<Project> GetProjectsInTurkish() => _allProjectsInTurkish;

    public static List<Project> GetProjectsInTraditionalChinese() => _allProjectsInTraditionalChinese;

    public static List<Project> GetProjectsInKorean() => _allProjectsInKorean;

    public static List<Project> GetProjectsInCroatian() => _allProjectsInCroatian;

    public static List<Project> GetProjectsInRussian() => _allProjectsInRussian;

    public static List<Project> GetProjectsInPolish() => _allProjectsInPolish;
}
