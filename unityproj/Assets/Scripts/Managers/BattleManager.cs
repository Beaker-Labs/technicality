using System;
using System.Collections.Generic;
using Unity;
using UnityEngine;

// This is the manager script for the battle scene, and is responsible for:
// - loading the map
// - spawning in all the relevant teams
// - detecting when a team wins the battle, and transitioning back to the tournament screen
//
public class BattleManager : MonoBehaviour
{
    public GameObject placeholderVehicle;
    private List<Team> _teams;
    private Arena _arena;



    void Awake()
    {
        GameInfo.BattleManager = this;
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // TODO: Detect battle end
    }

    public void StartMatch(Match match, GameObject arena)
    {
        _teams = match.GetMatchEntrantTeams();
        //SpawnTeams();
        _arena = Instantiate(arena).GetComponent<Arena>();

        GameObject i;
        i = Instantiate(placeholderVehicle);
        i.transform.position = _arena.spawnPoints[0].position;
        i.GetComponent<VehicleController>().isPlayerControlled = true;

        i = Instantiate(placeholderVehicle);
        i.transform.position = _arena.spawnPoints[1].position;
    }


    // UNFINISHED
    public void SpawnTeams()
    {
        for (int i = 0; i < _teams.Count; i++)
        {
            for (int j = 0; j < _teams[i].Vehicles.Count; j++)
            {
                Instantiate(_teams[i].Vehicles[j].Chassis.Prefab);
            }
        }
    }
}
