using Godot;
using System;
using Godot.Collections;

public class WeaponItem : EquippableItem
{
    [Export] public int Damage;
    [Export] public int RateOfFire; // rate of fire in rounds per minute
    [Export] public int Ammo; // number of rounds that can be fired before needing to reload. 0 for infinite
    [Export] public int ReloadTime; // Time to reload

    public void Fire()
    {
        
    }
}
