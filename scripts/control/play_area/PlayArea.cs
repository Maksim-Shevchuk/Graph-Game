using Godot;
using GraphGame;
using org.mariuszgromada.math.mxparser;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

public partial class PlayArea : VBoxContainer
{
	[Export] private LineEdit functionLineEdit;
	[Export] private HBoxContainer expandedInput;
	[Export] private LineEdit xZeroLineEdit;
	[Export] private LineEdit deltaLineEdit;
	[Export] private Button runButton;
	[Export] private PanelContainer HelpPopUpContainer;

	private static PlayArea instance;
	private PlayAreaModel model = PlayAreaModel.Instance;
	private PlayAreaController controller = PlayAreaController.Instance;
	private Ship shipView = Ship.Instance;
	private static string[] informationFromFields = new string[3] { "", "", "" };

	private PlayArea() { }

	public override void _Ready()
	{
		functionLineEdit.GrabFocus();
		expandedInput.Visible = false;
		HelpPopUpContainer.Visible = false;
		model.ChangeVisibilityExpandedInput += ChangeVisibilityExpandedInput;
		model.StopPhysics += StopVisualizingPath;
		functionLineEdit.InsertTextAtCaret(informationFromFields[0]);
		xZeroLineEdit.InsertTextAtCaret(informationFromFields[1]);
		deltaLineEdit.InsertTextAtCaret(informationFromFields[2]);
		instance = this;
	}

	public override void _ExitTree()
	{
		model.ChangeVisibilityExpandedInput -= ChangeVisibilityExpandedInput;
		model.StopPhysics -= StopVisualizingPath;
	}

	public void StopVisualizingPath()
	{
		SetPhysicsProcess(false);
	}

	public override void _ShortcutInput(InputEvent @event)
	{
		if (InputMap.EventIsAction(@event, "run_button_clicked"))
		{
			OnRunButtonPressed();
		}
	}
	private int count = 0;
	public override void _PhysicsProcess(double delta)
	{
		if (count != 75)
		{
			count++;
		}
		else
		{
			count = 0;
			string function = functionLineEdit.Text.Replace("\\s", "").ToLower();
			Argument y = new(function, new Argument("x"));
			bool syntax = y.checkSyntax();
			if (syntax)
			{
				bool isXZeroParsed = float.TryParse(xZeroLineEdit.Text.Replace(".", ","), out float xZero);
				bool isDeltaParsed = float.TryParse(deltaLineEdit.Text.Replace(".", ","), out float deltaLe);
				xZero = isXZeroParsed ? xZero : float.NaN;
				deltaLe = isDeltaParsed ? deltaLe : float.NaN;
				controller.VisualizePath(function, xZero, deltaLe);
			}
		}
	}

	private void OnRunButtonPressed()
	{
		if (!string.IsNullOrEmpty(functionLineEdit.Text))
		{
			string function = functionLineEdit.Text.Replace("\\s", "").ToLower();
			Argument y = new(function, new Argument("x"));
			bool syntax = y.checkSyntax();
			if (syntax)
			{
				functionLineEdit.Modulate = Colors.White;
				float xZero = 0f;
				bool isXZeroResultCorrect = true;
				if (string.IsNullOrEmpty(xZeroLineEdit.Text))
				{
					xZero = float.NaN;
				}
				else
				{
					isXZeroResultCorrect = float.TryParse(xZeroLineEdit.Text.Replace(".", ","), out xZero);
				}
				float delta = 0.01f;
				bool isDeltaResultCorrect = true;
				if (string.IsNullOrEmpty(deltaLineEdit.Text))
				{
					delta = float.NaN;
				}
				else
				{
					isDeltaResultCorrect = float.TryParse(deltaLineEdit.Text.Replace(".", ","), out delta);
				}

				xZeroLineEdit.Modulate = isXZeroResultCorrect ? Colors.White : Colors.Red;
				deltaLineEdit.Modulate = isDeltaResultCorrect ? Colors.White : Colors.Red;

				if (isXZeroResultCorrect && isDeltaResultCorrect)
				{
					runButton.Disabled = true;
					controller.HandleRunButtonPressed(function, xZero, delta);
				}
				informationFromFields[0] = function;
				informationFromFields[1] = xZero is float.NaN ? "" : xZero.ToString();
				informationFromFields[2] = delta is float.NaN ? "" : delta.ToString();
			}
			else
			{
				functionLineEdit.Modulate = Colors.Red;
			}
		}
	}

	private void OnHelpButtonPressed()
	{
		HelpPopUpContainer.Visible = !HelpPopUpContainer.Visible;
	}

	private void OnClosePopUpButtonPressed()
	{
		HelpPopUpContainer.Visible = false;
	}

	private void ChangeVisibilityExpandedInput(bool isExpandedInputVisible)
	{
		expandedInput.Visible = isExpandedInputVisible;
	}

	public static PlayArea Instance { get => instance ??= new(); }

	public static string[] InformationFromFields
	{
		get => informationFromFields;
		set => informationFromFields = value;
	}
}
