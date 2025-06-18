using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;

    void Start()
    {
        
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
