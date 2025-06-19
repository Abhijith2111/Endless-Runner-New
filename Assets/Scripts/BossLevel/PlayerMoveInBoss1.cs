using UnityEngine;

public class PlayerMoveInBoss1 : MonoBehaviour
{
    public float playerSpeed = 2;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
    }
}// potato
