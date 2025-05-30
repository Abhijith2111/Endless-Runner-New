using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
    public GameObject teleporterPrefab; 

    [SerializeField] int xPos = 50;
    [SerializeField] bool spawnSegment = false;
    [SerializeField] int segmentNum;

    [SerializeField] GameObject Player1;
    [SerializeField] GameObject CameraMain;
    [SerializeField] GameObject Death;

    private float gameTime = 0f;
    private bool teleporterSpawned = false;
    private GameObject currentTeleporter;

    void Update()
    {
        gameTime += Time.deltaTime;

        if (spawnSegment == false)
        {
            spawnSegment = true;
            StartCoroutine(SegmentGen());
        }

        if (gameTime >= 30f && !teleporterSpawned)
        {
            SpawnTeleporter();
            teleporterSpawned = true;
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 2); 
        GameObject newSegment = Instantiate(segment[segmentNum], new Vector3(xPos, 0, 0), Quaternion.identity);
        xPos += -50;

        var oofs = FindObjectsByType<OOF>(FindObjectsSortMode.None);

        foreach (var o in oofs)
        {
            if (o.Player1 == null) o.Player1 = Player1;
            if (o.CameraMain == null) o.CameraMain = CameraMain;
            if (o.Death == null) o.Death = Death;
        }

        yield return new WaitForSeconds(1);
        spawnSegment = false;
    }

    void SpawnTeleporter()
    {
        if (teleporterPrefab == null)
        {
            Debug.LogError("Teleporter prefab is not assigned!");
            return;
        }

        Vector3 teleporterPos = Player1.transform.position + new Vector3(15f, 0f, 0f);
        currentTeleporter = Instantiate(teleporterPrefab, teleporterPos, Quaternion.identity);

        var collider = currentTeleporter.GetComponent<Collider>();
        if (collider == null)
        {
            collider = currentTeleporter.AddComponent<BoxCollider>();
            collider.isTrigger = true;
        }

        var teleporter = currentTeleporter.GetComponent<Teleporter>();
        if (teleporter == null)
        {
            teleporter = currentTeleporter.AddComponent<Teleporter>();
        }

        teleporter.targetScene = "BossFight"; 
        teleporter.player = Player1;

        var particles = currentTeleporter.GetComponent<ParticleSystem>();
        if (particles != null) particles.Play();
    }
}


