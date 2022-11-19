using System;

public class WeaponItem : EquippableItem
{
    public int Damage;
    public int RateOfFire; // rate of fire in rounds per minute
    public int Ammo; // number of rounds that can be fired before needing to reload. 0 for infinite
    public int ReloadTime; // Time to reload

    public void Fire()
    {
        
    }
}
