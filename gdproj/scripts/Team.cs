using Godot;
using System;
using System.Collections.Generic;

// This represents a group of vehicles ready to be passed to the battle setup manager
public class Team : Reference
{
    public string Name;
    public List<Vehicle> Vehicles;
}
