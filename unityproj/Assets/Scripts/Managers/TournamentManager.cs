using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TournamentManager : MonoBehaviour
{
    [Header("Public Things")] private string _name;
    private Match _bracket; // This is the root match of the bracket
    private Match _nextMatch; // This is the next/current match to play
    private TournamentSeries _template;

    [Header("Object Links")] 
    public TextMeshProUGUI NextMatchTitleText;
    public Button NextMatchButton;
    public TextMeshProUGUI NextMatchButtonText;

    private string _betMessage;
    private int _betTeam;
    private int _betSize;
    

    void Awake()
    {
        GameInfo.TournamentManager = this;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // OnEnable is called when the object is enabled
    // for this script that happens whenever it's screen is loaded
    // that can happen either while starting a tournament or finishing a match within the tournament
    void OnEnable()
    {

    }

    // Generate a populated bracket based on Template
    public void SetupTournament(TournamentSeries template, string eventName)
    {
        _name = eventName;
        _template = template;
        _bracket = new Match(template.Stages);
        _nextMatch = _bracket.GetNextMatch();

        BattleTeam playerTeam = GameInfo.Campaign.GetBattleTeam();
        if (playerTeam.Vehicles.Count > 0)
        {
            _nextMatch.Entrants[0].Winner.PlayerControlled = true;
            _nextMatch.Entrants[0].Winner.Vehicles = GameInfo.Campaign.GetBattleTeam().Vehicles;
            _nextMatch.Entrants[0].Winner.Vehicles[0].Driver = 0; // Unnecessary, remove?
            _nextMatch.Entrants[0].Winner.Name = GameInfo.Campaign.TeamName;
        }
        else
        {
            Debug.Log("player entered as spectator");
        }

        Debug.Log($"Generated bracket as follows: {_bracket.DebugString()}\nNext match is:{_nextMatch.GetMatchName()}");

        NextMatchTitleText.text = _nextMatch.GetMatchName() + "\n" + _bracket.DebugString();
        NextMatchButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width-210, 10, 200, 600));
        GUILayout.BeginVertical("Betting", GUI.skin.box);
        GUILayout.Space(20);
        GUILayout.Label(_betMessage);
        GUILayout.Label($"Your Cash: {GameInfo.Campaign.Cash}");
        for (int i = 0; i < _nextMatch.Entrants.Count; i++)
        {
            string tInfo = $"Team {_nextMatch.Entrants[i].Winner.Name}";
            // GUILayout.Label(tInfo);

            if (GUILayout.Toggle(_betTeam == i, tInfo))
            {
                _betTeam = i;
            }
        }

        if (GUILayout.Button("Increase Bet"))
        {
            _betSize += 100;
        }
        
        GUILayout.Label($"Final Bet:\n{_betSize} on {_nextMatch.Entrants[_betTeam].Winner.Name}");
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    public void StartNextMatch()
    {
        if (_bracket.Winner != null)
        {
            if (_bracket.Winner.PlayerControlled)
            {
                GameInfo.Campaign.Cash += _template.Prize;
            }
            GameInfo.CloseLoadingDoors(LoadHQScene);
        }
        else
        {
            GameInfo.CloseLoadingDoors(LoadBattleScene);
        }
    }

    // is called by battlemanager when a match finishes
    public void MatchWon(int winnerIndex)
    {
        if (_betSize > 0)
        {
            if (_betTeam == winnerIndex)
            {
                _betMessage = $"Wow! you won ${_betSize} on the last match!";
                GameInfo.Campaign.Cash += _betSize;
            }
            else
            {
                _betMessage = $"you lost ${_betSize} on the last match, but I'm sure you'll win it all back this time.";
                GameInfo.Campaign.Cash -= _betSize;
            }
        }
        else
        {
            _betMessage = $"Try your luck! I've got a good feeling about [team]!";
        }

        _betSize = 0;
        _betTeam = 0;
        
        Debug.Log($"MatchWon({winnerIndex})");
        _nextMatch.Winner = _nextMatch.Entrants[winnerIndex].Winner;
        if (_nextMatch == _bracket)
        {
            Debug.Log("Tournament won by" + _nextMatch.Winner);
            NextMatchTitleText.text = _bracket.Winner.Name + " Won!";
            NextMatchButton.gameObject.SetActive(false);
            return;
        }
        string winnername = _nextMatch.Winner.Name;
        _nextMatch = _bracket.GetNextMatch();
        Debug.Log($"Match won by {winnername}, Next match is {_nextMatch.GetMatchName()}\nState of the bracket: {_bracket.DebugString()}");
        
        NextMatchTitleText.text = _nextMatch.GetMatchName() + "\n" + _bracket.DebugString();
    }

    public void SkipNextMatch()
    {
        
    }

    // Placeholder method to escape the tournament screen
    public void WinTournament()
    {
        GameInfo.CloseLoadingDoors(LoadHQScene);
        GameInfo.Campaign.Cash += _template.Prize;
    }

    private void LoadHQScene()
    {
        GameInfo.Campaign.Month++;
        gameObject.SetActive(false);
        GameInfo.Headquarters.gameObject.SetActive(true);
    }

    private void LoadBattleScene()
    {
        gameObject.SetActive(false);
        GameInfo.BattleManager.gameObject.SetActive(true);
        GameInfo.BattleManager.SetupMatch(_nextMatch, _template.Arena);
    }
}