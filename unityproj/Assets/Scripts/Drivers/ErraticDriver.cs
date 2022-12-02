using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErraticDriver : Driver
{
    public ErraticDriver(VehicleController parent) : base(parent) { }

    public override void Update()
    {
        VehicleController targettedEnemy = NearestEnemy();
        TargetSet = true;
        Target = targettedEnemy.transform.position;
        Fire = true;
        Steer = (Time.time % 2) - 1;
        Throttle = 0.5f;
    }
}
