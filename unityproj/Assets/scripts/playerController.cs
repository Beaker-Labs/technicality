using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public int speed;
    public float rotSpeed;

    private float hor;
    private float ver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.rotation -= rotSpeed * hor;
        rb.velocity = (transform.up * speed * ver);
    }
}
