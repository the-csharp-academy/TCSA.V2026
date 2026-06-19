using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;

namespace TCSA.V2026.Helpers;

public static class EmailHelper
{
    public static string GetProjectCompletedBody(string firstName, string title, int experiencePoints, string rankingText)
    {
        return @$"Hello <b>{firstName}</b> 👋<p><p>
🎉 Well done! We have just reviewed and approved your <b>{title}</b> project. 🏆<p><p>
You've gained <b>{experiencePoints}</b> Experience Points and moved to the <b>{rankingText}</b> position on our leaderboard. 📈<p>
Don't forget that marking our articles as read also gives you experience points! 📝<p><p>
🚀 Keep up the great work!<p><p>
<b>The C# Academy Team</b>"; ;
    }

    public static string GetNewBeltBody(string firstName, string title, Level level)
    {
        var icon = level switch
        {
            Level.Green => "📗💚🟩",
            Level.OliveGreen => "🫒🫒🫒",
            Level.Yellow => "💛⭐🟡",
            Level.Orange => "📙🍊🧡",
            Level.Red => "🔴❤️🍎",
            Level.Purple => "💜🟣🟪",
            Level.Brown => "🤎🟤🟫",
            Level.Grey => "🩶🩶🩶",
            Level.Blue => "📘💙🔵",
            Level.Black => "🎩⚫🖤"
        };

        return @$"Hello <b>{firstName}</b> 👋<p><p>
🎉 Well done! You have completed all necessary tasks and achieved <b>{level.ToString()} belt! {icon}</b>. 🏆<p><p>
🚀 Keep up the great work!<p><p>
<b>The C# Academy Team</b>"; ;
    }
}
