using Robust.Client.Graphics;

namespace Content.Client._NC.RTS.Components;

/// <summary>
/// Tracks the temporary client-only selection outline shader for RTS-selected entities.
/// </summary>
[RegisterComponent]
public sealed partial class RTSSelectedComponent : Component
{
    public ShaderInstance? Shader;
}
