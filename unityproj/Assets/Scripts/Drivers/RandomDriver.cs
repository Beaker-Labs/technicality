using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// RandomDriver picks a random point, drives to it, and repeats.
public class RandomDriver : Driver
{
    private Vector3 _destination = Vector3.zero;
    
    public RandomDriver(VehicleController parent) : base(parent) { }

    public override void Update()
    {
        if (_destination == Vector3.zero || Vector2.Distance(Parent.transform.position, _destination) < 50)
        {
            _destination = new Vector3(Random.Range(-700, 700), Random.Range(-700, 700), 0);
        }
        VehicleController targettedEnemy = NearestEnemy();
        TargetSet = true;
        Target = targettedEnemy.transform.position;
        Fire = true;
        DriveTowards(_destination);
    }
}