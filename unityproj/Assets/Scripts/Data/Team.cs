using System;
using System.Collections.Generic;

// This represents a group of vehicles ready to be passed to the battle setup manager
public class Team
{
    public string Name;
    public bool PlayerControlled;
    public List<Vehicle> Vehicles;
}
