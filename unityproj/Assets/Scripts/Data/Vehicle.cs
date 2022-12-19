using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

// Data type which can be edited in the garage, saved, loaded, and passed to the BattleManager to be instanced
public class Vehicle
{
    public string Name = "Fox";
    public Chassis Chassis;
    public List<WeaponItem> Weapons;
    public List<ArmorItem> Armor;
    public bool PlayerControlled;
    public string ChassisID = "Fox";
    //public List<ModItem> Mods;
    //public Pilot Pilot;

    public Vehicle()
    {
        Chassis = GetChassis();
        Weapons = new List<WeaponItem>();
        Weapons.Add(Resources.Load<WeaponItem>($"Item/Weapon/TestGun"));
    }

    public Vehicle(Chassis chassis)
    {
        Chassis = chassis;
        Weapons = new List<WeaponItem>();
        Weapons.Add(Resources.Load<WeaponItem>($"Item/Weapon/TestGun"));
    }

    public Chassis GetChassis()
    {
        return Resources.Load<GameObject>($"Chassis/{ChassisID}").GetComponent<Chassis>();
    }

    public GameObject Spawn(Transform parent, Vector3 position = new Vector3())
    {
        VehicleController spawnedVehicle = Object.Instantiate(Chassis.gameObject, parent).GetComponent<VehicleController>();
        spawnedVehicle.transform.localPosition = position;
        spawnedVehicle.SetDriver(PlayerControlled); // Replace this with some method of actually loading an AI
        // load weapons
        List<WeaponMount> weaponMounts = spawnedVehicle.WeaponMounts;
        if (weaponMounts.Count != Weapons.Count)
        {
            Debug.Log($"weaponMounts.Count is {weaponMounts.Count} while Weapons.Count is {Weapons.Count}, They should be the same.");
        }
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i] != null)
            {
                weaponMounts[i].SetWeapon(Weapons[i].prefab);
            }
        }
        spawnedVehicle.Activate();
        return spawnedVehicle.gameObject;
    }

    public GameObject SpawnEditMode(Transform parent)
    {
        VehicleController spawnedVehicle = Object.Instantiate(Chassis.gameObject, parent).GetComponent<VehicleController>();
        spawnedVehicle.transform.localScale = Vector3.one * 2;
        // load weapons
        List<WeaponMount> weaponMounts = spawnedVehicle.WeaponMounts;

        for (int i = 0; i < Weapons.Count; i++)
        {
            WeaponSlot ws = Object.Instantiate(GameInfo.WeaponSlotPrefab, spawnedVehicle.transform).GetComponent<WeaponSlot>();
            ws.Initialize(this, i);

            if (Weapons[i] != null)
            {
                weaponMounts[i].SetWeapon(Weapons[i].prefab);
            }
        }
        return spawnedVehicle.gameObject;
    }
}
