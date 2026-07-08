using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

public sealed partial class CCVars
{
    // Height width
    /// <summary>
    ///     Whether height & width sliders adjust a character's Fixture Component
    /// </summary>
    public static readonly CVarDef<bool> HeightAdjustModifiesHitbox =
        CVarDef.Create("heightadjust.modifies_hitbox", true, CVar.SERVERONLY);
    /// <summary>
    ///     Whether height & width sliders adjust a player's max view distance
    /// </summary>
    public static readonly CVarDef<bool> HeightAdjustModifiesZoom =
        CVarDef.Create("heightadjust.modifies_zoom", true, CVar.SERVERONLY);

    public static readonly CVarDef<string> DiscordEndRoundStatsWebhook =
        CVarDef.Create("discord.end_round_stats_webhook", string.Empty, CVar.SERVERONLY);

    /// <summary>
    ///     HEX color of end round stats discord webhook's embed.
    /// </summary>
    public static readonly CVarDef<string> DiscordEndRoundStatsWebhookColor =
        CVarDef.Create("discord.end_round_stats_webhook_embed_color", Color.LightBlue.ToHex(), CVar.SERVERONLY);


    public static readonly CVarDef<string> DiscordStartRoundStatsWebhook =
        CVarDef.Create("discord.start_round_stats_webhook", string.Empty, CVar.SERVERONLY);

    /// <summary>
    ///     HEX color of end round stats discord webhook's embed.
    /// </summary>
    public static readonly CVarDef<string> DiscordStartRoundStatsWebhookColor =
        CVarDef.Create("discord.start_round_stats_webhook_embed_color", Color.LawnGreen.ToHex(), CVar.SERVERONLY);
}
