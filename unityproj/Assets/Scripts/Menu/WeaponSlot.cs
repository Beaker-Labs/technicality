using System;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    private int _index;
    private float _defaultScale;
    private WeaponMount _mount;
    private Vehicle _vehicle;

    public void Initialize(Vehicle vehicle, int index)
    {
        _index = index;
        _vehicle = vehicle;
        _mount = vehicle.Chassis.GetComponent<VehicleController>().WeaponMounts[index];
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _defaultScale = transform.localScale.x;
    }

    private void OnMouseEnter()
    {
        transform.localScale = Vector3.one * _defaultScale * 1.1f;
    }

    private void OnMouseExit()
    {
        transform.localScale = Vector3.one * _defaultScale * 1.0f;
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on!");
        GetSelection();
    }

    private void GetSelection()
    {
        GameInfo.Garage.SelectItem(typeof(WeaponItem), SetContents);
    }

    private void SetContents(EquippableItem item)
    {
        Debug.Log($"Weaponslot has received the set item, {item.itemName}.\nNow you need to implement this function!");
        if (item is not WeaponItem) throw new Exception("Tried to equip a non weapon to a weapon slot!");
        
        _vehicle.Weapons[_index] = (WeaponItem)item;
        GameInfo.Garage.activeVehicleInstance.WeaponMounts[_index].SetWeapon(((WeaponItem)item).prefab);
    }
}
