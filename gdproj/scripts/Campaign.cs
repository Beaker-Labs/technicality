using Godot;
using System;
using System.Collections.Generic;

public class Campaign : Reference
{
    public int Month;
    public int Cash;
    public Team Team;
    public List<ItemList> Inventory;
    public List<Vehicle> Garage;
}
