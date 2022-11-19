using System;
using System.Collections.Generic;
using UnityEngine;

public class Campaign : ScriptableObject
{
    public int Month;
    public int Cash;
    public Team Team;
    public List<EquippableItem> Inventory;
    public List<Vehicle> Garage;
}