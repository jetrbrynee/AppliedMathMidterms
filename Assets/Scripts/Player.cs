using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject a, b; // left and right bullets. Pag nag space si player mag f-fire sya, dalawa saya L and R bullets
    public GameObject bullet; // yung bullet game object
    Rigidbody2D rb; // yung rigidbody2d ng player
    public float horizontalSpeed = 20f; // Customize player's horizontal movement speed.
    public float verticalSpeed = 8f;   // Customize player's vertical movement speed.
    int health = 3; // Player's health (set to 3 by default).

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // taga kuha ng component na rigidbody2d na naka attach sa game object.
        a = transform.Find("L").gameObject; // Reference to the left bullet spawn point.
        b = transform.Find("R").gameObject; // Reference to the right bullet spawn point.
    }

    void Update()
    {
        // Handle horizontal movement.
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, rb.velocity.y);

        // Handle vertical movement.
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            // Move up (W).
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
        }
        else if (verticalInput < 0)
        {
            // Move down (S).
            rb.velocity = new Vector2(rb.velocity.x, -verticalSpeed);
        }

        // Shoot bullets when the SPACE key is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Damage()
    {
        health--; // Decrease player's health.
        if (health <= 0)
            Destroy(gameObject); // Destroy the player if health reaches zero.
    }

    void Shoot()
    {
        //  (halimbawa nag move ako as a player from left to right, basically mag m-move din yung bullet kasi nasa spaceship sya)
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }
}
