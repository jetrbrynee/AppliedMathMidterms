using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody2D component for bullet movement.
    int dir = 1; // Direction variable

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // taga kuha ng component na rigidbody2d na naka attach sa game object.
    }

    public void ChangeDirection()
    {
        dir *= -1; // Changes the bullet's direction (upward or downward). in this case -1 sya so upward
    }

    void Update()
    {
        rb.velocity = new Vector2(0, 6 * dir); // Update bullet's movement based on its direction. (dito sa case na to ginagamit lang sya kumbaga gano kabilis mag travel bullet) 0 - di mag x axis, 6 sa y axis
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (dir == 1)
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemy>().Damage(); // Damages the enemy on collision.
                Destroy(gameObject); // Destroy the bullet.
            }
        }
        else
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<Player>().Damage(); // Damages the player on collision.
                Destroy(gameObject); // Destroy the bullet.
            }
        }
    }
}
