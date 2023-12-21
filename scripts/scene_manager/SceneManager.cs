using Godot;
using System;
using System.Collections.Generic;

public enum SceneNamesEnum
{
	MainMenu,
	CurrentLevel,
	LevelMenu
}

public partial class SceneManager : Node
{
	private static SceneManager instance;

	public Dictionary<SceneNamesEnum, string> sceneDictionary = new()
	{
		{SceneNamesEnum.MainMenu, "res://main/main.tscn"},
		{SceneNamesEnum.CurrentLevel, "res://game/game.tscn"},
		{SceneNamesEnum.LevelMenu, "res://main/level_menu/level_menu.tscn"}
	};

	public override void _Ready()
	{
		instance = this;
	}

	public void ChangeScene(SceneNamesEnum name)
	{
		string path = sceneDictionary[name];
		GetTree().ChangeSceneToFile(path);
	}

	public static SceneManager Instance { get => instance ??= new(); }
}
