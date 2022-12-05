using System;
using System.Collections.Generic;
using UnityEngine;

// Data type which can be edited in the garage, saved, loaded, and passed to the BattleManager to be instanced
public class Vehicle
{
    public string Name = "Fox";
    public Chassis Chassis;
    public List<Weapon> Weapons;
    public List<ArmorItem> Armor;
    public bool PlayerControlled;
    public string ChassisID = "Fox";
    //public List<ModItem> Mods;
    //public Pilot Pilot;

    public Vehicle()
    {
        Chassis = GetChassis();
        Weapons = new List<Weapon>();
        Weapons.Add(Resources.Load<GameObject>($"Items/Weapons/TestGun").GetComponent<Weapon>());
    }

    public Vehicle(Chassis chassis)
    {
        Chassis = chassis;
        Weapons = new List<Weapon>();
        Weapons.Add(Resources.Load<GameObject>($"Items/Weapons/TestGun").GetComponent<Weapon>());
    }

    public Chassis GetChassis()
    {
        return Resources.Load<GameObject>($"Chassis/{ChassisID}").GetComponent<Chassis>();
    }
}
