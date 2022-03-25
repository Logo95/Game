using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] waves;
    private int currentEnemyIndex;
    private int currentWaveIndex;
    private int enemiesLeftToSpawn;

    private void Start()
    {
        enemiesLeftToSpawn = waves[0].WaveSetting.Length;
        StartWave();
    }

    private IEnumerator SpawnEnemyWaves()
    {
        if (enemiesLeftToSpawn > 0)
        {
            yield return new WaitForSeconds(waves[currentWaveIndex].WaveSetting[currentEnemyIndex].SpawnDelay);
            Instantiate(waves[currentWaveIndex].WaveSetting[currentEnemyIndex].Enemy,
                        waves[currentWaveIndex].WaveSetting[currentEnemyIndex].Spawner.transform.position,
                        Quaternion.identity);
            enemiesLeftToSpawn--;
            currentEnemyIndex++;
            StartWave();
        }
        else
        {
            if (currentWaveIndex < waves.Length - 1)
            {
                currentWaveIndex++;
                enemiesLeftToSpawn = waves[currentWaveIndex].WaveSetting.Length;
                currentEnemyIndex = 0;
            }
        }
    }

    public void StartWave()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
}

[System.Serializable]

public class Waves
{
    [SerializeField] private WaveSettings[] waveSettings;
    public WaveSettings[] WaveSetting {get => waveSettings;}
}

[System.Serializable]

public class WaveSettings
{
    [SerializeField] private GameObject enemy;
    public GameObject Enemy {get => enemy;}

    [SerializeField] private GameObject spawner;
    public GameObject Spawner {get => spawner;}

    [SerializeField] private float spawnDelay;
    public float SpawnDelay {get => spawnDelay;}
}