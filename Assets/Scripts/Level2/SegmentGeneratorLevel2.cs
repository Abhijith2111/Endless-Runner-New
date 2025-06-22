using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGeneratorLevel2 : MonoBehaviour
{
    public GameObject[] segment;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;

    private Queue<GameObject> segmentQueue = new Queue<GameObject>();
    private bool deletingStarted = false;

    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, segment.Length);
        GameObject newSegment = Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        segmentQueue.Enqueue(newSegment);
        zPos += 50;

        if (!deletingStarted)
        {
            deletingStarted = true;
            StartCoroutine(DeleteSegmentsOneByOne());
        }

        yield return new WaitForSeconds(3f);
        creatingSegment = false;
    }

    IEnumerator DeleteSegmentsOneByOne()
    {
        yield return new WaitForSeconds(15f);

        while (true)
        {
            if (segmentQueue.Count > 0)
            {
                GameObject oldest = segmentQueue.Dequeue();
                Destroy(oldest);
            }

            yield return new WaitForSeconds(15f);
        }
    }

}
