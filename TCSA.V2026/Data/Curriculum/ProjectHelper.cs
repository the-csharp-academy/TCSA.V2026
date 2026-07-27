using TCSA.V2026.Data.Curriculum.ProjectsSubHelpers;
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
        .. SystemDesignProjectHelper.GetProjects(),
    ];

    private static readonly List<ShowcaseProjectInfo> _allProjectInfos = [.. _allProjects.Select(project => new ShowcaseProjectInfo
    {
        Id = project.Id,
        Title = project.Title,
        Area = project.Area,
    })];

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
}
