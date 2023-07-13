using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

// Data type which can be edited in the garage, saved, loaded, and passed to the BattleManager to be instanced
public class Vehicle
{
    public string Name = "Fox";
    public Chassis Chassis;
    public List<WeaponItem> Weapons;
    //public List<ArmorItem> Armor;
    public ArmorItem Armor;
    public List<ModuleItem> Modules;
    public EngineItem Engine;
    public int Driver;
    public string ChassisID = "Fox";
    public bool Selected; // only used in the garage to determine which vehicles you're bringing to the next event
    //public List<ModItem> Mods;
    //public Pilot Pilot;

    public Vehicle()
    {
        Chassis = GameInfo.Chassis[Random.Range(0, GameInfo.Chassis.Count)];
        Weapons = new List<WeaponItem>();
        for (int i = 0; i < Chassis.WeaponMountsCount(); i++)
        {
            //Weapons.Add(Resources.Load<WeaponItem>($"Item/Weapon/TestGun"));
            Weapons.Add(GameInfo.Weapons[Random.Range(0, GameInfo.Weapons.Count)]);
        }

        //Armor = new List<ArmorItem>();
        // for (int i = 0; i < 4; i++)
        // {
        //     Armor.Add(GameInfo.Armors[Random.Range(0, GameInfo.Armors.Count)]);
        // }
        Armor = GameInfo.Armors[Random.Range(0, GameInfo.Armors.Count)];

        Modules = new List<ModuleItem>();

        Engine = GameInfo.Engines[Random.Range(0, GameInfo.Engines.Count)];

        Driver = Random.Range(1, 5);
    }

    public Vehicle(Chassis chassis)
    {
        Chassis = chassis;
        Weapons = new List<WeaponItem>();
        for (int i = 0; i < Chassis.WeaponMountsCount(); i++)
        {
            Weapons.Add(Resources.Load<WeaponItem>($"Item/Weapon/TestGun"));
        }
        
        // Armor = new List<ArmorItem>();
        // for (int i = 0; i < 4; i++)
        // {
        //     Armor.Add(new ArmorItem());
        // }
        Armor = GameInfo.Armors[Random.Range(0, GameInfo.Armors.Count)];
        
        Modules = new List<ModuleItem>();

        Engine = GameInfo.Engines[Random.Range(0, GameInfo.Engines.Count)];

        Selected = true;

        Driver = 0;
    }

    public Chassis GetChassis()
    {
        return Resources.Load<GameObject>($"Chassis/{ChassisID}").GetComponent<Chassis>();
    }

    public GameObject Spawn(Transform parent, Vector3 position = new Vector3())
    {
        VehicleController spawnedVehicle = Object.Instantiate(Chassis.gameObject, parent).GetComponent<VehicleController>();
        spawnedVehicle.Initialize(this);
        spawnedVehicle.transform.localPosition = position;
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
        spawnedVehicle.Initialize(this);
        spawnedVehicle.transform.localScale = Vector3.one * 2;
        // load weapons
        List<WeaponMount> weaponMounts = spawnedVehicle.WeaponMounts;

        for (int i = 0; i < weaponMounts.Count; i++)
        {
            WeaponSlot ws = Object.Instantiate(GameInfo.WeaponSlotPrefab, spawnedVehicle.transform).GetComponent<WeaponSlot>();
            ws.Initialize(this, i);

            if (i < Weapons.Count && Weapons[i] != null)
            {
                weaponMounts[i].SetWeapon(Weapons[i].prefab);
            }
        }
        return spawnedVehicle.gameObject;
    }

    public int GetWeight()
    {
        int weight = 0;
        weight += Chassis.BaseWeight;
        foreach (WeaponItem i in Weapons)
        {
            weight += i.weight;
        }
        // foreach (ArmorItem i in Armor)
        // {
        //     weight += i.weight;
        // }
        weight += Armor.weight;
        foreach (ModuleItem i in Modules)
        {
            weight += i.weight;
        }

        if (Engine != null) weight += Engine.weight;

        return weight;
    }

    public int GetMaxHitPoints()
    {
        int total = 0;
        total += Chassis.HitPoints;
        // foreach (ArmorItem i in Armor)
        // {
        //     if (i != null)
        //     {
        //         total += i.HitPoints;
        //     }
        // }
        total += Armor.HitPoints;

        return total;
    }
}
