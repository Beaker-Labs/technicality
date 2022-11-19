using Godot;
using System;

// This is the root node script for the Loader scene, and is responsible for:
// - Controlling the scene transition animation
// - 
public class Loader : Node
{
    private Node _favoriteChild;
    private const string DoorsPath = "res://scenes/LoadingDoors.tscn";
    private const string MainMenuPath = "res://scenes/MainMenu.tscn";
    private Node _activeScene;
    private AnimationPlayer _loadingDoors;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _loadingDoors = GetChild<AnimationPlayer>(0);
        _activeScene = GetChild(1);
    }

    public override void _Process(float delta)
    {
        
    }


}
