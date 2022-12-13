using System;
using System.Threading.Tasks;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Serialization;

// This is the manager script for the Garage scene.
public class Garage : MonoBehaviour
{
    private int _selectedVehicle;
    public VehicleController activeVehicleInstance;
    public Transform vehicleHolder;
    public ItemSelector itemSelector;

    void Awake()
    {
        GameInfo.Garage = this;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        SelectVehicle(0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
