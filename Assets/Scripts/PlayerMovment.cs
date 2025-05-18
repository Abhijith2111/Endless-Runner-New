using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public float playerSpeed = 10;
    public float horizontalSpeed = 3;
    public float rightLimit = 6;
    public float leftLimit = -6;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 6;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);



        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.z > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.z < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
            }
        }

        //jump
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.01f, LayerMask.GetMask("Ground")))
            {
                Jump();
            }
            
        }
    }

    private void Jump()
    {
        
        rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    }
}
