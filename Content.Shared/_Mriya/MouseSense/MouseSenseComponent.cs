using Robust.Shared.GameStates;
using Robust.Shared.Utility;

namespace Content.Shared._Mriya.MouseSense;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class MouseSenseComponent : Component
{
    [DataField]
    public ResPath MarkerTexturePath = new("/Textures/_Mriya/Interface/mouse_marker.png");

    [DataField, AutoNetworkedField]
    public TimeSpan EndTime;

    [DataField, AutoNetworkedField]
    public float Range = 5f;

    [DataField]
    public TimeSpan Duration = TimeSpan.FromSeconds(6);
}
