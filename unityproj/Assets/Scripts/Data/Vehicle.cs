using System;
using System.Collections.Generic;
using UnityEngine;

// Data type which can be edited in the garage, saved, loaded, and passed to the BattleManager to be instanced
public class Vehicle
{
    public string Name = "Fox";
    public Chassis Chassis;
    public List<WeaponItem> Weapons;
    public List<ArmorItem> Armor;
    public string ChassisID = "Fox";
    //public List<ModItem> Mods;
    //public Pilot Pilot;

    public Chassis GetChassis()
    {
        return Resources.Load<GameObject>($"Chassis/{ChassisID}").GetComponent<Chassis>();
    }
}
