using Godot;
using System;

public class MainMenu : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public void StartGame()
    {
        GD.Print("Loading");
        PackedScene scn = (PackedScene)GD.Load("res://scenes/Headquarters.tscn");
        AddChild(scn.Instance());
        GD.Print("Loaded");
    }
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }
}
