using Godot;

namespace NinjaAdventure.Scripts.Player;

public partial class PlayerLife : Life {
  [Export]
  private CollisionShape2D CollisionShape2D { get; set; }

  public override void _Process(double delta) {
    if (Input.IsActionJustPressed("restore_life")) RestoreLife(10);
    if (Input.IsActionJustPressed("damage")) Damage(10);
  }

  private void RestoreLife(int life) {
    if (Current >= MaxLife || IsDefeated) return;

    Current += life;
    if (HasMaxLife) Current = MaxLife;

    EmitSignal(Life.SignalName.LifeChanged, Current);
  }

  private void Revive() {
    if (!IsDefeated) return;

    Current = MaxLife;
    CollisionShape2D.Disabled = false;
    EmitSignal(Life.SignalName.LifeChanged, Current);
  }

  protected override void OnDefeated() {
    CollisionShape2D.Disabled = true;
  }
}
