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

            if (!vehicle.IsAlive()) continue;

            float distance = Vector3.Distance(Parent.transform.position, vehicle.transform.position);

            if (distance < shortestDistance)
            {
                nearestVehicle = vehicle;
                shortestDistance = distance;
            }
        }

        return nearestVehicle;
    }

    protected void DriveTowards(Vector3 destination)
    {
        Vector3 destDir = Vector3.Normalize(destination - Parent.transform.position);
        Vector3 crossDestDir = Vector3.Cross(destDir, Vector3.forward);
        Steer = Vector3.Dot(crossDestDir, Parent.transform.up);
        Throttle = Vector3.Dot(destDir, Parent.transform.up);
    }

    public abstract void Update();

}
