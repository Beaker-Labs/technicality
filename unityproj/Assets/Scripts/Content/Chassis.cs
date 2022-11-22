using System;
using UnityEngine;

public class Chassis : ScriptableObject
{
    public string Name = "";
    public int BaseWeight;
    public int WeightLimit;
    public int HitPoints;
    //public int Armor;
    public bool Amphibious; // Amphibious units can move in water
    public bool Hover; // hover units are immune to all terrain effects
    public MoveTypes MoveType;


    public enum MoveTypes
    {
        Tank,
        FrontSteer,
        RearSteer,
        Omni
    }
}
