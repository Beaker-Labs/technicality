using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

// this contains the base stats in a chassis prefab
// Formerly named VehicleController.cs
[RequireComponent(typeof(VehicleController))]
public class Chassis : MonoBehaviour
{
    [Header("Chassis Base stats")]
    public string ChassisName = "";
    [TextArea] public string Description = "";
    public int BaseWeight;
    public int WeightLimit;
    public int HitPoints;
    //public int Armor;
    public bool Amphibious; // Amphibious units can move in water
    public bool Hover; // hover units are immune to all terrain effects
    public MoveTypes MoveType;

    private VehicleController _vehicleController;

    public enum MoveTypes
    {
        Tank,
        FrontSteer,
        RearSteer,
        Omni
    }

    private void Start()
    {
        _vehicleController = GetComponent<VehicleController>();
    }
}
