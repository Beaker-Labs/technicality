using System;
using UnityEditor.Build.Content;
using UnityEngine;

// This is the manager script for the Garage scene.
public class Garage : MonoBehaviour
{
    private int _selectedVehicle;
    private Vehicle _vehicle;
    public Transform vehicleHolder;

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
        _selectedVehicle = 0;
        GameInfo.Campaign.Garage[_selectedVehicle].Instantiate(vehicleHolder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNextVehicle()
    {
        _selectedVehicle = (_selectedVehicle + 1) % GameInfo.Campaign.Garage.Count;
    }

    public void SelectPreviousVehicle()
    {
        _selectedVehicle = (_selectedVehicle - 1) % GameInfo.Campaign.Garage.Count;
    }

    public void ReturnToHQ()
    {
        GameInfo.CloseLoadingDoors(LoadHQ);
    }

    private void LoadHQ()
    {
        
    }
}
