using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlledDriver : Driver
{
    private InputMaster _input;
    private Camera _mainCam;
    
    public PlayerControlledDriver(VehicleController parent) : base(parent)
    {
        _input = new InputMaster();
        _input.Vehicle.Enable();
        _mainCam = Camera.main;
    }

    public override void Update()
    {
        // Movement control
        Steer = _input.Vehicle.Left.ReadValue<float>() - _input.Vehicle.Right.ReadValue<float>();
        Throttle = _input.Vehicle.Forward.ReadValue<float>() - _input.Vehicle.Backward.ReadValue<float>();

        // Aim and firing
        TargetSet = true;
        Target = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Fire = _input.Vehicle.Fire.ReadValue<float>() > 0.5;
    }
}
