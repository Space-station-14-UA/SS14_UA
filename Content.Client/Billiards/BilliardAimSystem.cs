using Content.Client.Billiards;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.State;
using Robust.Client.UserInterface;

public sealed partial class BilliardAimSystem : EntitySystem
{
    [Dependency] private IOverlayManager _overlayManager = default!;
    [Dependency] private IPlayerManager _playerManager = default!;
    [Dependency] private IInputManager _inputManager = default!;
    [Dependency] private IStateManager _stateManager = default!;
    [Dependency] private IUserInterfaceManager _uiManager = default!;

    private BilliardAimOverlay _overlay = default!;

    public override void Initialize()
    {
        base.Initialize();
        _overlay = new BilliardAimOverlay(EntityManager, _playerManager, _inputManager, _stateManager, _uiManager);
        _overlayManager.AddOverlay(_overlay);
    }

    public override void Shutdown()
    {
        base.Shutdown();
        _overlayManager.RemoveOverlay(_overlay);
    }
}
