using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject invincibilityPickupPrefab;
    [SerializeField] private float spawnChance = 0.2f;
    [SerializeField] private float minSpawnDistance = 10f;
    [SerializeField] private float maxSpawnDistance = 30f;

    private float nextSpawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawnPosition = Random.Range(minSpawnDistance, maxSpawnDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= nextSpawnPosition)
        {
            TrySpawnPickup();
            nextSpawnPosition += Random.Range(minSpawnDistance, maxSpawnDistance);
        }
    }

    private void TrySpawnPickup()
    {
        if (Random.value <= spawnChance)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-3f, 3f), // Adjust based on your track width
                0.5f, // Adjust height as needed
                transform.position.z + 20f // Spawn ahead of player
            );

            Instantiate(invincibilityPickupPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
