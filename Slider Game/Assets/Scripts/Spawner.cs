using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject[] spawnPoints;

    public GameObject blockPrefab;

    public float obstacleSpeed;

    public float spawnRate = 2f;
    private float spawnCounter = 0f;

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Points");
    }

    void Update()
    {
        spawnRate -= Time.deltaTime / 100;

        spawnRate = Mathf.Clamp(spawnRate, .75f, 10f);

        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnRate)
        {
            SpawnBlocks();
            spawnCounter = 0;
        }
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spawnPoints[i].transform.position, Quaternion.identity);
            }
        }
    }
}
