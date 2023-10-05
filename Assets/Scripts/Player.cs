using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject a, b;
    public GameObject bullet;
    Rigidbody2D rb;
    public float horizontalSpeed = 20f; // increase/decrease horizontal speed
    public float verticalSpeed = 8f;   // increase/decrease vertical speed
    int health = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("L").gameObject; 
        b = transform.Find("R").gameObject; 
    }

    void Update()
    {
        // horizontal na galaw 
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, rb.velocity.y);

        // vertical na galaw
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            // W
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
        }
        else if (verticalInput < 0)
        {
            // S
            rb.velocity = new Vector2(rb.velocity.x, -verticalSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
            Destroy(gameObject);
    }

    void Shoot()
    {
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }
}
