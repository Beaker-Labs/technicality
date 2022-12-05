using System;
using System.Collections.Generic;
using UnityEngine;

public class Campaign
{
    public int Month;
    public int Cash;
    public Team Team;
    public List<EquippableItem> Inventory;
    public List<Vehicle> Garage;

    public Campaign()
    {
        Cash = 500;
        Inventory = new List<EquippableItem>();
        Inventory.AddRange(GameInfo.Items);
        Garage = new List<Vehicle>();
        //Garage.Add(new Vehicle(GameInfo.Chassis[0]));
        Team = new Team();
    }
}
