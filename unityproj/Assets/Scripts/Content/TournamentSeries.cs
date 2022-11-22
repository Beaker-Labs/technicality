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

    /* Returns description of tournament, formatted as follows: (excluding bracketed comments)
     *
     * Weight Limit:  150 per team  (or per vehicle)
     * Max Team Size: 5             (line omitted if no limit)
     * Min Team Size: 2             (line omitted if no limit)
     * Team Size:     2             (replaces Max and Min if both are enabled and the same value)
     * Entry Fee:    $20            (if value is zero, line is replaced with "No Entry Fee")
     * Prize:        $100
     * 
     * Description Text Lorem Ipsum Dolor Lorem Ipsum Dolor Lorem Ipsum Dolor  
     *
     */
    public string GetDescription()
    {
        string ret;
        
        ret = $"Weight Limit: {WeightLimit} {(WeightLimitPerVehicle ? "Per Vehicle" : "Per Team")}\n";
        
        if (TeamSizeMax == TeamSizeMin && TeamSizeMin > 0)
        {
            ret += $"Req Vehicles: {TeamSizeMax}\n";
        }
        else
        {
            if (TeamSizeMax > 0)
            {
                ret += $"Max Team Size: {TeamSizeMax}\n";
            }

            if (TeamSizeMin > 0)
            {
                ret += $"Min Team Size: {TeamSizeMin}\n";
            }
        }

        ret += EntryFee > 0 ? $"Entry Fee: ${EntryFee}\n" : "No Entry Fee\n";
        ret += $"Prize: ${Prize}\n";
        
        ret += "\n";
        ret += Description;

        return ret;
    }
}
