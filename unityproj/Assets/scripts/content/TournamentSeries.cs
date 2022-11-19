using System;
using UnityEngine;

// This is a data container for
public class TournamentSeries : ScriptableObject
{
    public string Name = "";
    public int Size;
    public int WeightLimit;
    public int TeamSizeMax; // leave at zero for no limit
    public int TeamSizeMin; // leave at zero for no limit
    public int EntryFee;
    public int Prize;
}
