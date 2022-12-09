using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMount : MonoBehaviour
{
    // maybe this should be a weapon stat?
    public float turnRate;

    public float offset; // Angle (cw) from 'forward' of the turret's resting position.
    //public bool isFixed;
    public bool fullRotation;
    public float rotationLimitMin = -180;
    public float rotationLimitMax = 180;
    
    private Vector2 _target;
    private bool _active;
    private bool _firing;
    private bool _hasWeapon = false;
    private float _currentAngle; // offset is center
    private WeaponController _weaponItem;

    // Start is called before the first frame update
    void Start()
    {
        _currentAngle = offset;
    }
    
    

    void FixedUpdate()
    {
        float desiredAngle = -offset + -transform.parent.rotation.eulerAngles.z;
        
        if (_active)
        {
            Vector2 targetDir = _target - (Vector2)transform.position;
            float targetAngle = -(Mathf.Atan2(targetDir.x, targetDir.y) * Mathf.Rad2Deg);
            // float targetAngleOriginal = targetAngle; // This is only for debug. remove when done.

            if (targetAngle > 180 + -offset + transform.parent.rotation.eulerAngles.z)
            {
                targetAngle -= 360;
            }
            
            if (targetAngle < -180 + -offset + transform.parent.rotation.eulerAngles.z)
            {
                targetAngle += 360;
            }
            
            desiredAngle += targetAngle + offset;

            // if (targetAngle == targetAngleOriginal)
            // {
            //     Debug.Log($"targetAngle: {targetAngle}, desiredAngle: {desiredAngle}");
            // }
            // else
            // {
            //     Debug.Log($"targetAngle: {targetAngle}, original targetAngle: {targetAngleOriginal}, desiredAngle: {desiredAngle}");
            // }
        }
        

        // moveTowardsAngle will cross over the back while moveTowards wont
        if (fullRotation)
        {
            _currentAngle = Mathf.MoveTowardsAngle(_currentAngle, desiredAngle, turnRate * Time.deltaTime);
        }
        else
        {
            _currentAngle = Mathf.MoveTowards(_currentAngle, desiredAngle, turnRate * Time.deltaTime);
            _currentAngle = Mathf.Clamp(_currentAngle, rotationLimitMin + -offset, rotationLimitMax + -offset);
        }

        transform.localRotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
        
        // Do the shooty if appropriate
        if (_firing && _hasWeapon)
        {
            _weaponItem.Fire();
        }
        _firing = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 5);
        
        if (fullRotation)
        {
            Gizmos.color = Color.white;
            DrawArcGizmo(transform.position, 30, 0, 360);
        }
        else
        {
            float lowerExtent = transform.parent.rotation.eulerAngles.z + rotationLimitMin + offset;
            float upperExtent = transform.parent.rotation.eulerAngles.z + rotationLimitMax + offset;
            Gizmos.color = Color.white;
            DrawArcGizmo(transform.position, 30, lowerExtent, upperExtent);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, lowerExtent) * Vector3.up * 40);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, upperExtent) * Vector3.up * 40);
        }
    }

    private void DrawArcGizmo(Vector3 center, float radius, float startAngle, float endAngle)
    {
        Vector3 pos = center + Quaternion.Euler(0, 0, startAngle) * Vector3.up * radius;
        Vector3 lastPos = pos;
        for (int i = 1; i <= 16; i++)
        {
            pos = center + Quaternion.Euler(0, 0, Mathf.Lerp(startAngle, endAngle, (float)i / 16)) * Vector3.up * radius;
            Gizmos.DrawLine(pos, lastPos);
            lastPos = pos;
        }
    }

    public void AddWeapon(GameObject weaponPrefab)
    {
        _weaponItem = Instantiate(weaponPrefab, transform).GetComponent<WeaponController>();
        _hasWeapon = true;
    }

    // Set the point to target.
    // Is called by VehicleController to tell the WeaponMount what point to aim at.
    // Just in case, this class has been given an explicit script execution order behind that of vehicleController,
    // So that if the target is set the turret will begin to respond on the same frame.
    public void SetTarget(Vector2 targetPoint)
    {
        _active = true;
        _target = targetPoint;
    }

    public void UnsetTarget()
    {
        _active = false;
    }

    // Fire the attached weapon
    // Is called by VehicleController every tick that the fire button is held
    // Since this class's FixedUpdate always executes after VehicleController's, if we called weapon.Fire() here, it would fire before turning.
    // Instead, we must set the _firing flag to true and then fire after turning in fixedUpdate()
    public void Fire()
    {
        _firing = true;
    }
}
