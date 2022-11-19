using System;
using System.Collections.Generic;
using UnityEngine;

// not the same kind of thing as Team!
// This resource can supply a team to fill out the CPU roster of a tournament.
public class NPCTeam : ScriptableObject
{
    public string Name = "";
    public List<Vehicle> Vehicles;
    
    // for later, so NPCTeams can build custom technicals,
    // and upgrade alongside the player
    public List<EquippableItem> Inventory; 
}
