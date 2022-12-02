using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public int damage;
    public Rigidbody2D origin;

    private Vector3 _lastPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.up * speed);
        _lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Linecast(_lastPos, transform.position);
        if (hit.rigidbody != null && hit.rigidbody != origin)
        {
            if (hit.rigidbody.TryGetComponent(out VehicleController hitVehicle))
            {
                //Debug.Log($"hit {hit.transform.name}, (not {origin.transform.name}) for {damage} damage, target health remaining: {hitChassis.GetHitPoints() - damage}" );
                hitVehicle.TakeDamage(damage);
                Destroy(gameObject);
                return;
            }
        }

        _lastPos = transform.position;
    }
}
