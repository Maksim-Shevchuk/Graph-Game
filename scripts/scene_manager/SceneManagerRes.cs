using Godot;
using System;

public partial class SceneManagerRes : Resource
{
	[Export] public PackedScene MainScene {get; set;}
	[Export] public PackedScene CurLevelScene {get; set;}
	[Export] public PackedScene LevelMenuScene {get; set;}
}
