using Godot;

namespace NinjaAdventure.Scripts.Player;

public partial class PlayerManna : Node {
  [Signal] public delegate void MannaChangedEventHandler(int manna);

  [Export] public int InitialManna { get; private set; } = 50;
  [Export] public int MaxManna { get; private set; } = 100;
  [Export] public int MannaRestoreAmount { get; private set; } = 5;
  [Export] private PlayerLife PlayerLife { get; set; }

  public int Current { get; private set; }
  public bool HasMaxManna => Current >= MaxManna;

  public override void _Ready() => Current = InitialManna;

  public override void _Process(double delta) {
    if (Input.IsActionJustPressed("use_manna")) UseManna(10);
  }

  private void UseManna(int amount) {
    if (amount <= 0 || Current < amount || PlayerLife.IsDefeated) return;

    Current -= amount;
    EmitSignal(SignalName.MannaChanged, Current);

    if (Current < 0) Current = 0;
    EmitSignal(SignalName.MannaChanged, Current);
  }

  public void OnRestoreManna(int amount) {
    if (Current >= MaxManna || PlayerLife.IsDefeated) return;

    Current += amount;
    EmitSignal(SignalName.MannaChanged, Current);

    if (HasMaxManna) Current = MaxManna;
    EmitSignal(SignalName.MannaChanged, Current);
  }

  private void OnMannaTimerTimeout() => OnRestoreManna(MannaRestoreAmount);
}
