using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public int speed;
    public float rotSpeed;
    public bool player;
    public int health = 420;
    
    private SpriteRenderer sprite;
    private float hor;
    private float ver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == true && health > 0)
        {
            Controls();
        }
        if(health <= 0)
        {
            sprite.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

    }

    void FixedUpdate()
    {
        rb.rotation -= rotSpeed * hor;
        rb.velocity = (transform.up * speed * ver);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "tempBullet(Clone)")
        {
            Debug.Log(collision.gameObject.GetComponent<projectile>().speed);
            health -= collision.gameObject.GetComponent<projectile>().damage;
            Destroy(collision.gameObject);
        }
    }

    private void Controls()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
    }
}
