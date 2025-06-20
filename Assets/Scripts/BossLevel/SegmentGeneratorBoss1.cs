using System.Collections;
using UnityEngine;

public class SegmentGeneratorBoss1 : MonoBehaviour
{
    public GameObject[] segment;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }
    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 8);
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(3);
        creatingSegment = false;

    }
}
