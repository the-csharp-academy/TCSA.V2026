using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Options;
using MudBlazor;
using MudBlazor.Services;
using NetCord.Gateway;
using NetCord.Hosting.Gateway;
using Stripe;
using TCSA.V2026.Components;
using TCSA.V2026.Components.Account;
using TCSA.V2026.Data;
using TCSA.V2026.Data.Helpers;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.Options;
using TCSA.V2026.Services;
using TCSA.V2026.Services.Challenges;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<LinksOptions>(builder.Configuration.GetSection("Links"));
builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection("Stripe"));
builder.Services.Configure<FeatureToggleOptions>(builder.Configuration.GetSection("FeatureToggle"));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddHybridCache();

builder.Services.AddSingleton<IStripeClient>(sp =>
{
    var stripeOptions = sp.GetRequiredService<IOptions<StripeOptions>>().Value;

    return new StripeClient(stripeOptions.ApiKey);
});

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();
builder.Services.AddScoped<IPeerReviewService, PeerReviewService>();
builder.Services.AddScoped<ICommunityService, CommunityService>();
builder.Services.AddScoped<IChallengeService, ChallengeService>();
builder.Services.AddScoped<ICodewarsService, CodewarsService>();
builder.Services.AddKeyedScoped<IChallengePlatformService, CodewarsService>(ChallengePlatform.CodeWars);
builder.Services.AddKeyedScoped<IChallengePlatformService, LeetCodeService>(ChallengePlatform.LeetCode);
builder.Services.AddScoped<IChallengePlatformFactory, ChallengePlatformFactory>();
builder.Services.AddScoped<ChallengeManager>();
builder.Services.AddScoped<IDiscordService, DiscordService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IGithubService, GithubService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<StatisticsService>();
builder.Services.AddScoped<IStatisticsService>(sp =>
{
    return new CachingStatisticsService(
        sp.GetRequiredService<StatisticsService>(),
        sp.GetRequiredService<HybridCache>()
    );
});
builder.Services.AddScoped<IFeedService, FeedService>();
builder.Services.AddScoped<IAccountabilityBuddyService, AccountabilityBuddyService>();
builder.Services.AddScoped<IDonateService, DonateService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ICustomEmailSender, EmailSender>();

builder.Services.AddControllers();


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ThemeService>();

builder.Services.AddDiscordGateway(options =>
{
    options.Intents = GatewayIntents.Guilds | GatewayIntents.GuildUsers | GatewayIntents.GuildPresences | GatewayIntents.GuildMessages;
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddGitHub(o =>
    {
        o.ClientId = builder.Configuration["Values:GithubClientId"];
        o.ClientSecret = builder.Configuration["Values:GithubClientSecret"];
        o.CallbackPath = "/signin-github";
    https://docs.github.com/en/developers/apps/building-oauth-apps/scopes-for-oauth-apps
        o.Scope.Add("read:user");
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("?? Application has started and logging is working!");

ServiceProviderAccessor.ServiceProvider = app.Services;

//if (app.Environment.IsDevelopment())
//{
//    await SeedData.Seed(app.Services);
//}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapRazorPages();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();