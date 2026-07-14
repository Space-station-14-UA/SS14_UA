using Content.Server.Discord;
using Content.Server.GameTicking;
using Content.Server.Maps;
using Content.Shared.CCVar;
using Content.Shared.GameTicking;
using Robust.Server;
using Robust.Server.Player;
using Robust.Shared.Configuration;
using Robust.Shared.Utility;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Content.Server.Mriya.Discord;
public sealed partial class DiscordWebhookRoundInfoSystem : EntitySystem
{
    [Dependency] private DiscordWebhook _discord = default!;
    [Dependency] private IConfigurationManager _cfg = default!;
    [Dependency] private GameTicker _ticker = default!;
    [Dependency] private IGameMapManager _gameMapManager = default!;
    [Dependency] private IBaseServer _baseServer = default!;
    [Dependency] private IPlayerManager _playerManager = default!;

    private WebhookIdentifier? _webhookStartId = null;
    private Color _webhookStartEmbedColor;

    private WebhookIdentifier? _webhookEndId = null;
    private Color _webhookEndEmbedColor;
    public override void Initialize()
    {
        base.Initialize();

        _cfg.OnValueChanged(CCVars.DiscordStartRoundStatsWebhook,
            value =>
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _discord.GetWebhook(value, data => _webhookStartId = data.ToIdentifier());
            }, true);

        _cfg.OnValueChanged(CCVars.DiscordStartRoundStatsWebhookColor, value =>
        {
            _webhookStartEmbedColor = Color.LawnGreen;
            if (Color.TryParse(value, out var color))
                _webhookStartEmbedColor = color;
        }, true);

        _cfg.OnValueChanged(CCVars.DiscordEndRoundStatsWebhook,
            value =>
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _discord.GetWebhook(value, data => _webhookEndId = data.ToIdentifier());
            }, true);

        _cfg.OnValueChanged(CCVars.DiscordEndRoundStatsWebhookColor, value =>
        {
            _webhookEndEmbedColor = Color.LawnGreen;
            if (Color.TryParse(value, out var color))
                _webhookEndEmbedColor = color;
        }, true);

        SubscribeLocalEvent<RoundEndMessageEvent>(OnRoundEndMessageEvent);
        SubscribeLocalEvent<GameRunLevelChangedEvent>(OnGameRunLevelChangedEvent);
    }

    private void OnGameRunLevelChangedEvent(GameRunLevelChangedEvent ev)
    {
        if (ev.Old != GameRunLevel.InRound && ev.New == GameRunLevel.InRound)
            SendRoundStartToDiscordWebhook();
    }

    private async Task SendRoundStartToDiscordWebhook()
    {
        if (_webhookStartId is null)
            return;
        var roundId = _ticker.RoundId;
        var playerCount = $"{_ticker.PlayersJoinedRoundNormally}/{_playerManager.PlayerCount}";
        var map = _gameMapManager.GetSelectedMap();
        var preset = _ticker.CurrentPreset ?? _ticker.Preset;
        var gameMode = preset != null ? Loc.GetString(preset.ModeTitle) : "Unknown";

        var now = DateTime.UtcNow;
        var unixTime = ((DateTimeOffset)now).ToUnixTimeSeconds();
        var discordTimestamp = $"<t:{unixTime}:R>";

        var description = Loc.GetString("discord-round-player-count", ("playerCount", playerCount)) + "\n" +
                          Loc.GetString("discord-round-gamemode-name", ("gamemode", gameMode)) + "\n" +
                          Loc.GetString("discord-round-map-name", ("mapName", map?.MapName ?? "Unknown")) + "\n" +
                          Loc.GetString("discord-round-start-at-time", ("timeStamp", discordTimestamp));

        try
        {
            var embed = new WebhookEmbed
            {
                Title = Loc.GetString("discord-round-start-round-id-label", ("roundId", _ticker.RoundId)),
                // There is no need to cut article content. It's MaxContentLength smaller then discord's limit (4096):
                Description = description,
                Color = _webhookStartEmbedColor.ToArgb() & 0xFFFFFF, // HACK: way to get hex without A (transparency)
                Footer = new WebhookEmbedFooter
                {
                    Text = Loc.GetString("discord-round-end-footer",
                        ("server", _baseServer.ServerName),
                        ("round", _ticker.RoundId))
                }
            };
            var payload = new WebhookPayload { Embeds = [embed] };
            await _discord.CreateMessage(_webhookStartId.Value, payload);
            Log.Info("Sent news article to Discord webhook");
        }
        catch (Exception e)
        {
            Log.Error($"Error while sending discord news article:\n{e}");
        }
    }

    private void OnRoundEndMessageEvent(RoundEndMessageEvent ev)
    {
        SendRoundEndStatsToDiscordWebhook(ev);
    }

    private async Task SendRoundEndStatsToDiscordWebhook(RoundEndMessageEvent ev)
    {
        if (_webhookEndId is null)
            return;

        var roundId = _ticker.RoundId;
        var gamemode = ev.GamemodeTitle;
        var allPlayersEndInfo = ev.AllPlayersEndInfo;
        var roundEndText = ev.RoundEndText;
        var roundDuration = ev.RoundDuration;

        var timeRound = Loc.GetString("discord-round-end-duration-label",
                                                   ("hours", roundDuration.Hours),
                                                   ("minutes", roundDuration.Minutes),
                                                   ("seconds", roundDuration.Seconds));

        var rawDesc = timeRound + "\n" + FormattedMessage.RemoveMarkupPermissive(roundEndText);
        var desc = Regex.Replace(rawDesc, @"\n{2,}", "\n").Trim();
        try
        {
            var embed = new WebhookEmbed
            {
                Title = Loc.GetString("discord-round-end-round-id-label", ("roundId", _ticker.RoundId)) + " " + Loc.GetString("discord-round-gamemode-name", ("gamemode", gamemode)),
                // There is no need to cut article content. It's MaxContentLength smaller then discord's limit (4096):
                Description = timeRound + "\n" + FormattedMessage.RemoveMarkupPermissive(roundEndText),
                Color = _webhookEndEmbedColor.ToArgb() & 0xFFFFFF, // HACK: way to get hex without A (transparency)
                Footer = new WebhookEmbedFooter
                {
                    Text = Loc.GetString("discord-round-end-footer",
                        ("server", _baseServer.ServerName),
                        ("round", _ticker.RoundId))
                }
            };
            var payload = new WebhookPayload { Embeds = [embed] };
            await _discord.CreateMessage(_webhookEndId.Value, payload);
            Log.Info("Sent news article to Discord webhook");
        }
        catch (Exception e)
        {
            Log.Error($"Error while sending discord news article:\n{e}");
        }
    }
}
