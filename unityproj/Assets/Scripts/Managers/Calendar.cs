using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Calendar : MonoBehaviour
{
    // [Header("Object Links")] 
    private UIDocument _uiDocument;
    private VisualElement _calendarRoot;
    private Label _dateText;
    private Label _selectedTourneyName;
    private Label _selectedTourneyDescription;
    private ListView _tournamentList;
    private Button _goButton;
    private Button _nextMonthButton;
    private Button _prevMonthButton;
    private Button _resetMonthButton;
    
    private List<TournamentSeries> _tournaments;
    private TournamentSeries _selectedTournament;

    private bool _active;
    private int _viewedMonth;


    void Awake()
    {
        GameInfo.Calendar = this;
    }

    private void Start()
    {
        _uiDocument = GetComponent<UIDocument>();
        _calendarRoot = _uiDocument.rootVisualElement.Q<VisualElement>("CalendarRoot");
        _dateText = _calendarRoot.Q<Label>("Date");
        _selectedTourneyName = _calendarRoot.Q<Label>("TournamentName");
        _selectedTourneyDescription = _calendarRoot.Q<Label>("TournamentDescription");
        _tournamentList = _calendarRoot.Q<ListView>("TournamentList");
        _goButton = _calendarRoot.Q<Button>("TournamentStartButton");
        _goButton.clicked += StartTournament;

        _nextMonthButton = _calendarRoot.Q<Button>("NextMonth");
        _nextMonthButton.clicked += NextMonth;
        _prevMonthButton = _calendarRoot.Q<Button>("PrevMonth");
        _prevMonthButton.clicked += PrevMonth;
        _resetMonthButton = _calendarRoot.Q<Button>("PresentMonthButton");
        _resetMonthButton.clicked += ResetMonth;

        _viewedMonth = 0;
        _tournaments = new List<TournamentSeries>();
        _tournaments.Add(Resources.Load<TournamentSeries>("Tournament/Johning"));

        // ReloadList();
        

        // The "makeItem" function will be called as needed
        // when the ListView needs more items to render
        Func<VisualElement> makeItem = () => new Label();
        
        // As the user scrolls through the list, the ListView object
        // will recycle elements created by the "makeItem"
        // and invoke the "bindItem" callback to associate
        // the element with the matching data item (specified as an index in the list)
        Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = _tournaments[i].GetMonthName(_viewedMonth);
        
        _tournamentList.makeItem = makeItem;
        _tournamentList.bindItem = bindItem;
        _tournamentList.itemsSource = _tournaments;
        _tournamentList.selectionType = SelectionType.Single;
        
        // Callback invoked when the user double clicks an item
        _tournamentList.itemsChosen += Debug.Log;
        
        // Callback invoked when the user changes the selection inside the ListView
        _tournamentList.selectionChanged += SelectTournament;
    }

    void ReloadList()
    {
        // disable the reset month button if current month is already selected
        _resetMonthButton.SetEnabled(_viewedMonth != GameInfo.Campaign.Month);


        DateTime currentDate = GameInfo.StartDate.AddMonths(_viewedMonth);
        _dateText.text = $"{currentDate.ToString("MMMM yyyy")}";

        // _tournaments = new List<TournamentSeries>();
        _tournaments.Clear();

        
        foreach (TournamentSeries i in GameInfo.TournamentSeries)
        {
            if (i.IsEntryForMonth(_viewedMonth))
            {
                _tournaments.Add(i);
            }
        }
        
        if (_tournaments.Count > 0)
        {
            if (_viewedMonth == GameInfo.Campaign.Month && _selectedTournament != null)
            {
                _tournamentList.SetSelection(_tournaments.IndexOf(_selectedTournament));
            }
            else
            {
                _tournamentList.SetSelection(0);
            }
            SelectTournament();
        }
        else
        {
            SelectNone();
        }

        _tournamentList.RefreshItems();
    }

    public void SelectTournament()
    {
        int index = _tournamentList.selectedIndex;
        if (_viewedMonth == GameInfo.Campaign.Month)
        {
            _selectedTournament = _tournaments[index];
        }
        _selectedTourneyName.text = _tournaments[index].GetMonthName(_viewedMonth);
        _selectedTourneyDescription.text = _tournaments[index].GetDescription();
    }
    
    private void SelectNone()
    {
        _selectedTourneyName.text = "";
        _selectedTourneyDescription.text = "";
    }

    public void Activate()
    {
        _active = true;
        _calendarRoot.style.display = DisplayStyle.Flex;
        _viewedMonth = GameInfo.Campaign.Month;
        ReloadList();
        
    }

    public void Deactivate()
    {
        _active = false;
        _calendarRoot.style.display = DisplayStyle.None;
    }

    void NextMonth()
    {
        _viewedMonth++;
        ReloadList();
    }

    void PrevMonth()
    {
        _viewedMonth--;
        ReloadList();
    }
    
    private void ResetMonth()
    {
        _viewedMonth = GameInfo.Campaign.Month;
        ReloadList();
    }

    public void SelectTournament(IEnumerable<object> selectedItems)
    {
        SelectTournament();
    }
    
    public void StartTournament()
    {
        GameInfo.CloseLoadingDoors(LoadTournamentScene);
    }

    private void LoadTournamentScene()
    {
        GameInfo.Campaign.Cash -= _selectedTournament.EntryFee;
        
        GameInfo.TournamentManager.gameObject.SetActive(true);
        GameInfo.TournamentManager.SetupTournament(_selectedTournament, name);
        
        gameObject.SetActive(false);
    }

    public TournamentSeries GetSelectedTournament()
    {
        return _selectedTournament;
    }
}
