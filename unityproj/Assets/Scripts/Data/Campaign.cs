using System;
using System.Collections.Generic;
using UnityEngine;

public class Campaign
{
    public string TeamName = "Player Team";
    public int Month;
    public int Cash;
    public List<EquippableItem> Inventory;
    public List<Vehicle> Garage;

    public Campaign()
    {
        Cash = 500;
        Inventory = new List<EquippableItem>();
        Inventory.AddRange(GameInfo.Items);
        Garage = new List<Vehicle>();
        Garage.Add(new Vehicle(GameInfo.Chassis[0]));
        Month = 0;
    }

    public BattleTeam GetBattleTeam()
    {
        List<Vehicle> teamVehicles = new List<Vehicle>();
        for (int i = 0; i < Garage.Count; i++)
        {
            if (Garage[i].Selected)
            {
                teamVehicles.Add(Garage[i]);
            }
        }
        return new BattleTeam(TeamName, teamVehicles, true);
    }
}
