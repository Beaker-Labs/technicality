using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;

// base class for other driver scripts to override.
// Finds the nearest enemy and drives towards it while shooting
// once there are several AIs, this class should be made abstract
public class Driver
{
    public float Steer;
    public float Throttle;
    public bool TargetSet;
    public Vector3 Target;
    public bool Fire;

    private VehicleController _parent;

    public Driver(VehicleController parent)
    {
        _parent = parent;
    }

    private VehicleController NearestEnemy()
    {
        VehicleController nearestVehicle = null;
        float shortestDistance = Mathf.Infinity;
        foreach (VehicleController vehicle in GameInfo.BattleManager.GetVehicles())
        {
            if (vehicle == _parent) continue;

            float distance = Vector3.Distance(_parent.transform.position, vehicle.transform.position);

            if (distance < shortestDistance)
            {
                nearestVehicle = vehicle;
                shortestDistance = distance;
            }
        }

        return nearestVehicle;
    }
    
    public virtual void Update()
    {
        VehicleController targettedEnemy = NearestEnemy();
        TargetSet = true;
        Target = targettedEnemy.transform.position;
        Fire = true;
        Steer = (Time.time % 2) - 1;
        Throttle = 0.5f;
    }
}
