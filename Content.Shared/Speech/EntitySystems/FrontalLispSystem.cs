using System.Text.RegularExpressions;
using Content.Shared.Speech.Components;

namespace Content.Shared.Speech.EntitySystems;

public sealed partial class FrontalLispSystem : RelayAccentSystem<FrontalLispComponent>
{
    // @formatter:off
    private static readonly Regex RegexUpperTh = new("[T]+[Ss]+|[S]+[Cc]+(?=[IiEeYy]+)|[C]+(?=[IiEeYy]+)|[P][Ss]+|([S]+[Tt]+|[T]+)(?=[Ii]+[Oo]+[Uu]*[Nn]*)|[C]+[Hh]+(?=[Ii]*[Ee]*)|[Z]+|[S]+|[X]+(?=[Ee]+)");
    private static readonly Regex RegexLowerTh = new("[t]+[s]+|[s]+[c]+(?=[iey]+)|[c]+(?=[iey]+)|[p][s]+|([s]+[t]+|[t]+)(?=[i]+[o]+[u]*[n]*)|[c]+[h]+(?=[i]*[e]*)|[z]+|[s]+|[x]+(?=[e]+)");
    private static readonly Regex RegexUpperEcks = new("[E]+[Xx]+[Cc]*|[X]+");
    private static readonly Regex RegexLowerEcks = new("[e]+[x]+[c]*|[x]+");

    // Regexes for for phonetic transformations encountered in Ukrainian speech
    //
    private static readonly Regex RegexUpperFSoftened = new("С");
    private static readonly Regex RegexLowerFSoftened = new("с");

    private static readonly Regex RegexUpperZSoftened = new("З");
    private static readonly Regex RegexLowerZSoftened = new("з");

    private static readonly Regex RegexUpperTSoftened = new("Ц");
    private static readonly Regex RegexLowerTSoftened = new("ц");
    // @formatter:on

    public override string Accentuate(string message, Entity<FrontalLispComponent>? ent = null)
    {
        // handles ts, sc(i|e|y), c(i|e|y), ps, st(io(u|n)), ch(i|e), z, s
        message = RegexUpperTh.Replace(message, "TH");
        message = RegexLowerTh.Replace(message, "th");
        // handles ex(c), x
        message = RegexUpperEcks.Replace(message, "EKTH");
        message = RegexLowerEcks.Replace(message, "ekth");

        message = RegexUpperFSoftened.Replace(message, "Ф");
        message = RegexLowerFSoftened.Replace(message, "ф");

        message = RegexUpperZSoftened.Replace(message, "В");
        message = RegexLowerZSoftened.Replace(message, "в");

        message = RegexUpperTSoftened.Replace(message, "Тф");
        message = RegexLowerTSoftened.Replace(message, "тф");

        return message;
    }
}
