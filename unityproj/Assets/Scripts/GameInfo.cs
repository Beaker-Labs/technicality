using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// One big singleton for various purposes. Primarily stores game state and references to managers
public static class GameInfo
{
    // Gamestate
    public static Campaign Campaign;
    
    // Content
    public static DateTime StartDate = new DateTime(2035, 1, 1);
    public static TournamentSeries[] TournamentSeries;
    
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

    static GameInfo()
    {
        Campaign = new Campaign();
        TournamentSeries = Resources.LoadAll<TournamentSeries>("Tournaments");
        Bullet = Resources.Load<GameObject>("Bullet");
    }

    // Call this to initiate the door closing animation, and pass a function to be executed when the doors are closed.
    public static void CloseLoadingDoors(Action onDoorsClosed)
    {
        LoadingDoors.CloseDoors(onDoorsClosed);
    }
}
