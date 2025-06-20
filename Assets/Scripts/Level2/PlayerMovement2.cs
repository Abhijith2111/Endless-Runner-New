using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
    }
}