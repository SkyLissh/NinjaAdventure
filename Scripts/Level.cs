using Godot;

using NinjaAdventure.Scripts.Player;

namespace NinjaAdventure.Scripts;

public partial class Level : Node {
  [Export] public PlayerController Player { get; set; }
  [Export] public Node2D PlayerSpawnPoint { get; set; }

  public override void _Ready() {
    Player.GlobalPosition = PlayerSpawnPoint.GlobalPosition;
  }
}
