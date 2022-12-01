using System;
using System.Collections.Generic;
using Unity;
using UnityEngine;

// This is the manager script for the battle scene, and is responsible for:
// - loading the map
// - spawning in all the relevant teams
// - detecting when a team wins the battle, and transitioning back to the tournament screen
//
// WARNING: BIG MESS
public class BattleManager : MonoBehaviour
{
    public GameObject placeholderVehicle;
    private List<Team> _teams;
    private List<List<Chassis>> _spawnedVehicles;
    private Arena _arena;

    private Transform _temp; // transform which is parent to everything that can be deleted once the battle is over 
    private int _winnerIndex;


    void Awake()
    {
        GameInfo.BattleManager = this;
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
    }

    void FixedUpdate()
    {
        CheckForWinner();
    }

    private void CheckForWinner()
    {
        // Bypass if check already succeeded and loading doors haven't closed yet
        if (GameInfo.LoadingDoors.AreDoorsClosing()) return;
        
        int teamsAlive = 0;
        int winningTeam = 0;
        for (int i = 0; i < _spawnedVehicles.Count; i++)
        {
            bool teamDead = true;
            for (int j = 0; j < _spawnedVehicles[i].Count; j++)
            {
                if (_spawnedVehicles[i][j].IsAlive())
                {
                    teamDead = false;
                }
            }

            if (!teamDead)
            {
                teamsAlive++;
                winningTeam = i;
            }
        }

        if (teamsAlive == 0)
        {
            Debug.Log("Something's gone wrong, All teams are dead. Declaring team 0 the winner");
            _winnerIndex = 0;
            GameInfo.CloseLoadingDoors(LoadTournamentScene);
        }

        if (teamsAlive == 1)
        {
            _winnerIndex = winningTeam;
            GameInfo.CloseLoadingDoors(LoadTournamentScene);
        }
    }

    public void StartMatch(Match match, GameObject arena)
    {
        _temp = new GameObject("temp").transform;
        _temp.parent = transform;
        _teams = match.GetMatchEntrantTeams();
        _arena = Instantiate(arena, _temp).GetComponent<Arena>();

        SpawnTeams();
    }


    // UNFINISHED, probably not ready for multi vehicle teams
    public void SpawnTeams()
    {
        _spawnedVehicles = new List<List<Chassis>>();
        for (int i = 0; i < _teams.Count; i++)
        {
            _spawnedVehicles.Add(new List<Chassis>());
            for (int j = 0; j < _teams[i].Vehicles.Count; j++)
            {
                GameObject g = Instantiate(_teams[i].Vehicles[j].GetChassis().gameObject, _temp);
                _spawnedVehicles[i].Add(g.GetComponent<Chassis>());
                _spawnedVehicles[i][j].transform.position = _arena.spawnPoints[i].position;
            }
        }
        
        // Placeholder, enable player control of vehicle 1
        _spawnedVehicles[0][0].isPlayerControlled = true;
    }

    private void LoadTournamentScene()
    {
        Destroy(_temp.gameObject);
        gameObject.SetActive(false);
        GameInfo.TournamentManager.gameObject.SetActive(true);
        GameInfo.TournamentManager.MatchWon(_winnerIndex);
    }

    public Transform GetBattleRoot()
    {
        return _temp;
    }
}