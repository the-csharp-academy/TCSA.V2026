# The C# Academy

Welcome to The C# Academy!

This repository contains the source code that powers our learning community and also serves as a collaborative space for developers of all skill levels.

The C# Academy website is more than just a learning platform - it's a living project where community members can practice real-world development skills. By contributing to this codebase, you'll experience what it's like to work on a production application maintained by multiple developers.

## 🛠️ Getting Started

### Community Issues

1. Request to be added as a contributor in [Community Project](https://discord.com/channels/925901888203935744/1045222886375444520) discord channel

2. Read [Contributing to The C# Academy](https://thecsharpacademy.com/article/30008/contributing-csharp-academy) article.

3. Browse the **Community Issues** or create a new **Community Issue** in [The C# Academy's Github Project](https://github.com/users/TheCSharpAcademy/projects/23)

   - Assign yourself to the issue
   - Create a new branch for your issue

4. Submit a new **Issue** (if one doesn't already exist) in **Community** section of [The C# Academy's Website](https://www.thecsharpacademy.com/dashboard/community)

   - Select the project.
   - Select the issue type.
   - Enter the issue Title from previous step.
   - Enter the issue URL from previous step.
   - Submit.

### Installation Prerequisites

- An IDE (code editor) like **Visual Studio** or **Visual Studio Code**.
- The **.NET 10** SDK.
- An **SQL Server** installation (Developer, Express, Docker Container. See note below if you don't have SQL Server installed).
- A database management tool like **SQL Server Management Studio** or **DBeaver** (optional, only required if you need to run the `GetRanking` stored procedure).

> [!TIP]
> Don't have SQL Server installed, or on Linux/Mac where LocalDB isn't available? The easiest option is running SQL Server in a Docker container:
> ```
> docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=AStrong!Passw0rd" -e "MSSQL_PID=Evaluation" -p 1433:1433 --name tcsa-sql -d mcr.microsoft.com/mssql/server:2025-latest
> ```
> Then use a connection string like this instead of the LocalDB one below:
> ```
> Server=localhost,1433;Database=TCSA_V2026;User Id=sa;Password=AStrong!Passw0rd;TrustServerCertificate=True;
> ```

### Installation Steps

> [!NOTE]
> The following steps are examples for terminal/command prompt.
>
> You may need to adjust them based on your specific operating system and environment.

1. Clone the repository:

   - `git clone https://github.com/TheCSharpAcademy/TCSA.V2026.git`

2. Navigate to the application project directory:

   - `cd TCSA.V2026/TCSA.V2026`

3. Create an `appsettings.json` file:

   - Windows: `notepad appsettings.json`
   - Linux/Mac: `touch appsettings.json && nano appsettings.json`

4. Paste the following, adjust any values specific to your environment. Save and close.

```json
{
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB; Initial Catalog=TCSA_V2026; Integrated Security=true;"
    },
    "Logging": {
        "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
        }
    },
    "Values": {
        "GithubClientId": "abc123",
        "GithubClientSecret": "abc123"
    },
    "Discord": {
        "Token": "ODAzMzc3MjcwODc4MTA5NzI2.ThisIsNot.ARealDiscordToken"
  }
}
```

> [!Tip]
> Replace `DefaultConnection` with your own connection string.
>
> If you want to login via GitHub, replace `GithubClientId` and `GithubClientSecret` with your own values.
>
> **Github Docs**: [Creating an OAuth app](https://docs.github.com/en/apps/oauth-apps/building-oauth-apps/creating-an-oauth-app)
>
> The `Discord:Token` and GitHub values just need to be non-empty strings to satisfy startup validation. They don't need to be real credentials unless you're testing GitHub login or Discord bot features.

5. Open the solution `TCSA.V2026.sln`.

6. Go to `Program.cs` and uncomment the following lines:

```
if (app.Environment.IsDevelopment())
{
    SeedData.Seed(app.Services);
}
```

> [!Note]
> After running the application you can comment out these lines again to avoid database recreation on every startup.
>
> Make sure to repeat this step when database schema changes or new seeding data is added.

7. Run the project.

    - `dotnet run`

8. Login as fake user

   - You can find several fake users in `Data/SeedData.cs`
   - Below is login info from a seeded user with Orange belt and 1000 XP points:

```plaintext
Username: user1@example.com
Password: Password123!
```

#### GetRanking Store Procedure

> [!IMPORTANT]  
> This stored procedure must be created if you want to access the leaderboard pages.
>
> Use your database management tool of choice and ensure you are connected to the correct database before running the below script.

```
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRanking]
    @userId NVARCHAR(450),
    @ranking INT OUTPUT
AS
BEGIN
    DECLARE @userExperiencePoints INT;

    -- Get the user's experience points based on the provided user ID
    SELECT @userExperiencePoints = [ExperiencePoints]
    FROM [AspNetUsers]
    WHERE [Id] = @userId;

    -- Calculate the user's ranking
    SELECT @ranking = COUNT(*) + 1
FROM [AspNetUsers]
WHERE [ExperiencePoints] > @userExperiencePoints
   OR ([ExperiencePoints] = @userExperiencePoints AND (
       [FirstName] < (SELECT [FirstName] FROM [AspNetUsers] WHERE [Id] = @userId) OR
       ([FirstName] = (SELECT [FirstName] FROM [AspNetUsers] WHERE [Id] = @userId) AND [LastName] < (SELECT [LastName] FROM [AspNetUsers] WHERE [Id] = @userId))
   ));
END;
GO
```

## 🧪 Testing

### End-to-End Testing with Playwright

This project uses Playwright for end-to-end testing. Before running the tests, you need to install the Playwright browsers.

#### Installing Playwright Browsers

```
cd TCSA.V2026.EndToEndTests
pwsh bin/Debug/net10.0/playwright.ps1 install
```

> [!NOTE]
> This command needs to be run after building the test project for the first time.
