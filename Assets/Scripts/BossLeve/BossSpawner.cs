using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;
    private bool bossSpawned = false;

    void Start()
    {
        
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
