using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

// One big singleton for various purposes. Primarily stores game state and references to managers
public static class GameInfo
{
    // Gamestate
    public static Campaign Campaign;
    
    // Content
    public static DateTime StartDate = new DateTime(1995, 1, 1);
    public static List<TournamentSeries> TournamentSeries;
    public static List<EquippableItem> Items;
    public static List<ArmorItem> Armors; // these more specific item lists may be redundant.
    public static List<EngineItem> Engines;
    public static List<ModuleItem> Modules;
    public static List<WeaponItem> Weapons;
    public static List<Chassis> Chassis;
    
    // GlobalData content
    public static Color TextPositiveColor;
    public static Color TextNegativeColor;
    public static GameObject WeaponSlotPrefab;
    
    
    
    // The Omnibullet
    public static GameObject Bullet;

    // Manager links
    // Each field is populated by it's respective class in Awake(), values will be null prior to this.
    public static LoadingDoors LoadingDoors;
    public static MainMenu MainMenu;
    public static Headquarters Headquarters;
    public static Calendar Calendar;
    public static Garage Garage;
    public static Catalog Catalog;
    public static TrophyRoom TrophyRoom;
    public static TournamentManager TournamentManager;
    public static TournamentVendorManager TournamentVendorManager;
    public static BattleManager BattleManager;


    private static string[] _names;

    static GameInfo()
    {
        LoadContent();
        
        // This depends on content being loaded and thus must be done after LoadContent();
        //Campaign = new Campaign();
    }

    // This does not respect the async features of the unity addressables system.
    // If inital load times become a problem, try doing that.
    private static void LoadContent()
    {
        string loadLog = "";
        
        // Load Global Data
        
        // Load Tournament Series
        TournamentSeries = Resources.LoadAll<TournamentSeries>("Tournament").ToList();
        loadLog += $"Loaded {TournamentSeries.Count} tournament series";

        // Load the Omnibullet
        Bullet = Resources.Load<GameObject>("Bullet");
        // Bullet = Addressables.LoadAssetAsync<GameObject>("Bullet.prefab").WaitForCompletion();

        // Load the list of names
        _names = Resources.Load<TextAsset>("names").text.Split("\n");
        loadLog += $"\nLoaded {_names.Length} names";
        
        // Load Chassis
        loadLog += "\n\n ---- LOADING CHASSIS ----";
        Chassis = new List<Chassis>();
        foreach (GameObject i in Resources.LoadAll<GameObject>("Chassis/"))
        {
            Chassis.Add(i.GetComponent<Chassis>());
            loadLog += $"\n{i.name}";
        }

        // Load Items
        Items = new List<EquippableItem>();
        Armors = new List<ArmorItem>();
        Engines = new List<EngineItem>();
        Modules = new List<ModuleItem>();
        Weapons = new List<WeaponItem>();
        
        loadLog += "\n\n ---- LOADING ARMORS ----";
        foreach (var i in Resources.LoadAll<ArmorItem>("Item/Armor/"))
        {
            Items.Add(i);
            Armors.Add(i);
            loadLog += $"\n{i.name}";
        }
        loadLog += "\n\n ---- LOADING ENGINES ----";
        foreach (var i in Resources.LoadAll<EngineItem>("Item/Engine/"))
        {
            Items.Add(i);
            Engines.Add(i);
            loadLog += $"\n{i.name}";
        }
        loadLog += "\n\n ---- LOADING MODULES ----";
        foreach (var i in Resources.LoadAll<ModuleItem>("Item/Module/"))
        {
            Items.Add(i);
            Modules.Add(i);
            loadLog += $"\n{i.name}";
        }
        loadLog += "\n\n ---- LOADING WEAPONS ----";
        foreach (var i in Resources.LoadAll<WeaponItem>("Item/Weapon/"))
        {
            Items.Add(i);
            Weapons.Add(i);
            loadLog += $"\n{i.name}";
        }

        loadLog += "\n\n loading GlobalData";
        GlobalData gd = Resources.Load<GlobalData>("GlobalData");
        TextPositiveColor = gd.textPositiveColor;
        TextNegativeColor = gd.textNegativeColor;
        WeaponSlotPrefab = gd.weaponSlotPrefab;
        
        Debug.Log(loadLog);
    }

    // Call this to initiate the door closing animation, and pass a function to be executed when the doors are closed.
    public static void CloseLoadingDoors(Action onDoorsClosed)
    {
        LoadingDoors.CloseDoors(onDoorsClosed);
    }

    public static string GetName()
    {
        return _names[Random.Range(0, _names.Length)];
    }
    
    // This returns the parent transform to all battle scene GameObjects, it is destroyed when battle ends
    public static Transform GetBattleRoot()
    {
        return BattleManager.GetBattleRoot();
    }
}
