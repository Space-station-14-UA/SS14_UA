using System.Text.RegularExpressions;
using Content.Shared.Speech.Components;

namespace Content.Shared.Speech.EntitySystems;

public sealed class MothAccentSystem : RelayAccentSystem<MothAccentComponent>
{
    private static readonly Regex RegexLowerBuzz = new Regex("[zзж]{1,3}");
    private static readonly Regex RegexUpperBuzz = new Regex("[ZЗЖ]{1,3}");

    public override string Accentuate(string message, Entity<MothAccentComponent>? ent = null)
    {
        // Triple lower-case "z", "з", "ж"
        message = RegexLowerBuzz.Replace(message, match => new string(match.Value[0], 3));

        // Triple upper-case "Z", "З", "Ж"
        message = RegexUpperBuzz.Replace(message, match => new string(match.Value[0], 3));

        //// buzzz
        //message = RegexLowerBuzz.Replace(message, "zzz");
        //// buZZZ
        //message = RegexUpperBuzz.Replace(message, "ZZZ");

        return message;
    }
}
