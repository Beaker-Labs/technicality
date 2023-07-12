using System;
using System.Collections.Generic;

// This represents a group of vehicles ready to be passed to the battle setup manager
// Right now this is used to represent teams in the tournament bracket as well, but eventually that function will need it's own class
public class BattleTeam
{
    public string Name;
    public bool PlayerControlled;
    public List<Vehicle> Vehicles;

    public BattleTeam(string name, List<Vehicle> vehicles, bool playerControlled = false)
    {
        Name = name;
        Vehicles = vehicles;
        PlayerControlled = playerControlled;
    }

    public BattleTeam()
    {
        Vehicles = new List<Vehicle>();
    }

    public int GetWeight()
    {
        int sum = 0;
        foreach (Vehicle i in Vehicles)
        {
            sum += i.GetWeight();
        }
        return sum;
    }
}
