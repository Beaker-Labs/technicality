using Godot;
using System;

public class EquippableItem : Resource
{
    [Export] public string Name = "";
    [Export] public string Description = "";
    [Export] public int Weight;
}
