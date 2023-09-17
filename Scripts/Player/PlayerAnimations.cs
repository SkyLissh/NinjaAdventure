using Godot;

namespace NinjaAdventure.Scripts.Player;

public partial class PlayerAnimations : AnimationTree {
  private static readonly StringName WalkingParams = "parameters/Walking/blend_position";
  private static readonly StringName IdleParams = "parameters/Idle/blend_position";

  private static readonly StringName Idle = "parameters/conditions/idle";
  private static readonly StringName Walking = "parameters/conditions/walking";
  private static readonly StringName Defeated = "parameters/conditions/defeated";

  [Export]
  private PlayerController PlayerController { get; set; }

  public override void _Ready() => Active = true;

  public override void _Process(double delta) => UpdateAnimation();

  private void UpdateAnimation() {
    SetIdle();

    if (!PlayerController.IsMoving) return;

    SetWalking();
    SetCoordinates(PlayerController.Velocity);
  }

  private void OnPlayerDefeated() => SetDefeated();

  private void SetCoordinates(Vector2 coordinates) {
    Set(IdleParams, coordinates);
    Set(WalkingParams, coordinates);
  }

  private void SetDefeated() {
    Reset();
    Set(Defeated, true);
  }

  private void SetIdle() {
    Reset();
    Set(Idle, true);
  }

  private void SetWalking() {
    Reset();
    Set(Walking, true);
  }

  private void Reset() {
    Set(Idle, false);
    Set(Walking, false);
    Set(Defeated, false);
  }
}
