using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;

// base class for other driver scripts to override.
public abstract class Driver
{
    public float Steer;
    public float Throttle;
    public bool TargetSet;
    public Vector3 Target;
    public bool Fire;

    protected VehicleController Parent;

    protected Driver(VehicleController parent)
    {
        Parent = parent;
    }

    protected VehicleController NearestEnemy()
    {
        VehicleController nearestVehicle = null;
        float shortestDistance = Mathf.Infinity;
        foreach (VehicleController vehicle in GameInfo.BattleManager.GetVehicles())
        {
            if (vehicle == Parent) continue;

            float distance = Vector3.Distance(Parent.transform.position, vehicle.transform.position);

            if (distance < shortestDistance)
            {
                nearestVehicle = vehicle;
                shortestDistance = distance;
            }
        }

        return nearestVehicle;
    }

    public abstract void Update();

}
