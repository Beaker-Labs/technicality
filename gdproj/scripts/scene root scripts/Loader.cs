using Godot;
using System;

// This is the root node script for the Loader scene, and is responsible for:
// - Controlling the scene transition animation
// - 
public class Loader : Node
{
    [Export] private Transform _doorLeft;
    [Export] private Transform _doorRight;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        
    }
    
}
