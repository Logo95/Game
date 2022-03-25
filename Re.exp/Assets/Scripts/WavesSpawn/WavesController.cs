using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    private int enemiesLeft = -1;
    private WaveSpawner waveSpawner;
    
    private void Awake()
    {
        waveSpawner = GameObject.Find("SpawnController").GetComponent<WaveSpawner>();
    }

    private void Start()
    {
        InvokeRepeating("CheckEnemies", 3f, 3f);
    }

    public void CheckEnemies()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemiesLeft);
        if (enemiesLeft == 0)
            waveSpawner.StartWave();
    }
}
