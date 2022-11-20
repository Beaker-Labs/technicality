using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    public static Campaign Campaign;
    public static DateTime StartDate = new DateTime(2035, 1, 1);
    public static TournamentSeries[] TournamentSeries;

    static GameInfo()
    {
        Campaign = new Campaign();
        TournamentSeries = Resources.LoadAll<TournamentSeries>("tournaments");
    }
}
