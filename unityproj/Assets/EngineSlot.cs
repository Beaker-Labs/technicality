using System;
using UnityEngine;

public class EngineSlot : ItemSlot
{
    public int index;

    protected override void GetSelection()
    {
        GameInfo.Garage.SelectItem(typeof(EngineItem), SetContents);
    }

    private void SetContents(EquippableItem item)
    {
        Debug.Log($"EngineSlot has received the set item, {item.itemName}.");
        if (item is not EngineItem) throw new Exception("Tried to equip a non engine to a engine slot!");
        
        GameInfo.Garage.GetActiveVehicle().Engine = (EngineItem)item;

        GameInfo.Garage.RecalculateWeight();
    }
}