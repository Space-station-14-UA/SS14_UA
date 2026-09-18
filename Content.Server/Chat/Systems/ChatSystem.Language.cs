using Content.Shared._EinsteinEngines.Language;
using Content.Shared.Chat;

namespace Content.Server.Chat.Systems;

public sealed partial class ChatSystem
{
    public readonly Color DefaultSpeakColor = Color.White;

    public string WrapPublicMessage(EntityUid source, string name, string message, LanguagePrototype? language = null)
    {
        var wrapId = GetSpeechVerb(source, message).Bold
            ? "chat-manager-entity-say-bold-wrap-message"
            : "chat-manager-entity-say-wrap-message";
        return WrapMessage(wrapId, InGameICChatType.Speak, source, name, message, language);
    }

    public string WrapWhisperMessage(EntityUid source, LocId defaultWrap, string entityName, string message, LanguagePrototype? language = null)
    {
        return WrapMessage(defaultWrap, InGameICChatType.Whisper, source, entityName, message, language);
    }

    public string WrapMessage(LocId wrapId, InGameICChatType chatType, EntityUid source, string entityName, string message, LanguagePrototype? language)
    {
        var speech = GetSpeechVerb(source, message);
        language ??= _language.GetLanguage(source);

        if (language.SpeechOverride.MessageWrapOverrides.TryGetValue(chatType, out var wrapOverride))
            wrapId = wrapOverride;

        var verbId = language.SpeechOverride.SpeechVerbOverrides is { } verbsOverride
            ? _random.Pick(verbsOverride).ToString()
            : _random.Pick(speech.SpeechVerbStrings);

        var color = DefaultSpeakColor;
        if (language.SpeechOverride.Color is { } colorOverride)
            color = Color.InterpolateBetween(color, colorOverride, colorOverride.A);

        var languageDisplay = language.IsVisibleLanguage
            ? Loc.GetString("chat-manager-language-prefix", ("language", language.ChatName))
            : "";

        return Loc.GetString(wrapId,
            ("entityName", entityName),
            ("verb", Loc.GetString(verbId)),
            ("fontType", language.SpeechOverride.FontId ?? speech.FontId),
            ("fontSize", language.SpeechOverride.FontSize ?? speech.FontSize),
            ("color", color),
            ("message", message),
            ("language", languageDisplay));
    }
}
