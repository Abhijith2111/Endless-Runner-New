using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public float platformLength = 30f;
    public int numberOfPlatforms = 5;

    private float spawnZ = 0f;
    private List<GameObject> platforms = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberOfPlatforms; i++) SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > spawnZ - platformLength * (numberOfPlatforms - 2))
        {
            SpawnPlatform();

            if (platforms.Count > numberOfPlatforms)
            {
                Destroy(platforms[0], 5f); // Wait 5 seconds before destroying
                platforms.RemoveAt(0);
            }
        }
    }

    void SpawnPlatform()
    {
        Vector3 spawnPos = new Vector3(0, 0, spawnZ);
        GameObject platform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        platforms.Add(platform);
        spawnZ += platformLength;
    }
}
