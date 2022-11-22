using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// One big singleton for various purposes. Primarily stores game state and references to managers
public static class GameInfo
{
    public static Campaign Campaign;
    public static DateTime StartDate = new DateTime(2035, 1, 1);
    public static TournamentSeries[] TournamentSeries;
    
    // Manager links
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
    }

    public static void CloseLoadingDoors(Action onDoorsClosed)
    {
        LoadingDoors.CloseDoors(onDoorsClosed);
    }
}
