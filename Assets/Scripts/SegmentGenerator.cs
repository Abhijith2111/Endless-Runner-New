using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;


    [SerializeField] int xPos = 50;
    [SerializeField] bool spawnSegment = false;
    [SerializeField] int segmentNum;

    [SerializeField] GameObject Player1;
    [SerializeField] GameObject CameraMain;
    [SerializeField] GameObject Death;

    
    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 3);
        GameObject newSegment = Instantiate(segment[segmentNum], new Vector3(xPos, 0, 0), Quaternion.identity);
        xPos += -50;
        


        var oofs = FindObjectsByType<OOF>(FindObjectsSortMode.None);
        

        

        foreach (var o in oofs)
        {
            if (o.Player1 == null)
            {
                o.Player1 = Player1;
            }
            if (o.CameraMain == null)
            {
                o.CameraMain = CameraMain;
            }
            if (o.Death == null)
            {
                o.Death = Death;
            }
        }
        yield return new WaitForSeconds(1);
        spawnSegment = false;

        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (spawnSegment == false)
        {
            spawnSegment = true;
            StartCoroutine(SegmentGen());

            
        }

    }
    
}
