using System;
using UnityEngine;

public class ArmorSlot : ItemSlot
{
    public int index;

    protected override void GetSelection()
    {
        GameInfo.Garage.SelectItem(typeof(ArmorItem), SetContents);
    }

    private void SetContents(EquippableItem item)
    {
        Debug.Log($"ArmorSlot has received the set item, {item.itemName}.");
        if (item is not ArmorItem) throw new Exception("Tried to equip a non armor to a armor slot!");
        
        GameInfo.Garage.GetActiveVehicle().Armor[index] = (ArmorItem)item;

        GameInfo.Garage.RecalculateWeight();
    }
}
