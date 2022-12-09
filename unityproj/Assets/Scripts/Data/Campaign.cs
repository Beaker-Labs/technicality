using System;
using System.Collections.Generic;
using UnityEngine;

public class Campaign
{
    public string TeamName = "Player Team";
    public int Month;
    public int Cash;
    // public BattleTeam BattleTeam;
    public List<EquippableItem> Inventory;
    public List<Vehicle> Garage;
    public List<Vehicle> TeamVehicles;

    public Campaign()
    {
        Cash = 500;
        Inventory = new List<EquippableItem>();
        Inventory.AddRange(GameInfo.Items);
        Garage = new List<Vehicle>();
        Garage.Add(new Vehicle(GameInfo.Chassis[0]));
        // BattleTeam = new BattleTeam(TeamName, Garage, true);
    }

    public BattleTeam GetBattleTeam()
    {
        return new BattleTeam(TeamName, TeamVehicles, true);
    }
}
