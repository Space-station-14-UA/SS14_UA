using Content.Shared._Mriya.BureaucraticComputer;

namespace Content.Client._Mriya.BureaucraticComputer.UI;

public sealed class BureaucracyComputerBoundUserInterface : BoundUserInterface
{
    private BureaucracyComputerWindow? _window;

    public BureaucracyComputerBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey) { }

    protected override void Open()
    {
        base.Open();
        _window = new BureaucracyComputerWindow();
        _window.OnClose += Close;

        _window.OnPrintPressed += (docId, fields) =>
        {
            SendMessage(new BureaucracyPrintMessage(docId, fields));
        };

        _window.OpenCentered();
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);

        if (state is BureaucracyAutoFillState autoFillState)
        {
            _window?.UpdateAutoFill(autoFillState);
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        _window?.Dispose();
    }
}
