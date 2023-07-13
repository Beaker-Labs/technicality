using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AggressiveDriver will just drive straight towards the nearest enemy, firing constantly
public class AggressiveDriver : Driver
{
    public AggressiveDriver(VehicleController parent) : base(parent) { }

    public override void Update()
    {
        VehicleController targettedEnemy = NearestEnemy();
        TargetSet = true;
        Target = targettedEnemy.transform.position;
        Fire = true;
        DriveTowards(Target);
    }
}