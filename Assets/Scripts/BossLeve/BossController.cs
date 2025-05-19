using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject minePrefab;
    public float laserInterval = 2f;
    public float mineInterval = 3f;
    public Transform[] laserSpawnPoints;

    private float bossTimer = 0f;
    private float laserTimer = 0f;
    private float mineTimer = 0f;

    void Start()
    {
        // Start boss behavior
        StartCoroutine(BossBehavior());
    }

    IEnumerator BossBehavior()
    {
        // Boss lives for 30 seconds
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
    }

    void Update()
    {
        bossTimer += Time.deltaTime;
        laserTimer += Time.deltaTime;
        mineTimer += Time.deltaTime;

        // Shoot lasers at intervals
        if (laserTimer >= laserInterval)
        {
            ShootLasers();
            laserTimer = 0f;
        }

        // Drop mines at intervals
        if (mineTimer >= mineInterval)
        {
            DropMine();
            mineTimer = 0f;
        }
    }

    void ShootLasers()
    {
        foreach (Transform spawnPoint in laserSpawnPoints)
        {
            Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    void DropMine()
    {
        Vector3 minePosition = transform.position + new Vector3(Random.Range(-5f, 5f), 0, 0);
        Instantiate(minePrefab, minePosition, Quaternion.identity);
    }
}