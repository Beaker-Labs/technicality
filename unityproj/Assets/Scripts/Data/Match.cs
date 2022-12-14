using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a recursive representation of the tournament bracket.
// Each Match object represents one match within the wider bracket.
// At the bottom of the bracket, matches are created with no entrants and a winner already set.
// Do not assume all Matches have entrants!
public class Match
{
    public BattleTeam Winner = null;
    public List<Match> Entrants = new List<Match>();
    public int Depth;
    
    // This constructor takes a list of stages, like how the shape of a tournament is defined in TournamentSeries.Stages
    public Match(List<int> stages, int depth = 0)
    {
        Depth = depth;

        if (stages.Count == 0)
        {
            Winner = new BattleTeam();
            Winner.Name = GameInfo.GetName();
            Winner.Vehicles.Add(new Vehicle());
        }
        else
        {
            List<int> stagesSubOne = stages.GetRange(1, stages.Count - 1);
            for (int i = 0; i < stages[0]; i++)
            {
                Entrants.Add(new Match(stagesSubOne, depth+1));
            }
        }
    }

    // ---- Currently Unused ----
    // This constructor is for the 'fake' brackets at the bottom of the tree, which
    // contain a 'winner' (entrant) by default and no deeper brackets.
    public Match(BattleTeam battleTeam)
    {
        Winner = battleTeam;
    }

    public List<BattleTeam> GetMatchEntrantTeams()
    {
        List<BattleTeam> teams = new List<BattleTeam>();
        foreach (Match i in Entrants)
        {
            if (i.Winner == null)
            {
                throw new Exception("GetMatchEntrantTeams() was called on a match with undetermined entrants");
            }
            teams.Add(i.Winner);
        }
        return teams;
    }

    // Traverses the tree to find the deepest match with full entrants
    public Match GetNextMatch(int depth = 0)
    {
        // get mad if used improperly
        if (Winner != null)
        {
            throw new Exception("GetNextMatch() was called on a Match that already had a defined winner");
        }

        // if any of the entrant selecting matches haven't been decided yet,
        // Recursively search for the deepest match
        Match deepestMatch = this;
        for (int i = 0; i < Entrants.Count; i++)
        {
            if (Entrants[i].Winner == null)
            {
                Match m = Entrants[i].GetNextMatch();
                if (m.Depth > deepestMatch.Depth)
                {
                    deepestMatch = m;
                }
            }
        }

        return deepestMatch;
    }
    

    public string GetMatchName()
    {
        
        // when the first condition is true the second should always be too
        if (Entrants.Count == 0 && Winner != null)
        {
            return Winner.Name;
        }

        string matchName = Entrants[0].Winner == null ? "???" : $"{Entrants[0].Winner.Name}";
        
        for (int i = 1; i < Entrants.Count; i++)
        {
            matchName += Entrants[i].Winner == null ? " vs. ???" : $" vs. {Entrants[i].Winner.Name}";
        }

        return matchName;
    }

    public string DebugString()
    {
        if (Winner != null)
        {
            return Winner.Name;
        }

        string ret = "(" + Entrants[0].DebugString();
        for (int i = 1; i < Entrants.Count; i++)
        {
            ret += ", " + Entrants[i].DebugString();
        }
        ret += ")";
        return ret;
    }
}

