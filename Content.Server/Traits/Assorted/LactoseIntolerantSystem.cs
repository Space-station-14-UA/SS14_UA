using Content.Shared.Nutrition;
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.Traits.Assorted;
using Content.Shared.Medical;
using Robust.Shared.Timing;
using DependencyAttribute = Robust.Shared.IoC.DependencyAttribute;

namespace Content.Server.Traits.Assorted;

/// <summary>
/// SP3CTRE - Система трейту непереносимості лактози
/// Викликає блювоту при вживанні молочних продуктів
/// </summary>
public sealed class LactoseIntolerantSystem : EntitySystem
{
    [Dependency] private readonly VomitSystem _vomit = default!;
    [Dependency] private readonly IGameTiming _timing = default!;

    public override void Initialize()
    {
        // Підписка на подію вживання їжі
        SubscribeLocalEvent<LactoseIntolerantComponent, IngestingEvent>(OnIngesting);
    }

    private void OnIngesting(Entity<LactoseIntolerantComponent> entity, ref IngestingEvent args)
    {
        // Перевірка на вміст молочних продуктів
        if (!HasMilkReagents(args.Split))
            return;

        var currentTime = _timing.CurTime;

        // Кулдаун на блювання
        if (entity.Comp.LastVomitTime.HasValue &&
            currentTime < entity.Comp.LastVomitTime.Value + entity.Comp.VomitCooldown)
            return;

        if (entity.Comp.HasVomitedThisSession)
            return;

        if (new Random().NextDouble() < entity.Comp.VomitChance)
        {
            entity.Comp.HasVomitedThisSession = true;
            Dirty(entity);

            Timer.Spawn(entity.Comp.VomitDelay, () =>
            {
                if (!Deleted(entity.Owner))
                {
                    _vomit.Vomit(entity.Owner);
                    entity.Comp.LastVomitTime = _timing.CurTime;
                    Dirty(entity);

                    // Скидання затримки для повторного блювання
                    Timer.Spawn(TimeSpan.FromSeconds(5), () =>
                    {
                        if (!Deleted(entity.Owner))
                        {
                            entity.Comp.HasVomitedThisSession = false;
                            Dirty(entity);
                        }
                    });
                }
            });
        }
    }
    /// <summary>
    /// Перевірка реагентів на наявність молочних продуктів
    /// </summary>
    private bool HasMilkReagents(Solution solution)
    {
        // ID реагентів які викликають блювання
        var milkReagents = new[] { "Milk", "MilkGoat", "MilkSpoiled", "Pilk", "Cream", "CafeLatte"  };

        foreach (var reagent in solution.Contents)
        {
            if (milkReagents.Contains(reagent.Reagent.Prototype))
                return true;
        }

        return false;
    }
}
