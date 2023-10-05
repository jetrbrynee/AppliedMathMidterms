using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public int score;
    public bool canShoot;
    public float fireRate;
    public float health;

    // Reference to the bullet prefab
    public GameObject bulletPrefab;

    // Speed of the bullets (adjust as needed)
    public float bulletSpeed = 10f;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (canShoot)
        {
            // Start shooting at the specified fire rate
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().Damage();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
            Die();
    }

    // Shooting logic to shoot vertically downward
    void Shoot()
    {
        // Ensure the bullet prefab is assigned in the Inspector
        if (bulletPrefab != null)
        {
            // Instantiate a bullet at the enemy's position and rotation
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Access the bullet's rigidbody2D (assuming you have one on the bullet prefab)
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Set the bullet's velocity to move downward (negative Y direction)
            bulletRb.velocity = new Vector2(0f, -bulletSpeed); // Adjust bulletSpeed as needed
        }
    }
}
