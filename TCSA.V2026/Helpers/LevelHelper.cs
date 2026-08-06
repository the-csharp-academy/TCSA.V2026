using TCSA.V2026.Data.Enums;

namespace TCSA.V2026.Helpers;

public static class LevelHelper
{
    public static string FormatBelt(Level level) =>
        level == Level.OliveGreen ? "Olive Green Belt" : $"{level} Belt";
}
