using Content.Shared.Damage;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;

namespace Content.Shared.Weapons.Misc;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
public sealed partial class TetherForseCombineComponent : BaseForceGunComponent
{

    [ViewVariables, DataField, AutoNetworkedField]
    public float MaxDistance = 10f;

    /// <summary>
    /// Maximum distance to throw entities.
    /// </summary>
    [DataField, AutoNetworkedField]
    public float ThrowDistance = 15f;

    [DataField, AutoNetworkedField]
    public float ThrowForce = 30f;

    [DataField(required: true)]
    public DamageSpecifier Damage = default!;

    [DataField("soundLaunch")]
    public SoundSpecifier? LaunchSound = new SoundPathSpecifier("/Audio/Weapons/soup.ogg")
    {
        Params = AudioParams.Default.WithVolume(5f),
    };
}
