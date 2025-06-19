using UnityEngine;

public class PlayerMoveInBoss1 : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
        }
    }
}// potato
