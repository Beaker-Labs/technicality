using System;
using System.Collections.Generic;

// Data type which can be edited in the garage, saved, loaded, and passed to the BattleManager to be instanced
public class Vehicle
{
    public string Name;
    public Chassis Chassis;
    public List<WeaponItem> Weapons;
    public List<ArmorItem> Armor;
    //public List<ModItem> Mods;
    //public Pilot Pilot;
}
