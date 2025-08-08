using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9f;
    protected int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemySpawnRandomly(waveNumber);
        SpawnPowerup();
    }

    private void SpawnPowerup()
    {
        Instantiate(
            powerupPrefab,
            GenerateRandomSpawnPosition(),
            powerupPrefab.transform.rotation);
    }

    private void EnemySpawnRandomly(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    protected Vector3 GenerateRandomSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        return new(spawnX, 0, spawnZ);
    }

    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            EnemySpawnRandomly(waveNumber);
            SpawnPowerup();
        }
    }
}
