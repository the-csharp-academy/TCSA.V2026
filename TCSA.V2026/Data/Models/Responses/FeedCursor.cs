using System.Text;
using System.Text.Json;

namespace TCSA.V2026.Data.Models.Responses;

public record FeedCursor(DateTimeOffset Date, string UserId)
{
    public static string Encode(DateTimeOffset Date, string UserId)
    {
        var cursor = new FeedCursor(Date, UserId);
        var json = JsonSerializer.Serialize(cursor);
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
    }

    public static FeedCursor? Decode(string? cursor)
    {
        if (string.IsNullOrEmpty(cursor)) return null;

        try
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(cursor));
            return JsonSerializer.Deserialize<FeedCursor>(json);
        }
        catch
        {
            return null;
        }
    }
}
