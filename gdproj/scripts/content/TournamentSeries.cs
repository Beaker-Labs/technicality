using Godot;
using System;

// This is a data container for
public class TournamentSeries : Resource
{
    [Export] public string Name = "";
    [Export] public int Size;
    [Export] public int WeightLimit;
    [Export] public int TeamSizeMax; // leave at zero for no limit
    [Export] public int TeamSizeMin; // leave at zero for no limit
    [Export] public int EntryFee;
    [Export] public int Prize;
}
