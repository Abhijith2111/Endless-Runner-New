using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickupPrefabs;

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
        if (Random.value <= spawnChance && pickupPrefabs.Length > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), 0.5f, transform.position.z + 20f);

            int randomIndex = Random.Range(0, pickupPrefabs.Length);
            Instantiate(invincibilityPickupPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
