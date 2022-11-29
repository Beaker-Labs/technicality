using System;
using UnityEngine;

// Scriptable object which stores chassis base stats as an asset
[CreateAssetMenu(fileName = "Chassis", menuName = "ScriptableObjects/Chassis", order = 1)]
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
    public GameObject Prefab; // The chassis prefab


    public enum MoveTypes
    {
        Tank,
        FrontSteer,
        RearSteer,
        Omni
    }
}
