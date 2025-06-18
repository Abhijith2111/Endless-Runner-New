using UnityEngine;

public class PlayerMovmentOther : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private float speedIncreaseInterval = 5f; 
    [SerializeField] private float speedIncrement = 1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 10;

    public float playerSpeed = 5;
    public float rightLimit = 6;
    public float leftLimit = -6;
    public bool canDoubleJump { get; set; }

    private float currentSpeed;
    private float timeSinceLastIncrease;
    bool hasDoubleJump;
    private bool isGameRunning = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning) return;
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= speedIncreaseInterval && currentSpeed < maxSpeed)
        {
            currentSpeed += speedIncrement;
            timeSinceLastIncrease = 0f;
        }



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

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.01f, LayerMask.GetMask("Ground"));

        if (isGrounded) hasDoubleJump = false;
        //jump     

        
            if (Input.GetKeyDown(KeyCode.Space))
            {
               if(isGrounded || (canDoubleJump && !hasDoubleJump))
               {
                    if(!isGrounded) hasDoubleJump = true;
                    Jump();
               }
                
            }

    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void Die()
    {
        Debug.Log("Player Died");
        isGameRunning = false;
    }

}
