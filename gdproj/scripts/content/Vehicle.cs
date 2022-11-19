using Godot;
using System;
using System.Collections.Generic;

public class Vehicle : Reference
{
    public string Name;
    public Chassis Chassis;
    public List<WeaponItem> Weapons;
    public List<ArmorItem> Armor;
    //public List<ModItem> Mods;
}
