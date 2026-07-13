using Content.Shared.CCVar;
using Content.Shared.Chat;
using Content.Shared.Speech;
using Robust.Shared.Audio;
using Robust.Shared.Configuration;
using Robust.Shared.Random;

namespace Content.Server.Speech;

public sealed partial class SpeechSoundSystem
{
    [Dependency] private IConfigurationManager _cfg = default!; // Mriya: Added dependency for configuration manager

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var currentTime = _gameTiming.CurTime;
        var query = EntityQueryEnumerator<SpeechComponent>();

        while (query.MoveNext(out var uid, out var comp))
        {
            if (comp.PendingSpeechSounds.Count == 0)
                continue;

            if (currentTime >= comp.NextSpeechSoundTime)
            {
                var soundData = comp.PendingSpeechSounds.Dequeue();
                _audio.PlayPvs(soundData.Sound, uid, soundData.Params);
                comp.NextSpeechSoundTime = currentTime + TimeSpan.FromSeconds(soundData.DelayAfter);
            }
        }
    }

    private void OnEntitySpokeHandler(Entity<SpeechComponent> ent, ref EntitySpokeEvent args)
    {
        if (_cfg.GetCVar(CCVars.MriyaSpeechBububu))
        {
            OnEntitySpokeMriya(ent.Owner, ent.Comp, args);
        }
        else
        {
            OnEntitySpoke(ent.Owner, ent.Comp, args);
        }
    }

    private void OnEntitySpokeMriya(EntityUid uid, SpeechComponent component, EntitySpokeEvent args)
    {
        if (component.SpeechSounds == null || string.IsNullOrWhiteSpace(args.Message))
            return;

        var currentTime = _gameTiming.CurTime;
        var cooldown = TimeSpan.FromSeconds(component.SoundCooldownTime);

        if (currentTime - component.LastTimeSoundPlayed < cooldown)
            return;

        component.LastTimeSoundPlayed = currentTime;
        component.PendingSpeechSounds.Clear();

        var words = args.Message.Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (component.PendingSpeechSounds.Count >= _cfg.GetCVar(CCVars.MriyaSpeechBububuMaxWord))
                break;

            var soundData = GetSpeechSoundMriya((uid, component), word);
            if (soundData == null)
                continue;

            var data = soundData.Value;

            var randomDelay = _random.NextFloat(component.MinDelayBetweenWords, component.MaxDelayBetweenWords);

            char lastChar = word[^1];
            if (lastChar == '.' || lastChar == ',' || lastChar == '!' || lastChar == '?' || lastChar == ';' || lastChar == ':')
            {
                if (lastChar == '.' || lastChar == '!' || lastChar == '?')
                    randomDelay += component.PunctuationDelay;
                else
                    randomDelay += (component.PunctuationDelay * 0.5f);
            }

            data.DelayAfter = randomDelay;

            component.PendingSpeechSounds.Enqueue(data);
        }

        component.NextSpeechSoundTime = currentTime;
    }

    public SpeechSoundData? GetSpeechSoundMriya(Entity<SpeechComponent> ent, string message)
    {
        if (ent.Comp.SpeechSounds == null)
            return null;

        SoundSpecifier? contextSound;
        var prototype = ProtoMan.Index<SpeechSoundsPrototype>(ent.Comp.SpeechSounds);

        contextSound = message[^1] switch
        {
            '?' => prototype.AskSound,
            '!' => prototype.ExclaimSound,
            _ => prototype.SaySound
        };

        int uppercaseCount = 0;
        for (int i = 0; i < message.Length; i++)
        {
            if (char.IsUpper(message[i]))
                uppercaseCount++;
        }

        if (uppercaseCount > (message.Length / 2))
        {
            contextSound = prototype.ExclaimSound;
        }

        var scale = (float)_random.NextGaussian(1, prototype.Variation);

        var audioParams = ent.Comp.AudioParams.WithPitchScale(scale);

        return new SpeechSoundData
        {
            Sound = contextSound,
            Params = audioParams
        };
    }
}
