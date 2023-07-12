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
    private List<BattleTeam> _teams;
    private List<List<VehicleController>> _spawnedVehicles;
    private Arena _arena;

    private Transform _battleRoot; // transform which is parent to everything that can be deleted once the battle is over 
    private int _winnerIndex;
    private bool _battleReportActive;
    private string _winText = "";
    
    private Camera _mainCamera;

    void Awake()
    {
        GameInfo.BattleManager = this;
        gameObject.SetActive(false);
        _mainCamera = Camera.main;
    }

    void Start()
    {
    }

    void OnEnable()
    {
        _winnerIndex = -1;
        _battleReportActive = false;
    }

    void FixedUpdate()
    {
        if (_winnerIndex == -1)
        {
            CheckForWinner();
        }
    }

    private void OnGUI()
    {
        if (_winnerIndex == -1)
        {
            GUILayout.BeginArea(new Rect(10, 10, 200, 400));
            GUILayout.BeginVertical("Battle Info", GUI.skin.box);
            GUILayout.Space(20);
            for (int i = 0; i < _teams.Count; i++)
            {
                GUILayout.Label($"Team {_teams[i].Name}");
                for (int j = 0; j < _spawnedVehicles[i].Count; j++)
                {
                    GUILayout.Label($"  {_spawnedVehicles[i][j].name}, {_spawnedVehicles[i][j].GetHitPoints()}/{_spawnedVehicles[i][j].GetMaxHitPoints()}");
                }
                GUILayout.Space(10);
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
        
        if (_battleReportActive)
        {
            GUI.Box(new Rect(Screen.width/2-100, Screen.height/2-200, 200, 400), _winText);
            if (GUI.Button(new Rect(Screen.width/2-40, Screen.width/2+20, 80, 20), "Continue"))
            {
                GameInfo.CloseLoadingDoors(LoadTournamentScene);
                _battleReportActive = false;
            }
        }
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
            _winText = "Something's gone wrong, All teams are dead. Declaring team 0 the winner";
            _winnerIndex = 0;
            _battleReportActive = true;
        }

        if (teamsAlive == 1)
        {
            _winText = $"Match Complete!\n\nThe winner is:\n{_teams[winningTeam].Name}";
            _winnerIndex = winningTeam;
            _battleReportActive = true;
        }
    }

    public void StartMatch(Match match, GameObject arena)
    {
        _battleRoot = new GameObject("battleRoot").transform;
        _battleRoot.parent = transform;
        _teams = match.GetMatchEntrantTeams();
        _arena = Instantiate(arena, _battleRoot).GetComponent<Arena>();
        
        _mainCamera.orthographicSize = 720;

        SpawnTeams();
    }

    // UNFINISHED, probably not ready for multi vehicle teams
    public void SpawnTeams()
    {
        _spawnedVehicles = new List<List<VehicleController>>();
        for (int i = 0; i < _teams.Count; i++)
        {
            _spawnedVehicles.Add(new List<VehicleController>());
            for (int j = 0; j < _teams[i].Vehicles.Count; j++)
            {
                GameObject g = _teams[i].Vehicles[j].Spawn(_battleRoot);
                
                // GameObject g = Instantiate(_teams[i].Vehicles[j].GetChassis().gameObject, _battleRoot);
                _spawnedVehicles[i].Add(g.GetComponent<VehicleController>());
                _spawnedVehicles[i][j].transform.position = _arena.spawnPoints[i].position;
                // _spawnedVehicles[i][j].Initialize(_teams[i].Vehicles[j]);
            }
        }
    }

    private void LoadTournamentScene()
    {
        Destroy(_battleRoot.gameObject);
        gameObject.SetActive(false);
        GameInfo.TournamentManager.gameObject.SetActive(true);
        GameInfo.TournamentManager.MatchWon(_winnerIndex);
    }

    public Transform GetBattleRoot()
    {
        return _battleRoot;
    }

    public List<VehicleController> GetVehicles()
    {
        List<VehicleController> ret = new List<VehicleController>();
        foreach (List<VehicleController> team in _spawnedVehicles)
        {
            foreach (VehicleController vehicle in team)
            {
                ret.Add(vehicle);
            }
        }
        return ret;
    }
}