using Godot;
using System;
using System.Collections.Generic;

// not the same kind of thing as Team!
// This resource can supply a team to fill out the CPU roster of a tournament.
public class NPCTeam : Resource
{
    [Export] public string Name = "";
    [Export] public List<Vehicle> Vehicles;
    
    // for later, so NPCTeams can build custom technicals,
    // so NPCTeams can upgrade alongside the player
    [Export] public List<EquippableItem> Inventory; 
}
