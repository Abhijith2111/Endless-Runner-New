using UnityEngine;

public class BossMovement1 : MonoBehaviour
{
    public float bossSpeed = 7;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bossSpeed);
    }
}// potato
