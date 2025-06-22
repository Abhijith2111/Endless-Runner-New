using UnityEngine;

public class ScoreCollect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        Knowledge.scoreTally += 1;
    }
}
