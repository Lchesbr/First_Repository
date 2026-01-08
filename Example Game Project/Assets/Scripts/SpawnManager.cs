using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] collPrefabs;
    public GameObject enemy;
    private float collSpawnRangeX = 14.0f;
    private float collSpawnPosY = 6.5f;
    private float collStartDelay = 2.0f;
    private float collSpawnInterval = 1.5f;
    private float enemyStartDelayL = 2.0f;
    private float enemyStartDelayR = 3.5f;
    private float enemySpawnInterval = 2.0f;
    public float enemyMaxRangeY;
    public float enemyMinRangeY;
    public float enemySpawnPosX = 15.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomCollectible", collStartDelay, collSpawnInterval);
        InvokeRepeating("SpawnEnemyLeft", enemyStartDelayL, enemySpawnInterval);
        InvokeRepeating("SpawnEnemyRight", enemyStartDelayR, enemySpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomCollectible()
    {
        int collIndex = Random.Range(0, collPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-collSpawnRangeX, collSpawnRangeX), collSpawnPosY, 0);

        Instantiate(collPrefabs[collIndex], spawnPos, collPrefabs[collIndex].transform.rotation);
    }

    void SpawnEnemyLeft()
    {
        Vector3 enemySpawnPos = new Vector3(-enemySpawnPosX, Random.Range(enemyMinRangeY, enemyMaxRangeY), 0);

        Instantiate(enemy, enemySpawnPos, enemy.transform.rotation);
    }

    void SpawnEnemyRight()
    {
        Vector3 enemySpawnPos = new Vector3(enemySpawnPosX, Random.Range(enemyMinRangeY, enemyMaxRangeY), 0);
        Vector3 rotation = new Vector3(0, 0, -180);
        Instantiate(enemy, enemySpawnPos, Quaternion.Euler(rotation));
    }

}
