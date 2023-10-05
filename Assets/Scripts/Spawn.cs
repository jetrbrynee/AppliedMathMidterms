using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate; //   kung gano karami mag spawn enemy or like how often
    public GameObject[] enemies; // enemies: kumbaga menu of enemies na pwede mag spawn
    public int waves = 1; //  Number of enemies to spawn in each wave.

    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate); //  Invokes the SpawnEnemy method at regular intervals.
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < waves; i++) ; // This loop determines the number of enemies to spawn in each wave.
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-9.5f, 10f), 5, 0), Quaternion.identity);
        // Instantiate enemy at a random position within specified bounds.
    }
}
