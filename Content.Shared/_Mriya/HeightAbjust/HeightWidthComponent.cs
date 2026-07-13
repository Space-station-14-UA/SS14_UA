using Robust.Shared.GameStates;

namespace Content.Shared.Mriya.HeightAbjust;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(raiseAfterAutoHandleState: true, fieldDeltas: true)]
public sealed partial class HeightWidthComponent : Component
{
    [DataField, AutoNetworkedField]
    public float Height = 1f;
    [DataField, AutoNetworkedField]
    public float Width = 1f;
}
