using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] collPrefabs;
    private float collSpawnRangeX = 14.0f;
    private float collSpawnPosY = 6.5f;
    private float collStartDelay = 2.0f;
    private float collSpawnInterval = 1.5f;
    public float enemyMaxRangeY;
    public float enemyMinRangeY;
    public float enemySpawnPosX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomCollectible", collStartDelay, collSpawnInterval);
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

}
