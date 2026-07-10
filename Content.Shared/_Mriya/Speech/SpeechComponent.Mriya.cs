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
    public float DelayBetweenWords = 0.15f;
}

public struct SpeechSoundData
{
    public SoundSpecifier Sound;
    public AudioParams Params;
}
