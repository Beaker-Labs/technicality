using System;
using UnityEditor.Build.Content;
using UnityEngine;

// This is the manager script for the Garage scene.
public class Garage : MonoBehaviour
{
    private int _selectedVehicle;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNextVehicle()
    {
        
    }

    public void SelectPreviousVehicle()
    {
        
    }
}
