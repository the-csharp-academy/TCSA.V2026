using NetCord.Gateway;
using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Helpers.Constants;

namespace TCSA.V2026.Services;

public interface IDiscordService
{
    Task<bool> ChangeDiscordBelt(string discordAlias, Level newBelt);
}

public class DiscordService : IDiscordService
{
    private const ulong _guildId = 925901888203935744;
    private const ulong _channelId = 925901888203935747;
    private static readonly Random _random = new();
    private readonly GatewayClient _client;

    public DiscordService(GatewayClient client)
    {
        _client = client;
    }

    public async Task<bool> ChangeDiscordBelt(string discordAlias, Level newBelt)
    {
        try
        {
            await _client.RequestGuildUsersAsync(new GuildUsersRequestProperties(_guildId));

            var user = _client.Cache.Guilds[_guildId].Users.Values.FirstOrDefault(u => u.Nickname == discordAlias || u.Username == discordAlias);

            if (user is null)
            {
                return false;
            }

            foreach (var role in user.RoleIds)
            {
                await user.RemoveRoleAsync(role);
            }

            var newRole = GetNewRoleId(newBelt);

            if (newRole == 0)
            {
                return false;
            }

            await user.AddRoleAsync(newRole);

            await _client.Rest.SendMessageAsync(_channelId, $"<@{user.Id}> congratulations! You got your {(newBelt == Level.OliveGreen ? "Olive Green" : newBelt)} belt!  :tada:");

            var gif = GetRandomGif(newBelt);

            if (string.IsNullOrWhiteSpace(gif))
            {
                return false;
            }

            await _client.Rest.SendMessageAsync(_channelId, $"{gif}");

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

    }

    private static ulong GetNewRoleId(Level belt)
    {
        return belt switch
        {
            Level.Green => DiscordRoles.Green,
            Level.OliveGreen => DiscordRoles.OliveGreen,
            Level.Yellow => DiscordRoles.Yellow,
            Level.Orange => DiscordRoles.Orange,
            Level.Red => DiscordRoles.Red,
            Level.Purple => DiscordRoles.Purple,
            Level.Brown => DiscordRoles.Brown,
            Level.Grey => DiscordRoles.Grey,
            Level.Blue => DiscordRoles.Blue,
            Level.Black => DiscordRoles.Black,
            _ => 0
        };
    }

    private static string GetRandomGif(Level belt)
    {

        var gifs = belt switch
        {
            Level.Green => BeltGifs.Green,
            Level.OliveGreen => BeltGifs.OliveGreen,
            Level.Yellow => BeltGifs.Yellow,
            Level.Orange => BeltGifs.Orange,
            Level.Red => BeltGifs.Red,
            Level.Purple => BeltGifs.Purple,
            Level.Brown => BeltGifs.Brown,
            Level.Grey => BeltGifs.Grey,
            Level.Blue => BeltGifs.Blue,
            Level.Black => BeltGifs.Black,
            _ => []
        };

        if (gifs.Count == 0)
        {
            return string.Empty;
        }

        var index = _random.Next(gifs.Count);

        return gifs[index];
    }
}
