using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRotatePoint : MonoBehaviour
{
    public Camera mainCam;
    public float TurnRate;
    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1 * Time.deltaTime * TurnRate);
    }
}
