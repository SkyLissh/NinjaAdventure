using Godot;

namespace NinjaAdventure.Scripts;

public partial class Life : Node2D {
  [Signal]
  public delegate void DefeatedEventHandler();

  [Signal]
  public delegate void LifeChangedEventHandler(int life);

  [Export]
  public int InitialLife { get; private set; } = 50;

  [Export]
  public int MaxLife { get; private set; } = 100;

  protected int Current { get; set; }
  public bool IsDefeated => Current <= 0;
  public bool HasMaxLife => Current >= MaxLife;

  public override void _Ready() {
    Current = InitialLife;
  }

  public void Damage(int damage) {
    if (damage <= 0 || IsDefeated) return;

    Current -= damage;
    EmitSignal(SignalName.LifeChanged, Current);

    if (!IsDefeated) return;

    Current = 0;
    EmitSignal(SignalName.Defeated);
    OnDefeated();
  }

  protected virtual void OnDefeated() => QueueFree();
}
