using Godot;
using System;

public class Chassis : Resource
{
    [Export] public string Name = "";
    [Export] public int BaseWeight;
    [Export] public int WeightLimit;
    [Export] public int HitPoints;
    //[Export] public int Armor;
    [Export] public bool Amphibious;
    [Export] public MoveTypes MoveType;


    public enum MoveTypes
    {
        Tank,
        FrontSteer,
        RearSteer,
        Omni
    }
}
