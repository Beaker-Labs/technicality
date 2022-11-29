using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{
    [Header("Public Things")] private string _name;
    private Match _bracket; // This is the root match of the bracket
    private Match _nextMatch; // This is the next/current match to play
    private TournamentSeries _template;

    [Header("Object Links")] 
    public TextMeshProUGUI NextFightTitleText;
    public TextMeshProUGUI NextFightButtonText;


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
        _nextMatch.Entrants[0].Winner.PlayerControlled = true;
        _nextMatch.Entrants[0].Winner.Name = "Player";
        Debug.Log(_bracket.DebugString());
        Debug.Log(_nextMatch.GetMatchName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNextMatch()
    {
        GameInfo.CloseLoadingDoors(LoadBattleScene);
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
        GameInfo.BattleManager.StartMatch(_bracket.GetNextMatch(), _template.Arena);
    }
}