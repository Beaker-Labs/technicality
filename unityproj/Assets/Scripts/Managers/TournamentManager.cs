using System;
using System.Collections.Generic;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{
    public string Name;
    private Match _match;
    public TournamentSeries Template;
    
    [SerializeField] private TournamentManager tournamentManager;
    [SerializeField] private LoadingDoors loadingDoors;
    
    
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
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinTournament()
    {
        GameInfo.CloseLoadingDoors(LoadHQScene);
        GameInfo.Campaign.Cash += Template.Prize;
    }

    private void LoadHQScene()
    {
        GameInfo.Campaign.Month++;
        GetComponent<Canvas>().gameObject.SetActive(false);
        GameInfo.Headquarters.gameObject.SetActive(true);
    }
}

// This is a recursive representation of the tournament bracket.
// Each Match object represents one match within the wider bracket.
// To start the tournament, matches are created with no entrants and a winner already set.
// Do not assume all Matches have entrants!
public class Match
{
    public Team Winner = null;
    public List<Match> Entrants = null;
    
    public Match GetNextMatch()
    {
        // get mad if used improperly
        if (Winner != null)
        {
            throw new Exception("GetNextMatch() was called on a bracket that already had a defined winner");
        }
        
        // Recurse if any of the entrant selecting matches haven't been decided yet.
        foreach (Match i in Entrants)
        {
            if (i.Winner != null)
            {
                return i.GetNextMatch();
            }
        }

        // Else this must be the next match, so return this.        
        return this;
    }
}

