using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This scriptableobject defines a tournament series, which can spawn tournament instances at set months within a year.
[CreateAssetMenu(fileName = "TournamentSeries", menuName = "ScriptableObjects/TournamentSeries", order = 1)]
public class TournamentSeries : ScriptableObject
{
    public string Name = "";
    [TextArea(15,20)] public string Description = "";
    public List<int> Stages; // Ex: An eight person tournament would be {2,2,2}, a same size free for all would be {8} 
    public int WeightLimit;
    public bool WeightLimitPerVehicle; // Is the weight limit per vehicle (true) or combined team weight? (false)
    public int TeamSizeMax; // leave at zero for no limit
    public int TeamSizeMin; // leave at zero for no limit
    public int EntryFee;
    public int Prize;
    public List<SeriesEntry> Entries = new List<SeriesEntry>();
    
    [Serializable] public class SeriesEntry
    {
        public string Name;
        public int Month;

        public SeriesEntry(string name, int month)
        {
            Name = name;
            Month = month;
        }
    }

    public bool IsEntryForMonth(int month)
    {
        foreach (SeriesEntry t in Entries)
        {
            if (t.Month-1 % 12 == month)
            {
                return true;
            }
        }
        return false;
    }

    public string GetMonthName(int month)
    {
        foreach (SeriesEntry t in Entries)
        {
            if (t.Month-1 % 12 == month)
            {
                string MMMM = GameInfo.StartDate.AddMonths(month).ToString("MMMM");
                string yyyy = GameInfo.StartDate.AddMonths(month).ToString("yyyy");
                return string.Format(t.Name, MMMM, yyyy);
            }
        }
        return "";
    }
}
