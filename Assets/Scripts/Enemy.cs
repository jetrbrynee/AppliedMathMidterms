using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb; // Reference to the Rigidbody2D component for enemy movement.

    public float xSpeed; // Horizontal speed of the enemy.
    public float ySpeed; // Vertical speed of the enemy.
    public int score; // Score value of the enemy.
    public bool canShoot; // Determines if the enemy can shoot. (like may check box sa enemy sprite)
    public float fireRate; // Rate at which the enemy shoots.
    public float health; // Health points of the enemy.

    public GameObject bulletPrefab; //basically yung bullet prefab, idk pano pa e-explain
    public float bulletSpeed = 10f; // Speed of the bullets.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // bali ito yung nag h-handle or like nag c-connect sa kung pano mag move yung bullet sa game. Kumbaga pano mag behave ganon.
    }

    void Start()
    {
        if (canShoot)
        {
            //  Sets up enemy shooting if canShoot is enabled (although ayaw pa rin).
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1); // Updates enemy movement.
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().Damage(); // Damages the player if they collide with the enemy.
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destroys the enemy object.
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score); // Increases the player's score.
    }

    public void Damage()
    {
        health--; // Decrease the enemy's health.
        if (health <= 0)
            Die();
    }

    // Shooting logic to shoot vertically downward (although ayaw talaga gumana)
    void Shoot()
    {
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            bulletRb.velocity = new Vector2(0f, -bulletSpeed); // Sets the bullet's velocity to move downward.
        }
    }
}
