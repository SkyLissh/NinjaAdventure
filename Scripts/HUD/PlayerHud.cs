using Godot;

using NinjaAdventure.Scripts.Widgets;

namespace NinjaAdventure.Scripts.HUD;

public partial class PlayerHud : MarginContainer {
  [Export] private Bar LifeBar { get; set; }
  [Export] private Bar MannaBar { get; set; }

  private void OnLifeChanged(int life) => LifeBar.OnValueChanged(life);
  private void OnMannaChanged(int manna) => MannaBar.OnValueChanged(manna);
}
