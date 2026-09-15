namespace TCSA.V2026.Helpers;

public static class LeaderboardHelper
{
    public static string GetRanking(long ranking)
    {
        long lastTwoDigits = 0;
        long lastDigit = 0;

        if (ranking < 100)
        {
            lastTwoDigits = ranking;
            lastDigit = ranking % 10;
        }
        else if (ranking > 100 && ranking < 1000)
        {
            lastTwoDigits = ranking % 100;
            lastDigit = ranking % 10;
        }
        else if (ranking > 1000 && ranking < 10000)
        {
            lastTwoDigits = ranking % 100;
            lastDigit = ranking % 1000;
        }
        else if (ranking > 1000)
        {
            lastTwoDigits = ranking % 1000;
            lastDigit = ranking % 10000;
        }

        if (lastTwoDigits >= 11 && lastTwoDigits <= 13)
        {
            return $"{ranking}th";
        }

        switch (lastDigit)
        {
            case 1:
                return $"{ranking}st";
            case 2:
                return $"{ranking}nd";
            case 3:
                return $"{ranking}rd";
            default:
                return $"{ranking}th";
        }
    }
}
