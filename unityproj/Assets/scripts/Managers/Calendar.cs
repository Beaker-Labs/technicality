using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

// Manager script for the calendar scene,
// where the player can check or go to upcoming tournaments
public class Calendar : MonoBehaviour
{
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI selectedTourneyName;
    public TextMeshProUGUI selectedTourneyDescription;
    public List<Button> selectorButtons;
    private List<TournamentSeries> _tournaments;
    private TournamentSeries _selectedTournament;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    
    // OnEnable is called every time the gameobject is enabled
    void OnEnable()
    {
        int month = GameInfo.Campaign.Month;
        DateTime currentDate = GameInfo.StartDate.AddMonths(month);
        dateText.text = $"{currentDate.ToString("MMMM yyyy")}";

        _tournaments = new List<TournamentSeries>();
        foreach (TournamentSeries i in GameInfo.TournamentSeries)
        {
            if (i.IsEntryForMonth(month))
            {
                _tournaments.Add(i);
            }
        }
        
        
        for (int i = 0; i < selectorButtons.Count; i++)
        {
            if (i >= _tournaments.Count)
            {
                selectorButtons[i].gameObject.SetActive(false);
            }
            else
            {
                selectorButtons[i].gameObject.SetActive(true);
                selectorButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _tournaments[i].GetMonthName(month);
            }
        }

        if (_tournaments.Count > 0)
        {
            SelectTournament(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTournament(int index)
    {
        selectedTourneyName.text = _tournaments[index].GetMonthName(GameInfo.Campaign.Month);
        selectedTourneyDescription.text = _tournaments[index].Description;
        return;
    }
}
