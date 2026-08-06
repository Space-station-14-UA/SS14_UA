using Robust.Shared.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Content.Shared.Speech;

public sealed partial class SpeechComponent
{
    [ViewVariables]
    public Queue<SpeechSoundData> PendingSpeechSounds = new();

    [DataField]
    public TimeSpan NextSpeechSoundTime;

    [DataField]
    public float MinDelayBetweenWords = 0.2f;

    [DataField]
    public float MaxDelayBetweenWords = 0.25f;

    [DataField]
    public float PunctuationDelay = 0.25f;

    [DataField]
    public bool UseSoundLimitOverride = false;

    [DataField]
    public int SoundLimitOverride = 1;
}

public struct SpeechSoundData
{
    public SoundSpecifier Sound;
    public AudioParams Params;
    public float DelayAfter;
}
