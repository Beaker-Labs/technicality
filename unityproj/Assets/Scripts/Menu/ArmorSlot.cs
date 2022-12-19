using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ArmorSlot : ItemSlot
{
    private int _index;
    private Vehicle _vehicle;

    public void Initialize(Vehicle vehicle, int index)
    {
        _index = index;
        _vehicle = vehicle;
    }

    protected override void GetSelection()
    {
        GameInfo.Garage.SelectItem(typeof(ArmorItem), SetContents);
    }

    private void SetContents(EquippableItem item)
    {
        //Debug.Log($"Weaponslot has received the set item, {item.itemName}.");
        if (item is not ArmorItem) throw new Exception("Tried to equip a non weapon to a weapon slot!");
        
        _vehicle.Armor[_index] = (ArmorItem)item;
    }
}
