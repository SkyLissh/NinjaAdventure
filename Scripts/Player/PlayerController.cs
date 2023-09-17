using Godot;

namespace NinjaAdventure.Scripts.Player;

public partial class PlayerController : CharacterBody2D {
  [Signal] public delegate void LifeChangedEventHandler(int life);

  [Signal] public delegate void MannaChangedEventHandler(int manna);

  private Vector2 _velocity;

  [Export] public float Speed { get; set; } = 400;
  [Export] private PlayerLife PlayerLife { get; set; }
  [Export] private PlayerManna PlayerManna { get; set; }

  public bool IsMoving => _velocity != Vector2.Zero;

  public override void _PhysicsProcess(double delta) {
    if (PlayerLife.IsDefeated) {
      if (IsMoving) _velocity = Vector2.Zero;
      return;
    }

    _velocity = Velocity;

    _velocity.Y = Input.GetAxis("up", "down");
    _velocity.X = Input.GetAxis("left", "right");

    Velocity = _velocity.Normalized() * Speed;
    MoveAndSlide();
  }

  private void OnLifeChanged(int life) => EmitSignal(SignalName.LifeChanged, life);

  private void OnMannaChanged(int manna) => EmitSignal(SignalName.MannaChanged, manna);

  private void OnRestoreManna(int amount) => PlayerManna.OnRestoreManna(amount);
}
