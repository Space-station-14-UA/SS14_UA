using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Content.Shared.CCVar;
using Robust.Shared.Configuration;

namespace Content.Server.Chat.Managers;

/// <summary>
///     Sanitizes messages!
///     It currently ony removes the shorthands for emotes (like "lol" or "^-^") from a chat message and returns the last
///     emote in their message
/// </summary>
public sealed partial class ChatSanitizationManager : IChatSanitizationManager
{
    private static readonly (Regex regex, string emoteKey)[] ShorthandToEmote =
    [
        Entry(":)", "chatsan-smiles"),
        Entry(":]", "chatsan-smiles"),
        Entry("=)", "chatsan-smiles"),
        Entry("=]", "chatsan-smiles"),
        Entry("(:", "chatsan-smiles"),
        Entry("[:", "chatsan-smiles"),
        Entry("(=", "chatsan-smiles"),
        Entry("[=", "chatsan-smiles"),
        Entry("^^", "chatsan-smiles"),
        Entry("^-^", "chatsan-smiles"),
        Entry(":(", "chatsan-frowns"),
        Entry(":[", "chatsan-frowns"),
        Entry("=(", "chatsan-frowns"),
        Entry("=[", "chatsan-frowns"),
        Entry("):", "chatsan-frowns"),
        Entry(")=", "chatsan-frowns"),
        Entry("]:", "chatsan-frowns"),
        Entry("]=", "chatsan-frowns"),
        Entry(":D", "chatsan-smiles-widely"),
        Entry("D:", "chatsan-frowns-deeply"),
        Entry(":Д", "chatsan-smiles-widely"), // Sich
        Entry("Д:", "chatsan-frowns-deeply"), // Sich
        Entry(":O", "chatsan-surprised"),
        Entry(":О", "chatsan-surprised"), // Sich
        Entry("!", "chatsan-surprised"), // Sich
        Entry(":3", "chatsan-smiles"),
        Entry(":з", "chatsan-smiles"), // Sich
        Entry(":S", "chatsan-uncertain"),
        Entry(":>", "chatsan-grins"),
        Entry(":<", "chatsan-pouts"),
        Entry("xD", "chatsan-laughs"),
        Entry("хД", "chatsan-laughs"), // Sich
        Entry(":'(", "chatsan-cries"),
        Entry(":'[", "chatsan-cries"),
        Entry("='(", "chatsan-cries"),
        Entry("='[", "chatsan-cries"),
        Entry(")':", "chatsan-cries"),
        Entry("]':", "chatsan-cries"),
        Entry(")'=", "chatsan-cries"),
        Entry("]'=", "chatsan-cries"),
        Entry(";-;", "chatsan-cries"),
        Entry(";_;", "chatsan-cries"),
        Entry("qwq", "chatsan-cries"),
        Entry(":u", "chatsan-smiles-smugly"),
        Entry(":v", "chatsan-smiles-smugly"),
        Entry(">:i", "chatsan-annoyed"),
        Entry(">:і", "chatsan-annoyed"), // Sich
        Entry(":i", "chatsan-sighs"),
        Entry(":і", "chatsan-sighs"), // Sich
        Entry(":|", "chatsan-sighs"),
        Entry(":p", "chatsan-stick-out-tongue"),
        Entry(";p", "chatsan-stick-out-tongue"),
        Entry(":b", "chatsan-stick-out-tongue"),
        Entry(":р", "chatsan-stick-out-tongue"), // Sich
        Entry(";р", "chatsan-stick-out-tongue"), // Sich
        Entry("0-0", "chatsan-wide-eyed"),
        Entry("o-o", "chatsan-wide-eyed"),
        Entry("o.o", "chatsan-wide-eyed"),
        Entry("0_0", "chatsan-wide-eyed"), // Sich
        Entry("0.0", "chatsan-wide-eyed"), // Sich
        Entry("о-о", "chatsan-wide-eyed"), // Sich
        Entry("о.о", "chatsan-wide-eyed"), // Sich
        Entry("omg", "chatsan-wide-eyed"), // Sich
        Entry("омг", "chatsan-wide-eyed"), // Sich
        Entry("._.", "chatsan-surprised"),
        Entry("о_0", "chatsan-surprised"), // Sich
        Entry("0_о", "chatsan-surprised"), // Sich
        Entry("о.0", "chatsan-surprised"), // Sich
        Entry("0.о", "chatsan-surprised"), // Sich
        Entry(".).", "chatsan-surprised"), // Sich-MIU
        Entry(".-.", "chatsan-confused"),
        Entry("?", "chatsan-confused"), // Sich
        Entry("-_-", "chatsan-unimpressed"),
        Entry("smh", "chatsan-unimpressed"),
        Entry(":?", "chatsan-shrugs"),
        Entry("o/", "chatsan-waves"),
        Entry("о/", "chatsan-waves"), // Sich
        Entry("^^/", "chatsan-waves"),
        Entry(":/", "chatsan-uncertain"),
        Entry(":\\", "chatsan-uncertain"),
        Entry("lmao", "chatsan-laughs"),
        Entry("lmfao", "chatsan-laughs"),
        Entry("lol", "chatsan-laughs"),
        Entry("lel", "chatsan-laughs"),
        Entry("kek", "chatsan-laughs"),
        Entry("rofl", "chatsan-laughs"),
        Entry("лмао", "chatsan-laughs"), // Sich
        Entry("лмфао", "chatsan-laughs"), // Sich
        Entry("лол", "chatsan-laughs"), // Sich
        Entry("кек", "chatsan-laughs"), // Sich
        Entry("рофл", "chatsan-laughs"), // Sich
        Entry("o7", "chatsan-salutes"),
        Entry("о7", "chatsan-salutes"), // Sich
        Entry(";_;7", "chatsan-tearfully-salutes"),
        Entry("хз", "chatsan-shrugs"), // Sich
        Entry(";)", "chatsan-winks"),
        Entry(";]", "chatsan-winks"),
        Entry("(;", "chatsan-winks"),
        Entry("[;", "chatsan-winks"),
        Entry(":')", "chatsan-tearfully-smiles"),
        Entry(":']", "chatsan-tearfully-smiles"),
        Entry("=')", "chatsan-tearfully-smiles"),
        Entry("=']", "chatsan-tearfully-smiles"),
        Entry("(':", "chatsan-tearfully-smiles"),
        Entry("[':", "chatsan-tearfully-smiles"),
        Entry("('=", "chatsan-tearfully-smiles"),
        Entry("['=", "chatsan-tearfully-smiles"),
    ];

    [Dependency] private IConfigurationManager _configurationManager = default!;
    [Dependency] private ILocalizationManager _loc = default!;

    private bool _doSanitize;

    public void Initialize()
    {
        _configurationManager.OnValueChanged(CCVars.ChatSanitizerEnabled, x => _doSanitize = x, true);
    }

    /// <summary>
    ///     Remove the shorthands from the message, returning the last one found as the emote
    /// </summary>
    /// <param name="message">The pre-sanitized message</param>
    /// <param name="speaker">The speaker</param>
    /// <param name="sanitized">The sanitized message with shorthands removed</param>
    /// <param name="emote">The localized emote</param>
    /// <returns>True if emote has been sanitized out</returns>
    public bool TrySanitizeEmoteShorthands(string message,
        EntityUid speaker,
        out string sanitized,
        [NotNullWhen(true)] out string? emote)
    {
        emote = null;
        sanitized = message;

        if (!_doSanitize)
            return false;

        // -1 is just a canary for nothing found yet
        var lastEmoteIndex = -1;

        foreach (var (r, emoteKey) in ShorthandToEmote)
        {
            // We're using sanitized as the original message until the end so that we can make sure the indices of
            // the emotes are accurate.
            var lastMatch = r.Match(sanitized);

            if (!lastMatch.Success)
                continue;

            if (lastMatch.Index > lastEmoteIndex)
            {
                lastEmoteIndex = lastMatch.Index;
                emote = _loc.GetString(emoteKey, ("ent", speaker));
            }

            message = r.Replace(message, string.Empty);
        }

        sanitized = message.Trim();
        return emote is not null;
    }

    private static (Regex regex, string emoteKey) Entry(string shorthand, string emoteKey)
    {
        // We have to escape it because shorthands like ":)" or "-_-" would break the regex otherwise.
        var escaped = Regex.Escape(shorthand);

        // So there are 2 cases:
        // - If there is whitespace before it and after it is either punctuation, whitespace, or the end of the line
        //   Delete the word and the whitespace before
        // - If it is at the start of the string and is followed by punctuation, whitespace, or the end of the line
        //   Delete the word and the punctuation if it exists.
        var pattern = new Regex(
            $@"\s{escaped}(?=\p{{P}}|\s|$)|^{escaped}(?:\p{{P}}|(?=\s|$))",
            RegexOptions.RightToLeft | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        return (pattern, emoteKey);
    }
}
