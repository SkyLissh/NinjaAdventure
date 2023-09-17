using Godot;

namespace NinjaAdventure.Scripts.Widgets;

public partial class Bar : HBoxContainer {
  [Export] public Label ValueLabel { get; set; }
  [Export] public TextureProgressBar ProgressBar { get; set; }

  [Export] public int InitialValue { get; set; } = 50;

  public override void _Ready() {
    ValueLabel.Text = InitialValue.ToString();
    ProgressBar.Value = InitialValue;
  }

  public void OnValueChanged(int value) {
    ValueLabel.Text = value.ToString();
    ProgressBar.Value = value;
  }
}
