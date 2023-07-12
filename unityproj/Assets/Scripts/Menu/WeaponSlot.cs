using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class WeaponSlot : ItemSlot
{
    private int _index;
    private WeaponMount _mount;
    private Vehicle _vehicle;

    public void Initialize(Vehicle vehicle, int index)
    {
        _index = index;
        _vehicle = vehicle;
        _mount = vehicle.Chassis.GetComponent<VehicleController>().WeaponMounts[index];
        transform.localPosition = _mount.transform.localPosition + Vector3.back * 10;
    }

    protected override void GetSelection()
    {
        GameInfo.Garage.SelectItem(typeof(WeaponItem), SetContents);
    }

    private void SetContents(EquippableItem item)
    {
        //Debug.Log($"Weaponslot has received the set item, {item.itemName}.");
        if (item is not WeaponItem) throw new Exception("Tried to equip a non weapon to a weapon slot!");
        
        _vehicle.Weapons[_index] = (WeaponItem)item;
        GameInfo.Garage.activeVehicleInstance.WeaponMounts[_index].SetWeapon(((WeaponItem)item).prefab);
        
        GameInfo.Garage.RecalculateWeight();
    }
}
