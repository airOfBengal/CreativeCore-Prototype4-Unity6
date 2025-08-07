using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemySpawnRandomly();
    }

    private void EnemySpawnRandomly()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new(spawnX, 0, spawnZ);
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
}
