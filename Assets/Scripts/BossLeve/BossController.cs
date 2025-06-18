using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject minePrefab;
    public float laserInterval = 2f;
    public float mineInterval = 3f;
    public Transform[] laserSpawnPoints;
    public string nextSceneName;

    private float laserTimer = 2f;
    private float mineTimer = 2f;

    void Start()
    {
        float lifeTime = Random.Range(15f, 30f);
        StartCoroutine(BossLifeCycle(lifeTime));
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 2f);

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
        int randomIndex = Random.Range(0, laserSpawnPoints.Length);
        Instantiate(laserPrefab, laserSpawnPoints[randomIndex].position, Quaternion.identity);
    }

    void DropMine()
    {
        Vector3 position = transform.position + new Vector3(Random.Range(-5f, 5f), 0, 0);
        Instantiate(minePrefab, position, Quaternion.identity);
    }

    IEnumerator BossLifeCycle(float lifeTime)
    {

        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        SceneManager.LoadScene(nextSceneName);
    }
}