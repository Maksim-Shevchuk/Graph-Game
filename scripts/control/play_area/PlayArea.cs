using Godot;
using GraphGame;
using System;

public partial class PlayArea : VBoxContainer
{
	[Export] private LineEdit lineEdit;
	private static PlayArea instance;
	private PlayAreaModel model = PlayAreaModel.Instance;
	private PlayAreaController controller = PlayAreaController.Instance;
	private Ship shipView = Ship.Instance;


	private PlayArea() { }

	public override void _Ready()
	{
		lineEdit.GrabFocus();
	}

	private void OnRunButtonPressed()
	{
		if (!string.IsNullOrEmpty(lineEdit.Text))
		{
			controller.HandleRunButtonPressed(lineEdit.Text.Replace("\\s", ""));
		}
	}

	public static PlayArea Instance { get => instance ??= new(); }
}
