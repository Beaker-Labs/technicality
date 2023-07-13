using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FlankingDriver will try to drive to a point 200u away from the enemy, 90 degrees around them relative to it's own position
public class FlankingDriver : Driver
{
    public FlankingDriver(VehicleController parent) : base(parent) { }

    public override void Update()
    {
        VehicleController targettedEnemy = NearestEnemy();
        TargetSet = true;
        Target = targettedEnemy.transform.position;
        Fire = true;
        DriveTowards(200 * Vector3.Cross(Vector3.forward, Vector3.Normalize(Target - Parent.transform.position)));
    }
}