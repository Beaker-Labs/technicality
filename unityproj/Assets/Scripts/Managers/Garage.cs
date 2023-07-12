using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

// This is the manager script for the Garage scene.
public class Garage : MonoBehaviour
{
    [Header("Object Links")]
    [SerializeField] private TextMeshProUGUI weightLimitText;
    
    private int _selectedVehicle;
    public VehicleController activeVehicleInstance;
    public Transform vehicleHolder;
    public ItemSelector itemSelector;

    private Camera _mainCamera;

    void Awake()
    {
        GameInfo.Garage = this;
        gameObject.SetActive(false);
        _mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        Debug.Log($"Garage count: {GameInfo.Campaign.Garage.Count}\n"
                        +$"first garage member name:{GameInfo.Campaign.Garage[0].Name}");
        SelectVehicle(0);
        itemSelector.Hide();
        _mainCamera.orthographicSize = 180;
        RecalculateWeight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 160, 220));
        GUILayout.BeginVertical("Garage", GUI.skin.box);
        GUILayout.Space(20);
        for (int i = 0; i < GameInfo.Campaign.Garage.Count; i++)
        {
            Vehicle v = GameInfo.Campaign.Garage[i];
            GUILayout.Label($"{v.Name}\n  Wt: {v.GetWeight()}  HP: {v.GetMaxHitPoints()}");
            v.Selected = GUILayout.Toggle(v.Selected, "On team?");
            GUILayout.Space(10);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();

        if (GUI.changed)
        {
            RecalculateWeight();
        }
    }

    public void SelectItem(Type itemType, Action<EquippableItem> setItemCallback)
    {
        itemSelector.Show(itemType, setItemCallback);
    }

    public void SelectNextVehicle()
    {
        _selectedVehicle = (_selectedVehicle + 1) % GameInfo.Campaign.Garage.Count;
        SelectVehicle(_selectedVehicle);

    }

    public void SelectPreviousVehicle()
    {
        _selectedVehicle = (_selectedVehicle - 1) % GameInfo.Campaign.Garage.Count;
        SelectVehicle(_selectedVehicle);
    }

    private void SelectVehicle(int index)
    {
        _selectedVehicle = index;
        if (vehicleHolder.childCount > 0) Destroy(vehicleHolder.GetChild(0).gameObject);
        activeVehicleInstance = GameInfo.Campaign.Garage[index].SpawnEditMode(vehicleHolder).GetComponent<VehicleController>();
        activeVehicleInstance.ActivateEditMode();
    }

    public void ReturnToHQ()
    {
        GameInfo.CloseLoadingDoors(LoadHQ);
    }

    private void LoadHQ()
    {
        GameInfo.Headquarters.gameObject.SetActive(true);
        
        gameObject.SetActive(false);
    }

    public Vehicle GetActiveVehicle()
    {
        return GameInfo.Campaign.Garage[_selectedVehicle];
    }

    public void RecalculateWeight()
    {
        Debug.Log("Recalculating Weight");

        int chassisWeight = GameInfo.Campaign.Garage[_selectedVehicle].GetWeight();
        int chassisLimit = GameInfo.Campaign.Garage[_selectedVehicle].Chassis.WeightLimit;
        int teamWeight = 0;
        int teamLimit = 0;
        if (GameInfo.Calendar.GetSelectedTournament() != null)
        {
            teamLimit = GameInfo.Calendar.GetSelectedTournament().WeightLimit;
        }
        teamWeight += GameInfo.Campaign.GetBattleTeam().GetWeight();
 
        weightLimitText.text = $"Chassis Weight: {chassisWeight}/{chassisLimit}\n" +
                               $"Team Weight: {teamWeight}/{teamLimit}";
        
        Debug.Log("Recalculated Weight");
    }
}
