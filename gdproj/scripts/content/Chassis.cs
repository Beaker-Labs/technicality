using Godot;
using System;

public class Chassis : Resource
{
    [Export] public string Name = "";
    [Export] public int BaseWeight;
    [Export] public int WeightLimit;
    [Export] public int HitPoints;
    //[Export] public int Armor;
    [Export] public bool Amphibious; // Amphibious units can move in water
    [Export] public bool Hover; // hover units are immune to all terrain effects
    [Export] public MoveTypes MoveType;


    public enum MoveTypes
    {
        Tank,
        FrontSteer,
        RearSteer,
        Omni
    }
}
