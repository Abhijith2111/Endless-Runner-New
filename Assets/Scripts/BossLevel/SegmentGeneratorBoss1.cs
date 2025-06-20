using System.Collections;
using UnityEngine;

public class SegmentGeneratorBoss1 : MonoBehaviour
{
    public GameObject segmentMap01;
    public GameObject segmentMap02;
    public GameObject segmentMap03;
    public GameObject segmentMap04;
    public GameObject segmentMap05;
    public GameObject segmentMap06;
    public GameObject segmentMap07;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SegmentGen());
    }
    IEnumerator SegmentGen()
    {
        yield return new WaitForSeconds(5);
        segmentMap02.SetActive(true);
        yield return new WaitForSeconds(5);
        segmentMap03.SetActive(true);
        yield return new WaitForSeconds(5);
        segmentMap04.SetActive(true);
        yield return new WaitForSeconds(5);
        segmentMap05.SetActive(true);
        yield return new WaitForSeconds(5);
        segmentMap06.SetActive(true);
        yield return new WaitForSeconds(5);
        segmentMap07.SetActive(true);
    }
}
